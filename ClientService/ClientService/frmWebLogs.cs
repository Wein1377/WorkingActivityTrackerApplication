using DevExpress.XtraEditors;
using MongoDB.Bson;
using MongoDB.Driver;
using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClientService
{
    public partial class frmWebLogs : DevExpress.XtraEditors.XtraForm
    {
        User user;
        Settings settings;
        List<WebSiteLogs> logs = new List<WebSiteLogs>();
        public frmWebLogs(User User, Settings Settings)
        {
            InitializeComponent();
            this.Icon = Properties.Resources.AppIcon;
            this.user = User;
            this.settings = Settings;
            listBoxControl1.DisplayMember = "lastname";
            listBoxControl1.ValueMember = "id";
        }

        private void LoadUsers()
        {
            DataSet dsBlacklist = new DataSet();
            DataTable dtBlackList = new DataTable();
            NpgsqlConnection connection = DBUtils.GetDBConnection(settings);

            string cmd = $"SELECT * FROM Users WHERE responsibleId = {user.id};";
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd, connection);
            dsBlacklist.Reset();
            da.Fill(dsBlacklist);
            dtBlackList = dsBlacklist.Tables[0];
            listBoxControl1.DataSource = dtBlackList;
            connection.Close();
        }

        private void frmWebLogs_Load(object sender, EventArgs e)
        {
            if (user.profileId == 1)
            {
                this.listBoxControl1.Visible = false;
                this.searchControl1.Visible = false;
            }
            else
            {
                LoadUsers();
            }
        }

        private void reportButton_Click(object sender, EventArgs e)
        {
            MongoDDUtils mongo = new MongoDDUtils(settings);
            if (user.profileId == 2)
            {
                if (listBoxControl1.ValueMember == null && dateEdit1.SelectedText != "")
                {
                    XtraMessageBox.Show("Заполните пустые поля", "Внимание", MessageBoxButtons.OK);
                }
                else
                {
                    int userdId = (int)listBoxControl1.SelectedValue;
                    string dateStart = dateEdit1.DateTime.AddHours(0).AddMinutes(0).AddSeconds(0).AddMilliseconds(0).ToString("yyyy-MM-ddTHH:mm:ss.fffZ");
                    string dateEnd = dateEdit1.DateTime.AddHours(23).AddMinutes(59).AddSeconds(59).AddMilliseconds(999).ToString("yyyy-MM-ddTHH:mm:ss.fffZ");

                    var filterBuilder = Builders<BsonDocument>.Filter;
                    var filter = filterBuilder.Gte("visitTime", BsonDateTime.Create(dateStart)) & filterBuilder.Lte("visitTime", BsonDateTime.Create(dateEnd)) & filterBuilder.Eq("userId", userdId);
                    var result = mongo.logs.Find(filter).ToList();

                    foreach (var log in result)
                    {
                        logs.Add(new WebSiteLogs(log.GetValue("url").ToString(), log.GetValue("visitTime").ToUniversalTime()));
                    }
                    gridControl1.DataSource = logs;
                    gridControl1.RefreshDataSource();
                }
            }
            else
            {
                if (dateEdit1.SelectedText != "")
                {
                    XtraMessageBox.Show("Заполните пустые поля", "Внимание", MessageBoxButtons.OK);
                }
                else
                {
                    string dateStart = dateEdit1.DateTime.AddHours(0).AddMinutes(0).AddSeconds(0).AddMilliseconds(0).ToString("yyyy-MM-ddTHH:mm:ss.fffZ");
                    string dateEnd = dateEdit1.DateTime.AddHours(23).AddMinutes(59).AddSeconds(59).AddMilliseconds(999).ToString("yyyy-MM-ddTHH:mm:ss.fffZ");

                    var filterBuilder = Builders<BsonDocument>.Filter;
                    var filter = filterBuilder.Gte("visitTime", BsonDateTime.Create(dateStart)) & filterBuilder.Lte("visitTime", BsonDateTime.Create(dateEnd)) & filterBuilder.Eq("userId", user.id);
                    var result = mongo.logs.Find(filter).ToList();

                    foreach (var log in result)
                    {
                        logs.Add(new WebSiteLogs(log.GetValue("url").ToString(), log.GetValue("visitTime").ToUniversalTime()));
                    }
                    gridControl1.DataSource = logs;
                    gridControl1.RefreshDataSource();
                }
            }
        }
    }
}