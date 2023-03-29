using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using ClosedXML.Excel;
using ARMCafeAdmin.DBModels;

namespace ARMCafeAdmin
{
    public partial class bookTable : Form
    {

        DBEntity db = new DBEntity();
        BookingTable bTable = new BookingTable();
        int bookingTableId = 0;

        public bookTable()
        {
            InitializeComponent();
            btnSave.Text = "Сохранить";
            btnCancel.Enabled = false;
            

        }

        private void bookTable_Load(object sender, EventArgs e)
        {
            CheckDeleteBtn();
            SetDataInGridView();
            GetListOfTables();
            GetListOfStatus();
        }

        public void CheckDeleteBtn()
        {
            if (global.IsAdministrator == true)
            {
                btnDelete.Show();
            }
            else
            {
                btnDelete.Hide();
            }
        }


        public void GetListOfTables()
        {
            var result = from x in db.RestTables
                         where x.IsActive == true
                         select new 
                         { 
                            x.Id,
                            x.TableNumber,
                            
                         };

            
            cmBTables.DataSource = result.ToList();
            cmBTables.ValueMember = "Id";
            cmBTables.DisplayMember = "Name";
        }

        public void GetListOfAllTables()
        {
            var result = from x in db.RestTables
                         select new
                         {
                             x.Id,
                             x.TableNumber,
                             
                         };


            cmBTables.DataSource = result.ToList();
            cmBTables.ValueMember = "Id";
            cmBTables.DisplayMember = "Name";
        }

        public void GetListOfStatus()
        {
            List<BookingTableStatu> status = db.BookingTableStatus.ToList();
            cmBStatus.DataSource = status;
            cmBStatus.ValueMember = "Id";
            cmBStatus.DisplayMember = "Name";
        }



        private void SetDataInGridView()
        {

            try
            {
                if (global.IsAdministrator == true)
                {
                   var resultAdmin = from b in db.BookingTables
                                    join t in db.BookingTableStatus on b.StatusId equals t.Id
                                    join f in db.Users on b.ChangedBy equals f.Id
                                    join h in db.RestTables on b.Table equals h.Id
                                    join k in db.TablePositions on h.PositionId equals k.Id
                                    orderby b.Date descending, b.LastName descending
                                    select new
                                      {
                                          Id = b.Id,
                                          Date = b.Date,
                                          Time = b.BookingTime,
                                          Table = b.Table,
                                          Position = k.Name,
                                          NumberOfQuests = b.NumberOfQuests,
                                          FirstName = b.FirstName,
                                          LastName = b.LastName,
                                          PhoneNumber = b.PhoneNumber,
                                          Status = t.Name,
                                          f.Username,
                                          b.ChangedDate
                                      };

                    dataGridViewBookingTable.DataSource = resultAdmin.ToList();
                    SetDataGridStyle();
                }
                else
                {
                    var result1 = from b in db.BookingTables
                                 orderby b.Date descending
                                 join t in db.BookingTableStatus on b.StatusId equals t.Id
                                  join h in db.RestTables on b.Table equals h.Id
                                  join k in db.TablePositions on h.PositionId equals k.Id
                                  orderby b.Date descending, b.LastName descending
                                 select new
                                 {
                                     Id = b.Id,
                                     Date = b.Date,
                                     Time = b.BookingTime,
                                     Table = b.Table,
                                     Position = k.Name,
                                     NumberOfQuests = b.NumberOfQuests,
                                     FirstName = b.FirstName,
                                     LastName = b.LastName,
                                     PhoneNumber = b.PhoneNumber,
                                     Status = t.Name
                                     
                                 };

                    dataGridViewBookingTable.DataSource = result1.ToList();
                    SetDataGridStyle();
                }
            }
            catch (Exception error)
            {

                MessageBox.Show("Возникла ошибка:" + error.Message);
            }
            
            
            

        }


        

