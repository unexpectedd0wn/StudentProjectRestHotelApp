//using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using ClosedXML.Excel;

namespace ARMCafeAdmin
{
    public partial class banquetManagment : Form
    {
        
        DBEntity db = new DBEntity();
        Banquet banquet = new Banquet();
        BanquetDish banqDish = new BanquetDish();
        int banqId = 0;
        int banqDishId = 0;
        
        
        public banquetManagment()
        {
            InitializeComponent();
            
        }

        private void banquetManagment_Load(object sender, EventArgs e)
        {
            SetDataInGridViewBanquets();
            CheckDeleteBtn();
            GetListOfPrePaymentStatus();
            GetListOfBanquetStatus();
            SetEnableFalseForDishArea();
            
        }
        /// <summary>
        /// Banquets Part
        /// </summary>
        public void SetDataInGridViewBanquets()
        {
            if (global.IsAdministrator == true)
            {
                try
                {
                    var resultAdmin = from b in db.Banquets
                                 join s in db.BanquetStatus on b.StatusId equals s.Id
                                 join p in db.PrepaymentStatuses on b.PrepaymentId equals p.Id
                                 join u in db.Users on b.ChangedBy equals u.Id
                                 orderby b.Date, s.Name descending

                                 select new
                                 {
                                     b.Id,
                                     b.Date,
                                     b.Time,
                                     b.CustomerFirstName,
                                     b.CustomerLastName,
                                     Status = s.Name,
                                     Payment = p.Name,
                                     u.Username,
                                     b.ChangeDate

                                 };


                    dataGridViewBanquet.DataSource = resultAdmin.ToList();
                    SetDataGridColumnsBanquets();
                }
                catch (Exception error)
                {

                    MessageBox.Show("Возникла ошибка при получении списка банкетов" + error.Message);
                }
            }
            else
            {
                try
                {
                    var resultUser = from b in db.Banquets
                                 join s in db.BanquetStatus on b.StatusId equals s.Id
                                 join p in db.PrepaymentStatuses on b.PrepaymentId equals p.Id
                                 orderby b.Date, s.Name descending

                                 select new
                                 {
                                     b.Id,
                                     b.Date,
                                     b.Time,
                                     b.CustomerFirstName,
                                     b.CustomerLastName,
                                     b.CustomerPhoneNumber,
                                     b.NumberOfQuests,
                                     b.Comment,
                                     Status = s.Name,
                                     Payment = p.Name,
                                };


                    dataGridViewBanquet.DataSource = resultUser.ToList();
                    SetDataGridColumnsBanquets();
                }
                catch (Exception error)
                {

                    MessageBox.Show("Возникла ошибка при получении списка банкетов" + error.Message);
                }
            }
        }
        private void dataGridViewBanquet_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridViewBanquet.CurrentCell.RowIndex != -1)
            {
                
                
                    banqId = Convert.ToInt32(dataGridViewBanquet.CurrentRow.Cells["Id"].Value);
                    banquet = db.Banquets.Where(x => x.Id == banqId).FirstOrDefault();
                    txtFirstName.Text = banquet.CustomerFirstName;
                    txtLastName.Text = banquet.CustomerLastName;
                    txtDate.Value = banquet.Date;
                    cmbTime.SelectedItem = banquet.Time;
                    txtComment.Text = banquet.Comment;
                    cmbBanquetStatus.SelectedValue = banquet.StatusId;
                    cmbPaymentStatus.SelectedValue = (int)banquet.PrepaymentId;
                    txtNumberOfQuests.Text = banquet.NumberOfQuests;
                    PhoneNumber.Text = banquet.CustomerPhoneNumber;
                    txtService.Text = banquet.Service.ToString();
                    txtDiscount.Text = banquet.Discount.ToString();
                    GetBanquetDish();
                    CountTotalValue();
                    GetListofDishestoAdd();
                    SetPaneltoDefaultStyle1();
                    btnExportDish.Enabled = true;

                    int status = banquet.StatusId;

                    if (status == 2)
                    {
                        if (global.IsAdministrator == true)
                        {
                        txtFirstName.Enabled = true;
                        txtLastName.Enabled = true;
                        txtDate.Enabled = true;
                        cmbTime.Enabled = true;
                        txtComment.Enabled = true;
                        cmbBanquetStatus.Enabled = true;
                        cmbPaymentStatus.Enabled = true;
                        txtNumberOfQuests.Enabled = true;
                        PhoneNumber.Enabled = true;
                        txtService.Enabled = true;
                        txtDiscount.Enabled = true;
                        cmbDishestoAdd.Enabled = true;
                        Qty.Enabled = true;
                        dataGridViewBanquetDish.Enabled = true;
                        btnSave.Enabled = true;
                        btnCancel.Enabled = true;
                        btnAddDishtoBanquet.Enabled = true;
                        btnDishDelete.Enabled = true;
                        btnDishCancel.Enabled = true;


                    }
                        else
                        {
                        txtFirstName.Enabled = false;
                        txtLastName.Enabled = false;
                        txtDate.Enabled = false;
                        cmbTime.Enabled = false;
                        txtComment.Enabled = false;
                        cmbBanquetStatus.Enabled = false;
                        cmbPaymentStatus.Enabled = false;
                        txtNumberOfQuests.Enabled = false;
                        PhoneNumber.Enabled = false;
                        txtService.Enabled = false;
                        txtDiscount.Enabled = false;
                        cmbDishestoAdd.Enabled = false;
                        Qty.Enabled = false;
                        dataGridViewBanquetDish.Enabled = false;
                        btnSave.Enabled = false;
                        btnCancel.Enabled = false;
                        btnAddDishtoBanquet.Enabled = false;
                        btnDishDelete.Enabled = false;
                        btnDishCancel.Enabled = false;
                    }
                    }
                    else
                    {
                    txtFirstName.Enabled = true;
                    txtLastName.Enabled = true;
                    txtDate.Enabled = true;
                    cmbTime.Enabled = true;
                    txtComment.Enabled = true;
                    cmbBanquetStatus.Enabled = true;
                    cmbPaymentStatus.Enabled = true;
                    txtNumberOfQuests.Enabled = true;
                    PhoneNumber.Enabled = true;
                    txtService.Enabled = true;
                    txtDiscount.Enabled = true;
                    cmbDishestoAdd.Enabled = true;
                    Qty.Enabled = true;
                    dataGridViewBanquetDish.Enabled = true;
                    btnSave.Enabled = true;
                    btnCancel.Enabled = true;
                    btnAddDishtoBanquet.Enabled = true;
                    btnDishDelete.Enabled = true;
                    btnDishCancel.Enabled = true;
                }




            }

