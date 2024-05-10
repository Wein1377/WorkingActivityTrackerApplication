using DevExpress.XtraEditors;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClientService
{
    class DBUtils
    {
        public static NpgsqlConnection GetDBConnection(Settings settings)
        {
            NpgsqlConnection connection = DBServerUtils.GetDBConnection(settings);
            try
            {
                connection.Open();
            }
            catch (NpgsqlException ex)
            {
                XtraMessageBox.Show($"{ex.Message}", "Внимание", MessageBoxButtons.OK);
            }
            return connection;
        }
    }
}