        private void dataGridViewBookingTable_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dataGridViewBookingTable.CurrentCell.RowIndex != -1)
                {
                    bookingTableId = Convert.ToInt32(dataGridViewBookingTable.CurrentRow.Cells["Id"].Value);
                    bTable = db.BookingTables.Where(x => x.Id == bookingTableId).FirstOrDefault();

                    txtxLastName.Text = bTable.LastName;
                    txtFirstName.Text = bTable.FirstName;
                    txtNumberOfQuests.Text = bTable.NumberOfQuests.ToString();
                    txtPhoneNumber.Text = bTable.PhoneNumber;
                    cmBStatus.SelectedValue = bTable.StatusId;
                    int status = bTable.StatusId;
                    if (status == 2)
                    {
                        GetListOfAllTables();
                        cmBTables.SelectedValue = bTable.Table;
                    }
                    else
                    {
                        GetListOfTables();
                        cmBTables.SelectedValue = bTable.Table;
                    }
                    
                    dtDate.Value = bTable.Date;
                    cmbTime.SelectedItem = bTable.BookingTime;

                    
                    if (status == 2)
                    {
                        if (global.IsAdministrator == true)
                        {
                            txtxLastName.Enabled = true;
                            txtFirstName.Enabled = true;
                            txtNumberOfQuests.Enabled = true;
                            txtPhoneNumber.Enabled = true;
                            cmBTables.Enabled = true;
                            dtDate.Enabled = true;
                            cmBStatus.Enabled = true;
                            cmbTime.Enabled = true;
                            btnSave.Text = "Обновить";
                            btnSave.Enabled = true;
                            btnCancel.Enabled = true;
                        }
                        else
                        {
                            txtxLastName.Enabled = false;
                            txtFirstName.Enabled = false;
                            txtNumberOfQuests.Enabled = false;
                            txtPhoneNumber.Enabled = false;
                            cmBTables.Enabled = false;
                            dtDate.Enabled = false;
                            cmBStatus.Enabled = false;
                            cmbTime.Enabled = false;

                            btnSave.Enabled = false;
                            btnCancel.Enabled = false;
                        }
                        
                    }
                    else
                    {
                        txtxLastName.Enabled = true;
                        txtFirstName.Enabled = true;
                        txtNumberOfQuests.Enabled = true;
                        txtPhoneNumber.Enabled = true;
                        cmBTables.Enabled = true;
                        dtDate.Enabled = true;
                        cmBStatus.Enabled = true;
                        cmbTime.Enabled = true;
                        btnSave.Text = "Обновить";
                        btnSave.Enabled = true;
                        btnCancel.Enabled = true;
                    }

                }
                btnSave.Text = "Обновить";
                btnCancel.Enabled = true;
            }
            catch (Exception error)
            {

                MessageBox.Show("Возникла ошибка:" + error.Message);
            }
        }

        //public void MessageToCloseBookinTable()
        //{
        //    if (global.IsAdministrator == true)
        //    {
        //        string message = "Вы уверены что хотите закрыть бронирование ?";
        //    }
        //    else
        //    {
        //        string message = "Вы уверены что хотите закрыть бронирование ? Закрытые бронирования не могут быть отредактированы";
        //    }
        //}

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                bTable.LastName = txtxLastName.Text.Trim();
                bTable.FirstName = txtFirstName.Text.Trim();
                bTable.NumberOfQuests = txtNumberOfQuests.Text;
                bTable.PhoneNumber = txtPhoneNumber.Text;
                bTable.Table = (int)cmBTables.SelectedValue;
                bTable.StatusId = ((BookingTableStatu)cmBStatus.SelectedItem).Id;
                bTable.Date = dtDate.Value;
                bTable.BookingTime = cmbTime.SelectedItem.ToString();


                int status = ((BookingTableStatu)cmBStatus.SelectedItem).Id;
                if (status == 2)
                {
                    if (MessageBox.Show("Вы уверены что хотите закрыть бронирование ? Закрытые бронирования не могут быть отредактированы", "Закрыть ?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        try
                        {
                            if (bookingTableId > 0)
                            {
                                bTable.ChangedBy = global.userId;
                                bTable.ChangedDate = System.DateTime.Now;
                                db.Entry(bTable).State = System.Data.Entity.EntityState.Modified;
                            }
                            else
                            {
                                bTable.ChangedBy = global.userId;
                                bTable.ChangedDate = System.DateTime.Now;
                                db.BookingTables.Add(bTable);
                            }

                            db.SaveChanges();
                            ClearData();
                            SetDataInGridView();
                            MessageBox.Show("Успешно обновлено");
                        }
                        catch (Exception error)
                        {

                            MessageBox.Show("Возникла ошибка" + error.Message);
                        }
                    }
                    
                }
                else
                {
                    try
                    {
                        if (bookingTableId > 0)
                        {
                            bTable.ChangedBy = global.userId;
                            bTable.ChangedDate = System.DateTime.Now;
                            db.Entry(bTable).State = System.Data.Entity.EntityState.Modified;
                        }
                        else
                        {
                            bTable.ChangedBy = global.userId;
                            bTable.ChangedDate = System.DateTime.Now;
                            db.BookingTables.Add(bTable);
                        }

                        db.SaveChanges();
                        ClearData();
                        SetDataInGridView();
                        MessageBox.Show("Успешно обновлено");
                    }
                    catch (Exception error)
                    {
                    }
                }
            }
            catch (Exception error)
            {

                MessageBox.Show("При сохранении, возникла ошибка:" + error.Message);
            }
        }

        public void ClearData()
        {
            txtNumberOfQuests.Text = txtPhoneNumber.Text = txtxLastName.Text = txtFirstName.Text = string.Empty;
            cmBTables.SelectedIndex = -1;
            cmbTime.SelectedIndex = -1;
            dtDate.ResetText();
            cmBStatus.SelectedIndex = -1;
            btnSave.Text = "Сохранить";
            bookingTableId = 0;
            
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ClearData();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                if (global.IsAdministrator == true)
                {
                    var searchResultAdmin = from b in db.BookingTables
                                       where b.LastName.Contains(txtSearch.Text) ^ b.FirstName.Contains(txtSearch.Text) ^ b.PhoneNumber.Contains(txtSearch.Text)
                                       join t in db.BookingTableStatus on b.StatusId equals t.Id
                                       join f in db.Users on b.ChangedBy equals f.Id
                                       join h in db.RestTables on b.Table equals h.Id
                                       join k in db.TablePositions on h.PositionId equals k.Id
                                            select new
                                       {

                                                Id = b.Id,
                                                Date = b.Date,
                                                Time = b.BookingTime,
                                                Table = b.Table,
                                                Position = k.Name,
                                                NumberOfQuests = b.NumberOfQuests,
                                                FirstName = b.FirstName,
                                                LastName = b.LastName,
                                                PhoneNumber = b.PhoneNumber,
                                                Status = t.Name,
                                                f.Username,
                                                b.ChangedDate
                                            };

                    dataGridViewBookingTable.DataSource = searchResultAdmin.ToList();
                    SetDataGridStyle();
                }
                else
                {
                    var searchResultUser = from b in db.BookingTables
                                            where b.LastName.Contains(txtSearch.Text) ^ b.FirstName.Contains(txtSearch.Text) ^ b.PhoneNumber.Contains(txtSearch.Text)
                                            join t in db.BookingTableStatus on b.StatusId equals t.Id
                                           join h in db.RestTables on b.Table equals h.Id
                                           join k in db.TablePositions on h.PositionId equals k.Id
                                           orderby b.Date descending, b.LastName descending
                                           select new
                                            {
                                               Id = b.Id,
                                               Date = b.Date,
                                               Time = b.BookingTime,
                                               Table = b.Table,
                                               Position = k.Name,
                                               NumberOfQuests = b.NumberOfQuests,
                                               FirstName = b.FirstName,
                                               LastName = b.LastName,
                                               PhoneNumber = b.PhoneNumber,
                                               Status = t.Name
                                           };

                    dataGridViewBookingTable.DataSource = searchResultUser.ToList();
                    SetDataGridStyle();
                }
            }
            catch (Exception error)
            {

                MessageBox.Show("Возникла ошибка:" + error.Message);
            }
        }

        private void btnSearchClear_Click(object sender, EventArgs e)
        {
            SetDataInGridView();
            txtSearch.ResetText();
        }

        private void btnTodayBook_Click(object sender, EventArgs e)
        {
            try
            {
                if (global.IsAdministrator == true)
                {
                    var TodayBookingTableForAdmin = from b in db.BookingTables
                                             where b.Date == DateTime.Today
                                             join t in db.BookingTableStatus on b.StatusId equals t.Id
                                             join f in db.Users on b.ChangedBy equals f.Id
                                                    join h in db.RestTables on b.Table equals h.Id
                                                    join k in db.TablePositions on h.PositionId equals k.Id
                                                    orderby b.Date descending, b.LastName descending
                                             select new
                                             {
                                                 Id = b.Id,
                                                 Date = b.Date,
                                                 Time = b.BookingTime,
                                                 Table = b.Table,
                                                 Position = k.Name,
                                                 NumberOfQuests = b.NumberOfQuests,
                                                 FirstName = b.FirstName,
                                                 LastName = b.LastName,
                                                 PhoneNumber = b.PhoneNumber,
                                                 Status = t.Name,
                                                 f.Username,
                                                 b.ChangedDate

                                             };

                    dataGridViewBookingTable.DataSource = TodayBookingTableForAdmin.ToList();
                    SetDataGridStyle();
                }
                else
                {
                    var TodayBookingTableforUser = from b in db.BookingTables
                                             where b.Date == DateTime.Today
                                             join t in db.BookingTableStatus on b.StatusId equals t.Id
                                                   join h in db.RestTables on b.Table equals h.Id
                                                   join k in db.TablePositions on h.PositionId equals k.Id
                                                   orderby b.Date descending, b.LastName descending
                                                   select new
                                             {

                                                       Id = b.Id,
                                                       Date = b.Date,
                                                       Time = b.BookingTime,
                                                       Table = b.Table,
                                                       Position = k.Name,
                                                       NumberOfQuests = b.NumberOfQuests,
                                                       FirstName = b.FirstName,
                                                       LastName = b.LastName,
                                                       PhoneNumber = b.PhoneNumber,
                                                       Status = t.Name
                                                   };

                    dataGridViewBookingTable.DataSource = TodayBookingTableforUser.ToList();
                    SetDataGridStyle();
                }
            }
            catch (Exception error)
            {

                MessageBox.Show("Возникла ошибка:" + error.Message);
            }
            
            
            
            
        }

        public void SetDataGridStyle()
        {
            if (global.IsAdministrator == true)
            {
                dataGridViewBookingTable.EnableHeadersVisualStyles = false;
                dataGridViewBookingTable.Columns[0].HeaderText = "#";
                dataGridViewBookingTable.Columns[1].HeaderText = "Дата";
                dataGridViewBookingTable.Columns[2].HeaderText = "Время";
                dataGridViewBookingTable.Columns[3].HeaderText = "Номер стола";
                dataGridViewBookingTable.Columns[4].HeaderText = "Расположение";
                dataGridViewBookingTable.Columns[5].HeaderText = "Кол-во гостей";
                dataGridViewBookingTable.Columns[6].HeaderText = "Имя";
                dataGridViewBookingTable.Columns[7].HeaderText = "Фамилия";
                dataGridViewBookingTable.Columns[8].HeaderText = "Телефон";
                dataGridViewBookingTable.Columns[9].HeaderText = "Статус";
                dataGridViewBookingTable.Columns[10].HeaderText = "Изменено";
                dataGridViewBookingTable.Columns[11].HeaderText = "Дата изменения";
            }
            else
            {
                dataGridViewBookingTable.EnableHeadersVisualStyles = false;
                dataGridViewBookingTable.Columns[0].HeaderText = "#";
                dataGridViewBookingTable.Columns[1].HeaderText = "Дата";
                dataGridViewBookingTable.Columns[2].HeaderText = "Время";
                dataGridViewBookingTable.Columns[3].HeaderText = "Номер стола";
                dataGridViewBookingTable.Columns[4].HeaderText = "Расположение";
                dataGridViewBookingTable.Columns[5].HeaderText = "Кол-во гостей";
                dataGridViewBookingTable.Columns[6].HeaderText = "Имя";
                dataGridViewBookingTable.Columns[7].HeaderText = "Фамилия";
                dataGridViewBookingTable.Columns[8].HeaderText = "Телефон";
                dataGridViewBookingTable.Columns[9].HeaderText = "Статус";
            }
            
            
        }


        

        private void btnExportToExcel_Click(object sender, EventArgs e)
        {
            try
            {
                //Creating DataTable
                DataTable dt = new DataTable();

                //Adding the Columns
                foreach (DataGridViewColumn column in dataGridViewBookingTable.Columns)
                {
                    dt.Columns.Add(column.HeaderText, column.ValueType);
                }

                //Adding the Rows
                foreach (DataGridViewRow row in dataGridViewBookingTable.Rows)
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
                    wb.Worksheets.Add(dt, "Бронирования");
                    wb.SaveAs(folderPath + "BookingTable.xlsx");
                    MessageBox.Show("Файл успешно сохранен: C:\\Excel");

                }
            }
            catch (Exception error)
            {

                MessageBox.Show(error.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Вы уверены что хотите удалить Бронирование ?", "Удалить ?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    db.BookingTables.Remove(bTable);
                    db.SaveChanges();
                    ClearData();
                    SetDataInGridView();
                    MessageBox.Show("Бронирование успешно удалено");
                }
                catch (Exception error)
                {

                    MessageBox.Show("Возникла ошибка" + error.Message);
                }



            }
        }
    }
}
