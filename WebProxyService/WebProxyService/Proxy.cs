using MongoDB.Bson;
using Nest;
using Npgsql;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Titanium.Web.Proxy;
using Titanium.Web.Proxy.EventArguments;
using Titanium.Web.Proxy.Http;
using Titanium.Web.Proxy.Models;

namespace WebProxyService
{
    class Proxy
    {
        static void Main(string[] args)
        {
            NpgsqlConnection connection = DBUtils.GetDBConnection();
            List<string> blackList = new List<string>();
            Dictionary<string, string> redirectList = new Dictionary<string, string>();

            NpgsqlCommand cmd = new NpgsqlCommand();
            cmd.Connection = connection;

            cmd.CommandText = "SELECT * FROM webBlackList";
            try
            {
                try
                {
                    using (NpgsqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                blackList.Add(reader.GetString(reader.GetOrdinal("url")));
                                Console.WriteLine(reader.GetString(reader.GetOrdinal("url")));
                            }
                        }
                    }
                }
                catch (NpgsqlException ex)
                {
                    Console.WriteLine($"{ex.Message}", "Внимание");
                }
            }
            catch (InvalidOperationException exp)
            {
                Console.WriteLine($"{exp.Message}");
            }

            NpgsqlCommand cmd_1 = new NpgsqlCommand();
            cmd.Connection = connection;

            cmd.CommandText = "SELECT * FROM webRedirectList";
            try
            {
                try
                {
                    using (NpgsqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                string url = reader.GetString(reader.GetOrdinal("url"));
                                string redirectUrl = reader.GetString(reader.GetOrdinal("redirectUrl"));
                                redirectList.Add(url, redirectUrl);
                            }
                        }
                    }
                }
                catch (NpgsqlException ex)
                {
                    Console.WriteLine($"{ex.Message}", "Внимание");
                }
            }
            catch (InvalidOperationException exp)
            {
                Console.WriteLine($"{exp.Message}");
            }

            var proxyServer = new ProxyServer();
            RabbitMqService service = new RabbitMqService();
            proxyServer.BeforeRequest += OnRequest;
            proxyServer.BeforeResponse += OnResponse;
            proxyServer.ServerCertificateValidationCallback += OnCertificateValidation;
            proxyServer.ClientCertificateSelectionCallback += OnCertificateSelection;


            var explicitEndPoint = new ExplicitProxyEndPoint(IPAddress.Any, 8000, true)
            {
            };

            explicitEndPoint.BeforeTunnelConnectRequest += OnBeforeTunnelConnectRequest;
            proxyServer.ProxyBasicAuthenticateFunc = OnBasicAuth;


            proxyServer.AddEndPoint(explicitEndPoint);
            proxyServer.Start();


            foreach (var endPoint in proxyServer.ProxyEndPoints)
                Console.WriteLine("Listening on '{0}' endpoint at Ip {1} and port: {2} ",
                    endPoint.GetType().Name, endPoint.IpAddress, endPoint.Port);

            proxyServer.SetAsSystemHttpProxy(explicitEndPoint);
            proxyServer.SetAsSystemHttpsProxy(explicitEndPoint);


            Console.Read();

            explicitEndPoint.BeforeTunnelConnectRequest -= OnBeforeTunnelConnectRequest;
            proxyServer.BeforeRequest -= OnRequest;
            proxyServer.BeforeResponse -= OnResponse;
            proxyServer.ServerCertificateValidationCallback -= OnCertificateValidation;
            proxyServer.ClientCertificateSelectionCallback -= OnCertificateSelection;

            proxyServer.Stop();


            async Task OnBeforeTunnelConnectRequest(object sender, TunnelConnectSessionEventArgs e)
            {
                string hostname = e.HttpClient.Request.RequestUri.Host;

                if (hostname.Contains("dropbox.com"))
                {
                    e.DecryptSsl = false;
                }
            }

            async Task OnRequest(object sender, SessionEventArgs e)
            {
                if(e.HttpClient.Request.IsHttps && e.HttpClient.Request.Method == "GET")
                {
                    WebSiteLogs webSiteLogs = new WebSiteLogs(DBUtils.settings.userId, e.HttpClient.Request.Url, "webLog");
                    Console.WriteLine(e.HttpClient.Request.Host);
                    
                    var b = e.UserData;
                    BsonDocument bson = webSiteLogs.ToBsonDocument();
                    service.SendMessage(bson.ToString());
                }

                var requestHeaders = e.HttpClient.Request.Headers;

                var method = e.HttpClient.Request.Method.ToUpper();
                if ((method == "POST" || method == "PUT" || method == "PATCH"))
                {
                    byte[] bodyBytes = await e.GetRequestBody();
                    e.SetRequestBody(bodyBytes);

                    string bodyString = await e.GetRequestBodyAsString();
                    e.SetRequestBodyString(bodyString);

                    e.UserData = e.HttpClient.Request;
                }

                foreach(string url in blackList)
                {
                    if (e.HttpClient.Request.RequestUri.AbsoluteUri.Contains(url))
                    {
                        e.Ok("<!DOCTYPE html>" +
                            "<html><body><h1>" +
                            "Сайт заблокирован" +
                            "</h1>" +
                            "<p>Обратитесь к администрации за подробностями</p>" +
                            "</body>" +
                            "</html>");
                    }
                }
                foreach(var url in redirectList)
                {
                    if (e.HttpClient.Request.RequestUri.AbsoluteUri.Contains(url.Value))
                    {
                        e.Redirect($"https://www.{url.Key}");
                    }
                }
            }

            async Task OnResponse(object sender, SessionEventArgs e)
            {
                var responseHeaders = e.HttpClient.Response.Headers;

                if (e.HttpClient.Request.Method == "GET" || e.HttpClient.Request.Method == "POST")
                {
                    if (e.HttpClient.Response.StatusCode == 200)
                    {
                        if (e.HttpClient.Response.ContentType != null && e.HttpClient.Response.ContentType.Trim().ToLower().Contains("text/html"))
                        {
                            byte[] bodyBytes = await e.GetResponseBody();
                            e.SetResponseBody(bodyBytes);

                            string body = await e.GetResponseBodyAsString();
                            e.SetResponseBodyString(body);
                        }
                    }
                }

                if (e.UserData != null)
                {
                    var request = (Request)e.UserData;
                }
            }

            Task OnCertificateValidation(object sender, CertificateValidationEventArgs e)
            {
                if (e.SslPolicyErrors == System.Net.Security.SslPolicyErrors.None)
                    e.IsValid = true;

                return Task.CompletedTask;
            }

            Task OnCertificateSelection(object sender, CertificateSelectionEventArgs e)
            {
                // set e.clientCertificate to override
                return Task.CompletedTask;
            }
            Task<bool> OnBasicAuth(SessionEventArgsBase ev, string u, string p)
            {
                if (u == "test" && p == "pass")
                {
                    return Task.FromResult(true);
                }
                return Task.FromResult(false);
            }
        }
    }
}