            btnSave.Text = "Обновить";
            btnCancel.Enabled = true;


        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                
                    banquet.CustomerFirstName = txtFirstName.Text.Trim();
                    banquet.CustomerLastName = txtLastName.Text.Trim();
                    banquet.Date = txtDate.Value;
                    banquet.Comment = txtComment.Text.Trim();
                    banquet.PrepaymentId = (int)cmbPaymentStatus.SelectedValue;
                    banquet.StatusId = ((BanquetStatu)cmbBanquetStatus.SelectedItem).Id;
                    banquet.NumberOfQuests = txtNumberOfQuests.Text;
                    banquet.CustomerPhoneNumber = PhoneNumber.Text;
                    banquet.Service = Convert.ToInt32(txtService.Text);
                    banquet.Time = cmbTime.SelectedItem.ToString();
                    banquet.Discount = Convert.ToDecimal(txtDiscount.Text);

                    if (banqId > 0)
                    {
                        banquet.ChangedBy = global.userId;
                        banquet.ChangeDate = System.DateTime.Now;
                        db.Entry(banquet).State = System.Data.Entity.EntityState.Modified;
                    }
                    else
                    {
                        banquet.ChangedBy = global.userId;
                        banquet.ChangeDate = System.DateTime.Now;
                        db.Banquets.Add(banquet);
                    }

