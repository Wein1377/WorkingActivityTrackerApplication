using MongoDB.Bson;
using System;
using System.ComponentModel;

namespace ClientService
{
    public class WebSiteLogs
    {
        [DisplayName("URL")]
        public string url { get; set; }
        [DisplayName("Время обращения")]
        public DateTime visitTime { get; set; }

        public WebSiteLogs(string Url, DateTime dateTime)
        {
            this.visitTime = dateTime;
            this.url = Url;
        }
    }
}
