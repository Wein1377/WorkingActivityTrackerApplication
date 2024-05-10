using DevExpress.XtraEditors;
using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ClientService
{
    public partial class frmAuth : DevExpress.XtraEditors.XtraForm
    {
        public User user;
        public Settings settings;

        public frmAuth()
        {
            InitializeComponent();
            this.Icon = Properties.Resources.AppIcon;
        }

        private bool auth(String token)
        {
            NpgsqlConnection connection = DBUtils.GetDBConnection(settings);

            NpgsqlCommand cmd = new NpgsqlCommand();
            cmd.Connection = connection;
            cmd.Parameters.AddWithValue(token);
            int userId = 0;
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
                                user = new User(userId, firstName, lastName, profileId);
                                return true;
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
            return false;
        }

        private void authButton_Click(object sender, EventArgs e)
        {
            string login = this.loginText.Text;
            string password = this.passwordText.Text;

            login = login.Trim();
            password = password.Trim();

            NpgsqlConnection connection = DBUtils.GetDBConnection(settings);

            NpgsqlCommand cmd = new NpgsqlCommand();
            cmd.Connection = connection;
            int userId = 0;
            string firstName = " ";
            string lastName = " ";
            int profileId = 0;

            cmd.Parameters.AddWithValue(login);
            cmd.Parameters.AddWithValue(password);

            cmd.CommandText = "SELECT * FROM UserLogin LEFT JOIN Users ON Users.id = UserLogin.userId WHERE UserLogin.login = $1 AND UserLogin.password = $2;";

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
                                user = new User(userId, firstName, lastName, profileId);
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

            try
            {
                NpgsqlCommand cmd_1 = new NpgsqlCommand();
                cmd_1.Connection = connection;
                string token = Convert.ToBase64String(Guid.NewGuid().ToByteArray());
                cmd_1.Parameters.AddWithValue(userId);
                cmd_1.Parameters.AddWithValue(token);
                cmd_1.CommandText = "INSERT INTO Sessions(userId, token) values ($1, $2);";
                cmd_1.ExecuteScalar();
                File.WriteAllText("token.txt", token);
            }
            catch(NpgsqlException ex)
            {
                XtraMessageBox.Show($"{ex.Message}", "Внимание", MessageBoxButtons.OK);
            }

            string output = Newtonsoft.Json.JsonConvert.SerializeObject(settings, Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText(@"C:\Users\Nikita\Desktop\Диплом\ClientService\conf.json", output);
        }

        private void passwordText_EditValueChanged(object sender, EventArgs e)
        {
            passwordText.Properties.PasswordChar = '\u25CF';
            if (Control.IsKeyLocked(Keys.CapsLock))
            {
                MessageBox.Show("Зажат CAPS LOCK", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
            }
        }

        private void frmAuth_Load(object sender, EventArgs e)
        {
            this.settings = new Settings();
        }

        private void frmAuth_Shown(object sender, EventArgs e)
        {
        //    if (File.Exists("token.txt"))
            //{
                //string token = File.ReadAllText("token.txt");
                //if (token != null && auth(token))
               // {
                    frmMain frmMain = new frmMain(user, settings);
                 //   frmMain.Show();
               //     this.Hide();
             //   }
           // }
        }
    }
}