                    db.SaveChanges();
                    ClearData();
                    SetDataInGridViewBanquets();
                    dataGridViewBanquetDish.Refresh();
                    MessageBox.Show("Успешно обновлено");
                
            }
            catch (Exception error)
            {

                MessageBox.Show("При сохранении, возникла ошибка:" + error.Message);
            }


        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            ClearData();
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Вы уверены что хотите удалить бронирование банкета?", "Удалить ?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {


                    db.Banquets.Remove(banquet);
                    db.SaveChanges();
                    SetDataInGridViewBanquets();
                    ClearData();
                    MessageBox.Show("Банкет успешно удален");
                }
                catch (Exception error)
                {

                    MessageBox.Show("При удалении, возникла ошибка:" + error.Message);
                }
            }
        }



        public void GetBanquetDish()
        {
            if (global.IsAdministrator == true)
            {
                try
                {
                    var resultAdmin = from bd in db.BanquetDishes
                                      join ds in db.Dishes on bd.DishId equals ds.Id
                                      join u in db.Users on bd.ChangedBy equals u.Id
                                      where bd.BanquetId == banqId

                                      select new
                                      {
                                          Id = bd.Id,
                                          Name = ds.Name,
                                          Qty = bd.Qty,
                                          Price = ds.Price,
                                          Weight = ds.Weight,
                                          Total = bd.Qty * ds.Price,
                                          u.Username,
                                          bd.ChangedDate

                                      };

                    dataGridViewBanquetDish.DataSource = resultAdmin.ToList();
                    SetDataGridColumnsBanquetDishes();
                    
                }
                catch (Exception error)
                {

                    MessageBox.Show("Возникла ошибка при получении списка банкетов" + error.Message);
                }
            }
            else
            {
                try
                {
                    var resultUser = from bd in db.BanquetDishes
                                     join ds in db.Dishes on bd.DishId equals ds.Id

                                     where bd.BanquetId == banqId

                                     select new
                                     {
                                         Id = bd.Id,
                                         Name = ds.Name,
                                         Qty = bd.Qty,
                                         Price = ds.Price,
                                         Weight = ds.Weight,
                                         Total = bd.Qty * ds.Price,
                                     };

                    dataGridViewBanquetDish.DataSource = resultUser.ToList();
                    SetDataGridColumnsBanquetDishes();
                    
                }
                catch (Exception error)
                {

                    MessageBox.Show("Возникла ошибка при получении списка банкетов" + error.Message);
                }
            }
        }

        private void dataGridViewBanquetDish_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridViewBanquetDish.CurrentCell.RowIndex != -1)
            {
                try
                {
                    banqDishId = Convert.ToInt32(dataGridViewBanquetDish.CurrentRow.Cells["Id"].Value);
                    banqDish = db.BanquetDishes.Where(x => x.Id == banqDishId).FirstOrDefault();
                    Qty.Value = Convert.ToInt32(banqDish.Qty);
                    cmbDishestoAdd.SelectedValue = banqDish.DishId;
                    SetPaneltoDefaultStyle2();
                    btnAddDishtoBanquet.Text = "Обновить";

                }
                catch (Exception error)
                {
                    MessageBox.Show("При получении деталей блюда, возникла ошибка:" + error.Message);
                    
                }
            }

        }
        private void btnDishDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Вы уверены что хотите удалить блюдо ?", "Удалить ?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    db.BanquetDishes.Remove(banqDish);
                    db.SaveChanges();
                    MessageBox.Show("Блюдо успешно удалено");
                    dataGridViewBanquetDish.Refresh();
                    GetBanquetDish();
                    ClearDishData();
                    CountTotalValue();



                }
            }
            catch (Exception error)
            {

                MessageBox.Show("При удалении блюда возникла ошибка:" + error.Message);
            }
        }


        private void ClearDishData()
        {
            cmbDishestoAdd.ResetText();
            Qty.ResetText();
            SetPaneltoDefaultStyle1();
        }




        private void ClearData()
        {

            txtComment.Text = txtDate.Text = txtFirstName.Text = txtLastName.Text = txtNumberOfQuests.Text = PhoneNumber.Text = txtService.Text = txtDiscount.Text = string.Empty;
            cmbBanquetStatus.ResetText();
            cmbPaymentStatus.ResetText();
            cmbTime.ResetText();
            btnSave.Text = "Сохранить";
            banqId = 0;
            dataGridViewBanquetDish.DataSource = null;
            lblTotal.Text = $"Общая стоимость: 0 руб. + Обслуживание: 0 р.";
            Qty.Enabled = false;
            cmbDishestoAdd.Enabled = false;
            btnExportDish.Enabled = false;
            btnAddDishtoBanquet.Enabled = false;
            btnDishDelete.Enabled = false;
            


        }

        

       

        

        

        

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (global.IsAdministrator == true)
            {
                var searchResultAdmin = from d in db.Banquets
                                        where d.CustomerLastName.Contains(txtSearch.Text) ^ d.CustomerPhoneNumber.Contains(txtSearch.Text)
                                        join s in db.BanquetStatus on d.StatusId equals s.Id
                                        join p in db.PrepaymentStatuses on d.PrepaymentId equals p.Id
                                        join x in db.Users on d.ChangedBy equals x.Id
                                        select new
                                        {

                                            d.Id,
                                            d.Date,
                                            d.Time,
                                            d.CustomerFirstName,
                                            d.CustomerLastName,
                                            d.CustomerPhoneNumber,
                                            d.NumberOfQuests,
                                            d.Comment,
                                            Status = s.Name,
                                            Payment = p.Name, 
                                            x.Username,
                                            d.ChangeDate

                                        };





                dataGridViewBanquet.DataSource = searchResultAdmin.ToList();
                SetDataGridColumnsBanquets();
            }
            else
            {
                var searchResultUser = from d in db.Banquets
                                        where d.CustomerLastName.Contains(txtSearch.Text) ^ d.CustomerPhoneNumber.Contains(txtSearch.Text)
                                        join s in db.BanquetStatus on d.StatusId equals s.Id
                                        join p in db.PrepaymentStatuses on d.PrepaymentId equals p.Id
                                        select new
                                        {

                                            d.Id,
                                            d.Date,
                                            d.Time,
                                            d.CustomerFirstName,
                                            d.CustomerLastName,
                                            d.CustomerPhoneNumber,
                                            d.NumberOfQuests,
                                            d.Comment,
                                            Status = s.Name,
                                            Payment = p.Name

                                        };





                dataGridViewBanquet.DataSource = searchResultUser.ToList();
                SetDataGridColumnsBanquets();
            }

        }
        private void btnSearchClear_Click(object sender, EventArgs e)
        {
            SetDataInGridViewBanquets();
            txtSearch.ResetText();
        }
        public void CountTotalValue()
        {
            banqId = Convert.ToInt32(dataGridViewBanquet.CurrentRow.Cells["Id"].Value);
            banquet = db.Banquets.Where(x => x.Id == banqId).FirstOrDefault();

            var countResult = from a in db.BanquetDishes
                              where a.BanquetId == banqId
                              join b in db.Dishes on a.DishId equals b.Id
                              select new
                              {
                                  b.Price,
                                  a.Qty,
                                  b.Discount
                              };


            var ServicePrice = (from d in db.Banquets
                                where d.Id == banqId
                                select d.Service).FirstOrDefault();
            var Discount = (from d in db.Banquets
                            where d.Id == banqId
                            select d.Discount).FirstOrDefault();


            if (countResult.Count() < 1)
            {
                lblTotal.Text = $"ИТОГО за блюда: 0 руб. + Обслуживание: {ServicePrice} руб.";
            }
            else
            {
                decimal TotalPrice = countResult.Sum(b => (decimal)b.Qty * b.Price);
                decimal CountDiscount = (TotalPrice * (decimal)Discount)/100;
                decimal Final = TotalPrice - CountDiscount;
                decimal Total = Final + (decimal)ServicePrice;
                lblTotal.Text = $"ИТОГО {Total} руб. | с учетом скидки {Discount}%, ИТОГО за блюда: {Final} руб. (без учета скидки: {TotalPrice} руб.) | Обслуживание: {ServicePrice} руб.";
            }


        }



        private void btnAddDishtoBanquet_Click(object sender, EventArgs e)
        {
            try
            {
                banqDish.BanquetId = banqId;
                banqDish.DishId = (int)cmbDishestoAdd.SelectedValue;
                banqDish.Qty = Convert.ToInt32(Qty.Text);
                
                if (banqDishId > 0)
                {
                    banqDish.ChangedBy = global.userId;
                    banqDish.ChangedDate = System.DateTime.Now;
                    db.Entry(banqDish).State = System.Data.Entity.EntityState.Modified;
                }
                else
                {
                    banqDish.ChangedBy = global.userId;
                    banqDish.ChangedDate = System.DateTime.Now;
                    db.BanquetDishes.Add(banqDish);
                }

                    db.SaveChanges();
                    
                    //ClearData();
                    GetBanquetDish();
                    dataGridViewBanquetDish.Refresh();
                    MessageBox.Show("Блюдо успешно добавлено");
                    Qty.ResetText();
                    CountTotalValue();


            }
            catch (Exception error)
            {

                MessageBox.Show(error.Message);
            }

        }

        

        

        private void ibToPdf_Click(object sender, EventArgs e)
        {
            
        }

        private void btnExportToExcel_Click(object sender, EventArgs e)
        {
            try
            {
                //Creating DataTable
                DataTable dt = new DataTable();

                //Adding the Columns
                foreach (DataGridViewColumn column in dataGridViewBanquet.Columns)
                {
                    dt.Columns.Add(column.HeaderText, column.ValueType);
                }

                //Adding the Rows
                foreach (DataGridViewRow row in dataGridViewBanquet.Rows)
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
                    wb.Worksheets.Add(dt, "Банкеты");
                    wb.SaveAs(folderPath + "BookingBanquets.xlsx");
                    MessageBox.Show("Файл успешно сохранен: C:\\Excel");

                }
            }
            catch (Exception error)
            {

                MessageBox.Show(error.Message);
            }
        }


        private void btnDishCancel_Click(object sender, EventArgs e)
        {

            cmbDishestoAdd.ResetText();
            Qty.ResetText();
            btnAddDishtoBanquet.Text = "Добавить";
            btnAddDishtoBanquet.Enabled = true;
            banqDishId = 0;

        }



        public void SetPaneltoDefaultStyle1()
        {
            cmbDishestoAdd.Enabled = true;
            Qty.Enabled = true;
            btnAddDishtoBanquet.Enabled = true;
            btnAddDishtoBanquet.Text = "Добавить";
            btnDishDelete.Enabled = false;
        }

        public void SetPaneltoDefaultStyle2()
        {
            cmbDishestoAdd.Enabled = true;
            Qty.Enabled = true;
            btnAddDishtoBanquet.Enabled = true;
            btnAddDishtoBanquet.Text = "Добавить";
            btnDishDelete.Enabled = true;
        }

        public void SetEnableTrueForDishArea()
        {
            
            Qty.Enabled = true;
            cmbDishestoAdd.Enabled = true;
            btnExportDish.Enabled = true;
            btnAddDishtoBanquet.Enabled = true;
            btnDishDelete.Enabled = true;
            //btnSaveEdit.Enabled = true;
            //txtQtyChange.Enabled = true;
        }

        public void SetEnableFalseForDishArea()
        {

            Qty.Enabled = false;
            cmbDishestoAdd.Enabled = false;
            btnExportDish.Enabled = false;
            btnAddDishtoBanquet.Enabled = false;
            btnDishDelete.Enabled = false;
            //btnSaveEdit.Enabled = false;
            //txtQtyChange.Enabled = false;
        }

        
        
        
        //DataGridColumns constructor
        public void SetDataGridColumnsBanquets()
        {
            if (global.IsAdministrator == true)
            {
                dataGridViewBanquet.EnableHeadersVisualStyles = false;
                dataGridViewBanquet.AutoGenerateColumns = false;
                dataGridViewBanquet.Columns[0].HeaderText = "#";
                dataGridViewBanquet.Columns[1].HeaderText = "Дата";
                dataGridViewBanquet.Columns[2].HeaderText = "Время";
                dataGridViewBanquet.Columns[3].HeaderText = "Имя";
                dataGridViewBanquet.Columns[4].HeaderText = "Отчество";
                dataGridViewBanquet.Columns[5].HeaderText = "Статус";
                dataGridViewBanquet.Columns[6].HeaderText = "Предоплата";
                dataGridViewBanquet.Columns[7].HeaderText = "Изменено";
                dataGridViewBanquet.Columns[8].HeaderText = "Дата изменения";
            }
            else
            {
                dataGridViewBanquet.EnableHeadersVisualStyles = false;
                dataGridViewBanquet.AutoGenerateColumns = false;
                dataGridViewBanquet.Columns[0].HeaderText = "#";
                dataGridViewBanquet.Columns[1].HeaderText = "Дата";
                dataGridViewBanquet.Columns[2].HeaderText = "Время";
                dataGridViewBanquet.Columns[3].HeaderText = "Имя";
                dataGridViewBanquet.Columns[4].HeaderText = "Отчество";
                dataGridViewBanquet.Columns[5].HeaderText = "Телефон";
                dataGridViewBanquet.Columns[6].HeaderText = "Кол-во гостей";
                dataGridViewBanquet.Columns[7].HeaderText = "Комментарий";
                dataGridViewBanquet.Columns[8].HeaderText = "Статус";
                dataGridViewBanquet.Columns[9].HeaderText = "Предоплата";
            }
        }

        public void SetDataGridColumnsBanquetDishes()
        {
            if (global.IsAdministrator == true)
            {
                dataGridViewBanquetDish.EnableHeadersVisualStyles = false;
                dataGridViewBanquetDish.Columns[0].Visible = false;
                dataGridViewBanquetDish.Columns[1].HeaderText = "Назание";
                dataGridViewBanquetDish.Columns[2].HeaderText = "Кол-во";
                dataGridViewBanquetDish.Columns[3].HeaderText = "Цена";
                dataGridViewBanquetDish.Columns[4].HeaderText = "Вес";
                dataGridViewBanquetDish.Columns[5].HeaderText = "Общая стоимость";
                dataGridViewBanquetDish.Columns[6].HeaderText = "Изменено";
                dataGridViewBanquetDish.Columns[7].HeaderText = "Дата измнения";
            }
            else
            {
                dataGridViewBanquetDish.EnableHeadersVisualStyles = false;
                dataGridViewBanquetDish.Columns[0].Visible = false;
                dataGridViewBanquetDish.Columns[1].HeaderText = "Назание";
                dataGridViewBanquetDish.Columns[2].HeaderText = "Кол-во";
                dataGridViewBanquetDish.Columns[3].HeaderText = "Цена";
                dataGridViewBanquetDish.Columns[4].HeaderText = "Вес";
                dataGridViewBanquetDish.Columns[5].HeaderText = "Общая стоимость";
                
            }
        }
         
        //DropDowns Values
        public void GetListOfPrePaymentStatus()
        {
            var result = from x in db.PrepaymentStatuses
                         where x.IsActive == true
                         select new 
                         { 
                            x.Id,
                            x.Name
                         };


            
            cmbPaymentStatus.DataSource = result.ToList();
            cmbPaymentStatus.ValueMember = "Id";
            cmbPaymentStatus.DisplayMember = "Name";
        }

        public void GetListOfBanquetStatus()
        {
            List<BanquetStatu> banquetStatus = db.BanquetStatus.ToList();
            cmbBanquetStatus.DataSource = banquetStatus;
            cmbBanquetStatus.ValueMember = "Id";
            cmbBanquetStatus.DisplayMember = "Name";
        }

        public void GetListofDishestoAdd()
        {
            var DishesToAdd = from a in db.Dishes
                              where a.IsAvalible == true
                              select new
                              {
                                  a.Id,
                                  a.Name
                              };

            cmbDishestoAdd.DataSource = DishesToAdd.ToList();
            cmbDishestoAdd.ValueMember = "Id";
            cmbDishestoAdd.DisplayMember = "Name";

            //List<PrepaymentStatus> PaymentStatus = db.PrepaymentStatuses.ToList();
        }

        //check Dleete button
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

        private void btnExportDish_Click(object sender, EventArgs e)
        {
            try
            {
                //Creating DataTable
                DataTable dt = new DataTable();

                //Adding the Columns
                foreach (DataGridViewColumn column in dataGridViewBanquetDish.Columns)
                {
                    dt.Columns.Add(column.HeaderText, column.ValueType);
                }

                //Adding the Rows
                foreach (DataGridViewRow row in dataGridViewBanquetDish.Rows)
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
                    wb.Worksheets.Add(dt, "Меню");
                    wb.SaveAs(folderPath + "Меню банкета.xlsx");
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
