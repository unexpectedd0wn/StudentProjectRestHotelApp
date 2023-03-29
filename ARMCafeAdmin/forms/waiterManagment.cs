using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ARMCafeAdmin.DBModels;

namespace ARMCafeAdmin
{
    public partial class waiterManagment : Form
    {

        DBEntity db = new DBEntity();
        Waiter waiter = new Waiter();
        WatersSchedule waterSchedule = new WatersSchedule();
        int waiterId = 0;
        int scheduleId = 0;
        public waiterManagment()
        {
            InitializeComponent();
            
           
            //btnSave.Text = "Сохранить";
            //btnCancel.Enabled = false;
        }

        

        private void waiterManagmentForm_Load(object sender, EventArgs e)
        {
            SetDataInGridView();
            SetDataInGridViewSchedule();
            GetListOfWaiters();
        }


        public void SetDataInGridView()
        {
            if (global.IsAdministrator == true)
            {
                var resultAdmin = from b in db.Waiters
                                  join v in db.Users on b.ChangedBy equals v.Id
                                  orderby b.LastName descending

                             select new
                             {
                                 b.Id,
                                 b.FirstName,
                                 b.LastName,
                                 b.IsActive,
                                 v.Username,
                                 b.ChangedDate
                             };

                dataGridViewWaters.DataSource = resultAdmin.ToList();
                SetDataGridStyleColumns();
            }
            else
            {
                var resultUser = from b in db.Waiters
                             orderby b.LastName descending

                             select new
                             {
                                 b.Id,
                                 b.FirstName,
                                 b.LastName,
                                 b.IsActive,
                             };

                dataGridViewWaters.DataSource = resultUser.ToList();
                SetDataGridStyleColumns();
            }
            

        }

        public void SetDataGridStyleColumns()
        {
            if (global.IsAdministrator == true)
            {
                
                dataGridViewWaters.EnableHeadersVisualStyles = false;
                dataGridViewWaters.Columns[0].Visible = false;
                dataGridViewWaters.Columns[1].HeaderText = "Имя";
                dataGridViewWaters.Columns[2].HeaderText = "Фамилия";
                dataGridViewWaters.Columns[3].HeaderText = "Активен";
                dataGridViewWaters.Columns[4].HeaderText = "Изменено";
                dataGridViewWaters.Columns[5].HeaderText = "Дата изменения";
            }
            else
            {
                
                dataGridViewWaters.EnableHeadersVisualStyles = false;
                dataGridViewWaters.Columns[0].Visible = false;
                dataGridViewWaters.Columns[1].HeaderText = "Имя";
                dataGridViewWaters.Columns[2].HeaderText = "Фамилия";
                dataGridViewWaters.Columns[3].HeaderText = "Активен";
            }
        
        }

        public void SetDataInGridViewSchedule()
        {
            if (global.IsAdministrator == true)
            {
                var resultAdmin = from b in db.WatersSchedules
                                  join c in db.Waiters on b.WaterId equals c.Id
                                  join v in db.Users on b.ChangedBy equals v.Id
                                  orderby b.WorkDate descending

                             select new
                             {
                                 b.Id,
                                 b.WorkDate,
                                 c.LastName,
                                 v.Username,
                                 b.ChangedDate
                             };

                dataGridViewSchedule.DataSource = resultAdmin.ToList();
                SetDataGridStyleSchedule();
            }
            else
            {
                var resultUser = from b in db.WatersSchedules
                                  join c in db.Waiters on b.WaterId equals c.Id
                                  orderby b.WorkDate descending

                                  select new
                                  {
                                      b.Id,
                                      b.WorkDate,
                                      c.LastName
                                  };

                dataGridViewSchedule.DataSource = resultUser.ToList();
                SetDataGridStyleSchedule();
            }
            

        }

        public void SetDataGridStyleSchedule()
        {
            if (global.IsAdministrator == true )
            {
                dataGridViewSchedule.EnableHeadersVisualStyles = false;
                dataGridViewSchedule.Columns[0].Visible = false;
                dataGridViewSchedule.Columns[1].HeaderText = "Дата";
                dataGridViewSchedule.Columns[2].HeaderText = "Фамилия";
                dataGridViewSchedule.Columns[3].HeaderText = "Изменено";
                dataGridViewSchedule.Columns[4].HeaderText = "Дата изменения";
            }
            else
            {
                dataGridViewSchedule.EnableHeadersVisualStyles = false;
                dataGridViewSchedule.Columns[0].Visible = false;
                dataGridViewSchedule.Columns[1].HeaderText = "Дата";
                dataGridViewSchedule.Columns[2].HeaderText = "Фамилия";
            }
        }

        public void GetListOfWaiters()
        {
            try
            {
                var WaitersToAdd = from a in db.Waiters
                                  where a.IsActive == true
                                  select new
                                  {
                                      a.Id,
                                      a.LastName
                                  };

                cmbWaters.DataSource = WaitersToAdd.ToList();
                cmbWaters.ValueMember = "Id";
                cmbWaters.DisplayMember = "LastName";

                
            }
            catch (Exception error)
            {

                MessageBox.Show("Возникла ошибка: " + error.Message);
            }
        }

