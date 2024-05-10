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
    public partial class frmSettings : DevExpress.XtraEditors.XtraForm
    {
        Settings settings;
        User user;
        Dictionary<string, int> idWord = new Dictionary<string, int>();
        public frmSettings(User User, Settings Settings)
        {
            InitializeComponent();
            this.Icon = Properties.Resources.AppIcon;
            this.user = User;
            this.settings = Settings;
        }

        private void frmSettings_Load(object sender, EventArgs e)
        {
            LoadTableBlackList();
            LoadTableRedirectList();
            LoadListBox();
        }

        private void LoadTableBlackList()
        {
            DataSet dsBlacklist = new DataSet();
            DataTable dtBlackList = new DataTable();
            NpgsqlConnection connection = DBUtils.GetDBConnection(settings);

            string cmd = "SELECT * FROM WebBlackList;";
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd, connection);
            dsBlacklist.Reset();
            da.Fill(dsBlacklist);
            dtBlackList = dsBlacklist.Tables[0];
            gridControl1.DataSource = dtBlackList;
            gridView1.BestFitColumns();
            connection.Close();
            gridControl1.RefreshDataSource();
        }

        private void LoadTableRedirectList()
        {
            DataSet dsRedirectlist = new DataSet();
            DataTable dtRedirectList = new DataTable();
            NpgsqlConnection connection = DBUtils.GetDBConnection(settings);

            string cmd = "SELECT * FROM WebRedirectList;";
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd, connection);
            dsRedirectlist.Reset();
            da.Fill(dsRedirectlist);
            dtRedirectList = dsRedirectlist.Tables[0];
            gridControl2.DataSource = dtRedirectList;
            gridView2.BestFitColumns();
            connection.Close();
            gridControl2.RefreshDataSource();
        }

        private void LoadListBox()
        {
            searchControl1.Client = listBoxControl1;
            listBoxControl1.Items.Clear();

            NpgsqlConnection connection = DBUtils.GetDBConnection(settings);

            NpgsqlCommand cmd_p = new NpgsqlCommand();

            cmd_p.Connection = connection;
            try
            {
                cmd_p.CommandText = "SELECT * FROM StopWords;";

                using (NpgsqlDataReader reader = cmd_p.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            int id = reader.GetInt32(reader.GetOrdinal("id"));
                            string word = reader.GetString(reader.GetOrdinal("word"));
                            idWord.Add(word, id);
                            listBoxControl1.Items.Add(word);
                        }
                    }
                }
            }
            catch (NpgsqlException ex)
            {
                XtraMessageBox.Show($"{ex.Message}", "Внимание", MessageBoxButtons.OK);
            }
            listBoxControl1.Refresh();
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            renameBlackList.Text = gridView1.GetFocusedRowCellValue("url").ToString();
        }

        private void editBlackListButton_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(renameBlackList.Text) && gridView1.GetFocusedRow() == null)
            {
                XtraMessageBox.Show("Заполните пустые поля", "Внимание", MessageBoxButtons.OK);
            }
            else
            {
                try
                {
                    int id = (int)gridView1.GetFocusedRowCellValue("id");
                    NpgsqlConnection connection = DBUtils.GetDBConnection(settings);

                    NpgsqlCommand cmd = new NpgsqlCommand();
                    cmd.Connection = connection;
                    cmd.Parameters.AddWithValue(renameBlackList.Text);
                    cmd.Parameters.AddWithValue(id);

                    cmd.CommandText = "UPDATE WebBlackList SET url = $1 WHERE WebBlackList.id = $2;";

                    var rowAffected = cmd.ExecuteNonQuery();
                    LoadTableBlackList();
                    if (rowAffected != 0)
                    {
                        XtraMessageBox.Show("Адрес успешно обновлен", "Успех", MessageBoxButtons.OK);
                    }
                    connection.Close();
                }
                catch (NpgsqlException ex)
                {
                    XtraMessageBox.Show($"{ex.Message}", "Внимание", MessageBoxButtons.OK);
                }
            }
        }

        private void deleteBlackListButton_Click(object sender, EventArgs e)
        {
            if (gridView1.GetFocusedRow() != null)
            {
                int id = (int)gridView1.GetFocusedRowCellValue("id");
                try
                {
                    NpgsqlConnection connection = DBUtils.GetDBConnection(settings);

                    NpgsqlCommand cmd = new NpgsqlCommand();
                    cmd.Connection = connection;
                    cmd.Parameters.AddWithValue(id);

                    cmd.CommandText = "DELETE FROM WebBlackList WHERE WebBlackList.id = $1;";

                    var rowAffected = cmd.ExecuteNonQuery();
                    LoadTableBlackList();
                    if (rowAffected != 0)
                    {
                        XtraMessageBox.Show("Сайт удален", "Успех", MessageBoxButtons.OK);
                    }
                    connection.Close();
                }
                catch (NpgsqlException ex)
                {
                    XtraMessageBox.Show($"{ex.Message}", "Внимание", MessageBoxButtons.OK);
                }
            }
        }

        private void newBlackListButton_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(newBlackList.Text))
            {
                XtraMessageBox.Show("Заполните пустые поля", "Внимание", MessageBoxButtons.OK);
            }
            else
            {
                try
                {
                    NpgsqlConnection connection = DBUtils.GetDBConnection(settings);

                    NpgsqlCommand cmd = new NpgsqlCommand();
                    cmd.Connection = connection;
                    cmd.Parameters.AddWithValue(newBlackList.Text);

                    cmd.CommandText = "INSERT INTO WebBlackList(url) VALUES($1);";
                    LoadTableBlackList();

                    var rowAffected = cmd.ExecuteNonQuery();
                    if (rowAffected != 0)
                    {
                        XtraMessageBox.Show("Сайт добавлен в черный список", "Успех", MessageBoxButtons.OK);
                    }
                    connection.Close();
                }
                catch (NpgsqlException ex)
                {
                    XtraMessageBox.Show($"{ex.Message}", "Внимание", MessageBoxButtons.OK);
                }
            }
        }

        private void editRedirectButton_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(editRedirect.Text) && String.IsNullOrEmpty(editRedirectUrl.Text) && gridView2.GetFocusedRow() == null)
            {
                XtraMessageBox.Show("Заполните пустые поля", "Внимание", MessageBoxButtons.OK);
            }
            else
            {
                try
                {
                    int id = (int)gridView2.GetFocusedRowCellValue("id");
                    NpgsqlConnection connection = DBUtils.GetDBConnection(settings);

                    NpgsqlCommand cmd = new NpgsqlCommand();
                    cmd.Connection = connection;
                    cmd.Parameters.AddWithValue(editRedirect.Text);
                    cmd.Parameters.AddWithValue(editRedirectUrl.Text);
                    cmd.Parameters.AddWithValue(id);

                    cmd.CommandText = "UPDATE WebRedirectList SET url = $1, redirecturl = $2 WHERE WebRedirectList.id = $3;";

                    var rowAffected = cmd.ExecuteNonQuery();
                    LoadTableRedirectList();
                    if (rowAffected != 0)
                    {
                        XtraMessageBox.Show("Адрес успешно обновлен", "Успех", MessageBoxButtons.OK);
                    }
                    connection.Close();
                }
                catch (NpgsqlException ex)
                {
                    XtraMessageBox.Show($"{ex.Message}", "Внимание", MessageBoxButtons.OK);
                }
            }
        }

        private void deleteRedirectButton_Click(object sender, EventArgs e)
        {
            if (gridView2.GetFocusedRow() != null)
            {
                int id = (int)gridView2.GetFocusedRowCellValue("id");
                try
                {
                    NpgsqlConnection connection = DBUtils.GetDBConnection(settings);

                    NpgsqlCommand cmd = new NpgsqlCommand();
                    cmd.Connection = connection;
                    cmd.Parameters.AddWithValue(id);

                    cmd.CommandText = "DELETE FROM WebRedirectList WHERE WebRedirectList.id = $1;";

                    var rowAffected = cmd.ExecuteNonQuery();
                    LoadTableRedirectList();
                    if (rowAffected != 0)
                    {
                        XtraMessageBox.Show("Сайт удален", "Успех", MessageBoxButtons.OK);
                    }
                    connection.Close();
                }
                catch (NpgsqlException ex)
                {
                    XtraMessageBox.Show($"{ex.Message}", "Внимание", MessageBoxButtons.OK);
                }
            }
        }

        private void addRedirectButton_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(newRedirect.Text) && String.IsNullOrEmpty(newRedirectUrl.Text))
            {
                XtraMessageBox.Show("Заполните пустые поля", "Внимание", MessageBoxButtons.OK);
            }
            else
            {
                try
                {
                    NpgsqlConnection connection = DBUtils.GetDBConnection(settings);

                    NpgsqlCommand cmd = new NpgsqlCommand();
                    cmd.Connection = connection;
                    cmd.Parameters.AddWithValue(newRedirect.Text);
                    cmd.Parameters.AddWithValue(newRedirectUrl.Text);

                    cmd.CommandText = "INSERT INTO WebRedirectList(url, redirecturl) VALUES($1, $2);";

                    var rowAffected = cmd.ExecuteNonQuery();
                    LoadTableRedirectList();
                    if (rowAffected != 0)
                    {
                        XtraMessageBox.Show("Сайт добавлен в список переадресации", "Успех", MessageBoxButtons.OK);
                    }
                    connection.Close();
                }
                catch (NpgsqlException ex)
                {
                    XtraMessageBox.Show($"{ex.Message}", "Внимание", MessageBoxButtons.OK);
                }
            }
        }

        private void gridView2_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            editRedirect.Text = gridView2.GetFocusedRowCellValue("url").ToString();
            editRedirectUrl.Text = gridView2.GetFocusedRowCellValue("redirecturl").ToString();
        }

        private void listBoxControl1_SelectedValueChanged(object sender, EventArgs e)
        {
            editWord.Text = listBoxControl1.SelectedItem.ToString();
        }

        private void editWordButton_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(editWord.Text) && !idWord.ContainsKey(listBoxControl1.SelectedItem.ToString()))
            {
                XtraMessageBox.Show("Заполните пустые поля", "Внимание", MessageBoxButtons.OK);
            }
            else
            {
                try
                {
                    int id = idWord[listBoxControl1.SelectedItem.ToString()];
                    idWord.Remove(listBoxControl1.SelectedItem.ToString());
                    NpgsqlConnection connection = DBUtils.GetDBConnection(settings);

                    NpgsqlCommand cmd = new NpgsqlCommand();
                    cmd.Connection = connection;
                    cmd.Parameters.AddWithValue(editWord.Text);
                    cmd.Parameters.AddWithValue(id);

                    cmd.CommandText = "UPDATE StopWords SET word = $1 WHERE StopWords.id = $2;";

                    var rowAffected = cmd.ExecuteNonQuery();
                    idWord.Add(editWord.Text, id);
                    LoadListBox();
                    if (rowAffected != 0)
                    {
                        XtraMessageBox.Show("Слово успешно обновлено", "Успех", MessageBoxButtons.OK);
                    }
                    connection.Close();
                }
                catch (NpgsqlException ex)
                {
                    XtraMessageBox.Show($"{ex.Message}", "Внимание", MessageBoxButtons.OK);
                }
            }
        }

        private void deleteWordButton_Click(object sender, EventArgs e)
        {
            if (idWord.ContainsKey(listBoxControl1.SelectedItem.ToString()))
            {
                try
                {
                    int id = idWord[listBoxControl1.SelectedItem.ToString()];
                    idWord.Remove(listBoxControl1.SelectedItem.ToString());
                    NpgsqlConnection connection = DBUtils.GetDBConnection(settings);

                    NpgsqlCommand cmd = new NpgsqlCommand();
                    cmd.Connection = connection;
                    cmd.Parameters.AddWithValue(id);

                    cmd.CommandText = "DELETE FROM StopWords WHERE StopWords.id = $1;";

                    var rowAffected = cmd.ExecuteNonQuery();
                    LoadListBox();
                    if (rowAffected != 0)
                    {
                        XtraMessageBox.Show("Слово удалено", "Успех", MessageBoxButtons.OK);
                    }
                    connection.Close();
                }
                catch (NpgsqlException ex)
                {
                    XtraMessageBox.Show($"{ex.Message}", "Внимание", MessageBoxButtons.OK);
                }
            }
        }

        private void addWordButton_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(addWord.Text))
            {
                XtraMessageBox.Show("Заполните пустые поля", "Внимание", MessageBoxButtons.OK);
            }
            else
            {
                NpgsqlConnection connection = DBUtils.GetDBConnection(settings);

                NpgsqlCommand cmdSelect = new NpgsqlCommand();
                cmdSelect.Connection = connection;
                int count = 0;

                cmdSelect.CommandText = "SELECT COUNT(*) FROM StopWords;";

                try
                {
                    try
                    {
                        using (NpgsqlDataReader reader = cmdSelect.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    count = reader.GetInt32(reader.GetOrdinal("count"));
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
                try
                {
                    NpgsqlCommand cmd = new NpgsqlCommand();
                    cmd.Connection = connection;
                    cmd.Parameters.AddWithValue(addWord.Text);

                    cmd.CommandText = "INSERT INTO StopWords(word) VALUES($1);";

                    var rowAffected = cmd.ExecuteNonQuery();
                    idWord.Add(addWord.Text, count + 1);
                    LoadTableRedirectList();
                    if (rowAffected != 0)
                    {
                        XtraMessageBox.Show("Слово добавлено в список стоп-слов", "Успех", MessageBoxButtons.OK);
                    }
                }
                catch (NpgsqlException ex)
                {
                    XtraMessageBox.Show($"{ex.Message}", "Внимание", MessageBoxButtons.OK);
                }
                connection.Close();
            }
        }
    }
}