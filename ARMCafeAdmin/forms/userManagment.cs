using System;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using System.Data;
using ClosedXML.Excel;

namespace ARMCafeAdmin
{
    public partial class userManagment : Form
    {

        DBEntity db = new DBEntity();
        User user = new User();
        int userId = 0;
        public userManagment()
        {
            InitializeComponent();
            
        }

        private void userManagmentForm_Load(object sender, EventArgs e)
        {
            SetDataInGridView();
        }

        public void SetDataInGridView()
        {
            var result = from a in db.Users
                              select new
                              {
                                  a.Id,
                                  a.Username,
                                  a.FirstName,
                                  a.LastName,
                                  a.IsActive,
                                  a.isAdmininistrator,




                              };


            dataGridViewUsers.DataSource = result.ToList();
            dataGridViewUsers.EnableHeadersVisualStyles = false;
            dataGridViewUsers.Columns[0].Visible = false;
            dataGridViewUsers.Columns[1].HeaderText = "Логин";
            dataGridViewUsers.Columns[2].HeaderText = "Имя";
            dataGridViewUsers.Columns[3].HeaderText = "Фамилия";
            dataGridViewUsers.Columns[4].HeaderText = "Активен?";
            dataGridViewUsers.Columns[5].HeaderText = "Администратор?";


        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                
                    
                    user.Username = txtUsername.Text.Trim();
                    user.Password = txtPassword.Text.Trim();
                    user.FirstName = txtFirstName.Text.Trim();
                    user.LastName = txtLastName.Text.Trim();
                    user.IsActive = cbIsActive.Checked;
                    user.isAdmininistrator = cbIsAdmin.Checked;

                    if (userId > 0)
                    {
                        db.Entry(user).State = System.Data.Entity.EntityState.Modified;
                    }
                    else
                    {
                        db.Users.Add(user);
                    }

                    db.SaveChanges();
                    ClearData();
                    SetDataInGridView();
                    MessageBox.Show("Успешно обновлено");
                
                
                
            }
            catch (Exception error)
            {

                MessageBox.Show("Возникла ошибка: " + error.Message, "Свяжитесь с Администратором");
            }
            
            
        }

        

        private void dataGridViewUsers_DoubleClick(object sender, EventArgs e)
        {
            if (dataGridViewUsers.CurrentCell.RowIndex != -1)
            {
                userId = Convert.ToInt32(dataGridViewUsers.CurrentRow.Cells["Id"].Value);
                user = db.Users.Where(x => x.Id == userId).FirstOrDefault();
                txtUsername.Text = user.Username;
                txtPassword.Text = user.Password;
                txtFirstName.Text = user.FirstName;
                txtLastName.Text = user.LastName;
                cbIsActive.Checked = user.IsActive;
                cbIsAdmin.Checked = user.isAdmininistrator;

            }
            btnSave.Text = "Обновить";
            
        }

        private void ClearData()
        {
            txtUsername.Text = txtPassword.Text = txtFirstName.Text = txtLastName.Text = string.Empty;

            cbIsAdmin.Checked = false;
            cbIsActive.Checked = false;
            
            btnSave.Text = "Сохранить";
            userId = 0;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ClearData();
            errorProvider1.Clear();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            var searchResult = from d in db.Users
                               where d.Username.Contains(txtSearch.Text) ^ d.LastName.Contains(txtSearch.Text) ^ d.FirstName.Contains(txtSearch.Text)
                               select new
                               { 
                                   Id = d.Id,
                                   Username = d.Username,
                                   Password = d.Password,
                                   FirstName = d.FirstName,
                                   LastName = d.LastName,
                                   IsActive = d.IsActive,
                                   IsAdministrator = d.isAdmininistrator
                                
                               };





            dataGridViewUsers.DataSource = searchResult.ToList();
            
            dataGridViewUsers.Columns[0].Visible = false;
            dataGridViewUsers.Columns[1].HeaderText = "Логин";
            dataGridViewUsers.Columns[2].HeaderText = "Имя";
            dataGridViewUsers.Columns[3].HeaderText = "Фамилия";
            dataGridViewUsers.Columns[4].HeaderText = "Активен?";
            dataGridViewUsers.Columns[5].HeaderText = "Администратор?";

        }

        private void btnClearSearch_Click(object sender, EventArgs e)
        {
            SetDataInGridView();
            txtSearch.ResetText();
        }

        private void iconHidePass_Click(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = true;
            
        }

        private void iconShowPass_Click(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = false;
            
        }

        private void txtFirstName_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(txtFirstName.Text))
            {
                errorProvider1.SetError(txtFirstName, "Имя не должно быть пустым");
                
            }
            else if (txtFirstName.Text.Length < 4)
            {
                errorProvider1.SetError(txtFirstName, "Слишком короткое имя");
                
                
            }
            else
            {
                errorProvider1.Clear();
                
            }
        }

        private void txtPassword_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(txtPassword.Text))
            {
                errorProvider1.SetError(txtPassword, "Пароль неможет быть пустым");
                
            }
            else if (txtPassword.Text.Length < 4)
            {
                errorProvider1.SetError(txtPassword, "Пароль должен содержать 6 символов");
                

            }
            else
            {
                errorProvider1.Clear();
                
            }
        }

        private void txtLastName_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(txtLastName.Text))
            {
                errorProvider1.SetError(txtLastName, "Фамилия не может быть пустым");
                
            }
            else if (txtLastName.Text.Length < 4)
            {
                errorProvider1.SetError(txtLastName, "Фамилия должна содержать больше чем 4");
                

            }
            else
            {
                errorProvider1.Clear();
                
            }
        }

        public void txtUsername_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(txtUsername.Text))
            {
                errorProvider1.SetError(txtUsername, "Не указано имя");
                btnSave.Enabled = false;
            }
            else if (txtUsername.Text.Length < 4)
            {
                errorProvider1.SetError(txtUsername, "Слишком короткое имя");
                btnSave.Enabled = false;
            }
            else
            {
                errorProvider1.SetError(txtUsername,"");
                //errorProvider1.Clear();
                btnSave.Enabled = true;
            }
        }

        private void btnExportToExcel_Click(object sender, EventArgs e)
        {
            try
            {
                //Creating DataTable
                DataTable dt = new DataTable();

                //Adding the Columns
                foreach (DataGridViewColumn column in dataGridViewUsers.Columns)
                {
                    dt.Columns.Add(column.HeaderText, column.ValueType);
                }

                //Adding the Rows
                foreach (DataGridViewRow row in dataGridViewUsers.Rows)
                {
                    dt.Rows.Add();
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        dt.Rows[dt.Rows.Count - 1][cell.ColumnIndex] = cell.Value.ToString();
                    }
                }

                //Exporting to Excel
                string folderPath = "C:\\Excel\\";
                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }
                using (XLWorkbook wb = new XLWorkbook())
                {
                    wb.Worksheets.Add(dt, "Users");
                    wb.SaveAs(folderPath + "Users.xlsx");
                    MessageBox.Show("Файл успешно сохранен: C:\\Excel");

                }
            }
            catch (Exception error)
            {

                MessageBox.Show(error.Message);
            }
            
            
            
        }

        
    }
}
