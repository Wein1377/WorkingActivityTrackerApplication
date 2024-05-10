using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeechHandler
{
    class DBServerUtils
    {
        public static NpgsqlConnection GetDBConnection(Settings settings)
        {
            string connString = $"Host={settings.dbHost};Username={settings.dbUser};Password={settings.dbPassword};Database={settings.db};Port={settings.dbPort}";

            NpgsqlConnection conn = new NpgsqlConnection(connString);

            return conn;
        }
    }
}
