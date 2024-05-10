using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemProxySystem
{
    class DBUtils
    {
        public static Settings settings;

        public static NpgsqlConnection GetDBConnection()
        {
            settings = new Settings();
            NpgsqlConnection connection = DBServerUtils.GetDBConnection(settings);
            try
            {
                connection.Open();
            }
            catch (NpgsqlException ex)
            {
                Console.WriteLine($"{ex.Message}");
            }
            return connection;
        }
    }
}
