using DevExpress.XtraEditors;
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
    public partial class frmMain : DevExpress.XtraEditors.XtraForm
    {
        User user;
        Settings settings;

        public frmMain(User User, Settings Settings)
        {
            InitializeComponent();
            this.Icon = Properties.Resources.AppIcon;
            this.user = User;
            this.settings = Settings;
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            nameLabel.Text = user.firstName + " " + user.lastName;
            DateTime now = DateTime.Now;
            dateLabel.Text = now.ToString("dd:MM:yyyy - dddd");

            NpgsqlConnection connection = DBUtils.GetDBConnection(settings);

            NpgsqlCommand cmd = new NpgsqlCommand();
            cmd.Connection = connection;
            cmd.Parameters.AddWithValue(user.profileId);

            cmd.CommandText = "SELECT * FROM UserProfile WHERE UserProfile.id = $1;";
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
                                roleLabel.Text = reader.GetString(reader.GetOrdinal("name"));
                            }
                        }
                    }
                }
                catch (NpgsqlException ex)
                {
                    XtraMessageBox.Show($"{ex.Message}", "Внимание", MessageBoxButtons.OK);
                }
            }
            catch (InvalidOperationException exp)
            {
                XtraMessageBox.Show($"{exp.Message}", "Внимание", MessageBoxButtons.OK);
            }
            connection.Close();

            if(user.profileId == 1)
            {
                this.groupControl1.Visible = false;
                this.groupControl3.Visible = false;
                this.Size = new Size(600, 393);
            }
        }

        private void settingsButton_Click(object sender, EventArgs e)
        {
            frmSettings setting = new frmSettings(user, settings);
            setting.ShowDialog();
        }

        private void workingTimeButton_Click(object sender, EventArgs e)
        {
            frmWorkingTime workingTime = new frmWorkingTime(user, settings);
            workingTime.ShowDialog();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            frmWorkingTime workingTime = new frmWorkingTime(user, settings);
            workingTime.ShowDialog();
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            frmWebLogs webLogs = new frmWebLogs(user, settings);
            webLogs.ShowDialog();
        }

        private void webActivityButton_Click(object sender, EventArgs e)
        {
            frmWebLogs webLogs = new frmWebLogs(user, settings);
            webLogs.ShowDialog();
        }

        private void speechRecognitionButton_Click(object sender, EventArgs e)
        {
            frmStopWordsLogs stopWordsLogs = new frmStopWordsLogs(user, settings);
            stopWordsLogs.ShowDialog();
        }
    }
}