        private void dataGridViewWaters_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridViewWaters.CurrentCell.RowIndex != -1)
            {
                try
                {
                    waiterId = Convert.ToInt32(dataGridViewWaters.CurrentRow.Cells["Id"].Value);
                    waiter = db.Waiters.Where(x => x.Id == waiterId).FirstOrDefault();
                    txtFirstName.Text = waiter.FirstName;
                    txtLastName.Text = waiter.LastName;
                    txtPhoneNumber.Text = waiter.PhoneNumber;
                    cbIsActive.Checked = waiter.IsActive;
                    
                    btnSave.Text = "Обновить";
                    
                }
                catch (Exception error)
                {

                    MessageBox.Show("Возникла ошибка: " + error.Message);
                }
            }
        }

        private void dataGridViewSchedule_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridViewSchedule.CurrentCell.RowIndex != -1)
            {
                try
                {
                    scheduleId = Convert.ToInt32(dataGridViewSchedule.CurrentRow.Cells["Id"].Value);
                    waterSchedule = db.WatersSchedules.Where(x => x.Id == scheduleId).FirstOrDefault();

                    cmbWaters.SelectedValue = waterSchedule.WaterId;
                    dtWorkDay.Value = waterSchedule.WorkDate;

                    btnSaveSchedule.Text = "Обновить";
                    
                }
                catch (Exception error)
                {

                    MessageBox.Show("Возникла ошибка: " + error.Message);
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                waiter.FirstName = txtFirstName.Text;
                waiter.LastName = txtLastName.Text;
                waiter.PhoneNumber = txtPhoneNumber.Text;
                waiter.IsActive = cbIsActive.Checked;

                if (waiterId > 0)
                {
                    waiter.ChangedBy = global.userId;
                    waiter.ChangedDate = System.DateTime.Now;
                    db.Entry(waiter).State = System.Data.Entity.EntityState.Modified;
                }
                else
                {
                    waiter.ChangedBy = global.userId;
                    waiter.ChangedDate = System.DateTime.Now;
                    db.Waiters.Add(waiter);
                }

                db.SaveChanges();
                ClearData();
                SetDataInGridView();
                GetListOfWaiters();
                SetDataInGridViewSchedule();
                MessageBox.Show("Успешно обновлено");
            }
            catch (Exception error)
            {

                MessageBox.Show("Возникла ошибка: " + error.Message);
            }


            
        }

        //private void btnDelete_Click(object sender, EventArgs e)
        //{
        //    if (MessageBox.Show("Вы уверены что хотите удалить официанта ?", "Удалить ?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
        //    {
        //        db.Waiters.Remove(waiter);
        //        db.SaveChanges();
        //        ClearData();
        //        SetDataInGridView();

        //        MessageBox.Show("Официант успешно удален");
        //    }
        //}

        public void ClearData()
        {
            try
            {
                txtFirstName.Text = txtLastName.Text = txtPhoneNumber.Text = string.Empty;
                cbIsActive.Checked = false;
                btnSave.Text = "Сохранить";
                waiterId = 0;
            }
            catch (Exception error)
            {

                MessageBox.Show("Возникла ошибка: " + error.Message);
            }
        }

        private void btnSaveSchedule_Click(object sender, EventArgs e)
        {
            try
            {
                
                
                waterSchedule.WaterId = (int)cmbWaters.SelectedValue;
                waterSchedule.WorkDate = dtWorkDay.Value;
                

                if (scheduleId > 0)
                {
                    waterSchedule.ChangedBy = global.userId;
                    waterSchedule.ChangedDate = System.DateTime.Now;
                    db.Entry(waterSchedule).State = System.Data.Entity.EntityState.Modified;
                }
                else
                {
                    waterSchedule.ChangedBy = global.userId;
                    waterSchedule.ChangedDate = System.DateTime.Now;
                    db.WatersSchedules.Add(waterSchedule);
                }

                db.SaveChanges();
                SetDataInGridViewSchedule();
                ClearData();

                MessageBox.Show("Успешно обновлено");
            }
            catch (Exception error)
            {

                MessageBox.Show("Возникла ошибка: " + error.Message);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ClearData();
        }

        private void btnDeleteSchedule_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Вы уверены что хотите удалить смену ?", "Удалить ?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                db.WatersSchedules.Remove(waterSchedule);
                db.SaveChanges();
                ClearData();
                SetDataInGridView();
                SetDataInGridViewSchedule();

                MessageBox.Show("Смена успешно удалена");
            }
        }

        private void btnExportToExcel_Click(object sender, EventArgs e)
        {
            try
            {
                //Creating DataTable
                DataTable dt = new DataTable();

                //Adding the Columns
                foreach (DataGridViewColumn column in dataGridViewSchedule.Columns)
                {
                    dt.Columns.Add(column.HeaderText, column.ValueType);
                }

                //Adding the Rows
                foreach (DataGridViewRow row in dataGridViewSchedule.Rows)
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
                    wb.Worksheets.Add(dt, "Официанты");
                    wb.SaveAs(folderPath + "РасписаниеОфициантов.xlsx");
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
