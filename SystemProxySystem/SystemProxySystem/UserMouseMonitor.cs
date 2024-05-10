using Npgsql;
using System;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;

namespace SystemProxySystem
{
    class UserMouseMonitor
    {
        static DateTime start = DateTime.Now;
        static int userId = 0;

        static void Main(string[] args)
        {
            Console.WriteLine("UserMouseMonitor");
            AppDomain.CurrentDomain.ProcessExit += new EventHandler(OnProcessExit);

            Point prevPnt = new Point();
            int counter = 0;

            NpgsqlConnection connection = DBUtils.GetDBConnection();

            NpgsqlCommand cmd = new NpgsqlCommand();
            cmd.Connection = connection;
            cmd.Parameters.AddWithValue(File.ReadAllText("token.txt"));
            string firstName = " ";
            string lastName = " ";
            int profileId = 0;


            cmd.CommandText = "SELECT * FROM Sessions LEFT JOIN Users ON Users.id = Sessions.userId WHERE Sessions.token = $1;";
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
                                userId = reader.GetInt32(reader.GetOrdinal("userId"));
                                firstName = reader.GetString(reader.GetOrdinal("firstName"));
                                lastName = reader.GetString(reader.GetOrdinal("lastName"));
                                profileId = reader.GetInt32(reader.GetOrdinal("profileId"));
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
            cmd_1.Connection = connection;
            cmd_1.Parameters.AddWithValue(userId);
            cmd_1.Parameters.AddWithValue(start);

            cmd_1.CommandText = "INSERT INTO UsersWorkSessions(userId, startTime) VALUES($1, $2)";
            try
            {
                cmd_1.ExecuteScalar();
            }
            catch (InvalidOperationException exp)
            {
                Console.WriteLine($"{exp.Message}");
            }

            while (true)
            {
                Point defPnt = new Point();

                GetCursorPos(ref defPnt);
                Console.WriteLine(defPnt.X);
                Console.WriteLine(defPnt.Y);
                if (defPnt == prevPnt)
                {
                    counter++;
                    if(counter > 5)
                    {
                        NpgsqlCommand cmd_2 = new NpgsqlCommand();
                        cmd_2.Connection = connection;
                        cmd_2.Parameters.AddWithValue(userId);
                        cmd_2.Parameters.AddWithValue(start);
                        cmd_2.Parameters.AddWithValue(counter * 60);

                        cmd_2.CommandText = "UPDATE UsersWorkSessions SET timeLoss = timeLoss + $3 WHERE userId = $1 AND startTime = $2";
                        try
                        {
                            cmd_2.ExecuteScalar();
                        }
                        catch (InvalidOperationException exp)
                        {
                            Console.WriteLine($"{exp.Message}");
                        }
                    }
                }
                prevPnt = defPnt;
                counter = 0;

                Thread.Sleep(60000);
            }

            [DllImport("user32.dll")]

            static extern bool GetCursorPos(ref Point lpPoint);
        }
        static void OnProcessExit(object sender, EventArgs e)
        {
            NpgsqlConnection connection = DBUtils.GetDBConnection();
            NpgsqlCommand cmd_3 = new NpgsqlCommand();
            cmd_3.Connection = connection;
            cmd_3.Parameters.AddWithValue(userId);
            cmd_3.Parameters.AddWithValue(start);

            cmd_3.CommandText = "UPDATE UsersWorkSessions SET endTime = NOW() WHERE userId = $1 AND startTime = $2";
            try
            {
                cmd_3.ExecuteScalar();
            }
            catch (InvalidOperationException exp)
            {
                Console.WriteLine($"{exp.Message}");
            }
            connection.Close();
        }
    }
}
