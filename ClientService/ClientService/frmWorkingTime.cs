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
    public partial class frmWorkingTime : DevExpress.XtraEditors.XtraForm
    {
        User user;
        Settings settings;
        List<WorkingMonitor> workingMonitors = new List<WorkingMonitor>();
        public frmWorkingTime(User User, Settings Settings)
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

        private void frmWorkingTime_Load(object sender, EventArgs e)
        {
            if(user.profileId == 1)
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
            if(user.profileId == 2)
            {
                if (listBoxControl1.ValueMember == null && dateEdit1.SelectedText != "")
                {
                    XtraMessageBox.Show("Заполните пустые поля", "Внимание", MessageBoxButtons.OK);
                }
                else
                {
                    DateTime date = dateEdit1.DateTime;
                    int id = (int)listBoxControl1.SelectedValue;

                    NpgsqlConnection connection = DBUtils.GetDBConnection(settings);

                    NpgsqlCommand cmd = new NpgsqlCommand();
                    cmd.Connection = connection;
                    cmd.Parameters.AddWithValue(date.Date);
                    cmd.Parameters.AddWithValue(id);

                    cmd.CommandText = "SELECT UsersWorkSessions.id, Users.firstname, Users.lastname, UsersWorkSessions.startTime, UsersWorkSessions.endTime, UsersWorkSessions.timeloss FROM UsersWorkSessions LEFT JOIN Users ON Users.id = UsersWorkSessions.userId WHERE UsersWorkSessions.userId = $2 AND DATE(UsersWorkSessions.startTime) = $1;";
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
                                        int rowId = reader.GetInt32(reader.GetOrdinal("id"));
                                        string firstName = reader.GetString(reader.GetOrdinal("firstname"));
                                        string lastName = reader.GetString(reader.GetOrdinal("lastname"));
                                        DateTime startTime = reader.GetDateTime(reader.GetOrdinal("startTime"));
                                        DateTime endTime = reader.GetDateTime(reader.GetOrdinal("endTime"));
                                        int timeloss = reader.GetInt32(reader.GetOrdinal("timeloss"));
                                        workingMonitors.Add(new WorkingMonitor(firstName, lastName, startTime, endTime, timeloss));
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
                    gridControl1.DataSource = workingMonitors;
                    gridView1.BestFitColumns();
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
                    DateTime date = dateEdit1.DateTime;

                    NpgsqlConnection connection = DBUtils.GetDBConnection(settings);

                    NpgsqlCommand cmd = new NpgsqlCommand();
                    cmd.Connection = connection;
                    cmd.Parameters.AddWithValue(date.Date);
                    cmd.Parameters.AddWithValue(user.id);

                    cmd.CommandText = "SELECT UsersWorkSessions.id, Users.firstname, Users.lastname, UsersWorkSessions.startTime, UsersWorkSessions.endTime, UsersWorkSessions.timeloss FROM UsersWorkSessions LEFT JOIN Users ON Users.id = UsersWorkSessions.userId WHERE UsersWorkSessions.userId = $2 AND DATE(UsersWorkSessions.startTime) = $1;";
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
                                        int rowId = reader.GetInt32(reader.GetOrdinal("id"));
                                        string firstName = reader.GetString(reader.GetOrdinal("firstname"));
                                        string lastName = reader.GetString(reader.GetOrdinal("lastname"));
                                        DateTime startTime = reader.GetDateTime(reader.GetOrdinal("startTime"));
                                        DateTime endTime = reader.GetDateTime(reader.GetOrdinal("endTime"));
                                        int timeloss = reader.GetInt32(reader.GetOrdinal("timeloss"));
                                        workingMonitors.Add(new WorkingMonitor(firstName, lastName, startTime, endTime, timeloss));
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
                    gridControl1.DataSource = workingMonitors;
                    gridView1.BestFitColumns();
                    gridControl1.RefreshDataSource();
                }
            }
        }
    }
}