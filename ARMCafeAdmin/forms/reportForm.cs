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
    public partial class reportForm : Form
    {
        DBEntity db = new DBEntity();

        public reportForm()
        {
            InitializeComponent();
            
        }

        private void reportForm_Load(object sender, EventArgs e)
        {
            GetListofReports();
        }



        public void GetListofReports()
        {
            var Reports = from a in db.Reports
                          where a.IsActive == true
                             select new
                              {
                                  a.Id,
                                  a.Name
                              };

            cmbListOfReprts.DataSource = Reports.ToList();
            cmbListOfReprts.ValueMember = "Id";
            cmbListOfReprts.DisplayMember = "Name";
        }
        
        

        private void btnCreateReport_Click(object sender, EventArgs e)
        {
            int selectedReport = (int)cmbListOfReprts.SelectedValue;

            switch (selectedReport)
            {
                case 1:

                    try
                    {
                        if (global.IsAdministrator == true)
                        {
                            var reportResultAdmin = from x in db.BookingTables
                                                   join c in db.RestTables on x.Table equals c.Id
                                                   join v in db.BookingTableStatus on x.StatusId equals v.Id
                                                   join b in db.Users on x.ChangedBy equals b.Id
                                                   where x.Date >= dtFrom.Value && x.Date <= dtTo.Value
                                               select new
                                               {
                                                   x.Id,
                                                   x.Date,
                                                   x.BookingTime,
                                                   x.FirstName,
                                                   x.LastName,
                                                   x.PhoneNumber,
                                                   c.TableNumber,
                                                   x.NumberOfQuests,
                                                   v.Name,
                                                   b.Username,
                                                   x.ChangedDate
                                               };

                            dataGridViewReportResult.DataSource = reportResultAdmin.ToList();
                            dataGridViewReportResult.EnableHeadersVisualStyles = false;
                            dataGridViewReportResult.Columns[0].HeaderText = "№";
                            dataGridViewReportResult.Columns[1].HeaderText = "Дата";
                            dataGridViewReportResult.Columns[2].HeaderText = "Время";
                            dataGridViewReportResult.Columns[3].HeaderText = "Имя";
                            dataGridViewReportResult.Columns[4].HeaderText = "Фамилия";
                            dataGridViewReportResult.Columns[5].HeaderText = "Телефон";
                            dataGridViewReportResult.Columns[6].HeaderText = "Номер стола";
                            dataGridViewReportResult.Columns[7].HeaderText = "Кол-во гостей";
                            dataGridViewReportResult.Columns[8].HeaderText = "Статус";
                            dataGridViewReportResult.Columns[9].HeaderText = "Изменено";
                            dataGridViewReportResult.Columns[10].HeaderText = "Дата изменения";
                            
                        }
                        else
                        {
                            var reportResultUser = from x in db.BookingTables
                                               join c in db.RestTables on x.Table equals c.Id
                                               join v in db.BookingTableStatus on x.StatusId equals v.Id
                                               where x.Date >= dtFrom.Value && x.Date <= dtTo.Value
                                               select new
                                               {
                                                   x.Id,
                                                   x.Date,
                                                   x.BookingTime,
                                                   x.FirstName,
                                                   x.LastName,
                                                   x.PhoneNumber,
                                                   c.TableNumber,
                                                   x.NumberOfQuests,
                                                   v.Name

                                               };

                            dataGridViewReportResult.DataSource = reportResultUser.ToList();
                            dataGridViewReportResult.EnableHeadersVisualStyles = false;
                            dataGridViewReportResult.Columns[0].HeaderText = "№";
                            dataGridViewReportResult.Columns[1].HeaderText = "Дата";
                            dataGridViewReportResult.Columns[2].HeaderText = "Время";
                            dataGridViewReportResult.Columns[3].HeaderText = "Имя";
                            dataGridViewReportResult.Columns[4].HeaderText = "Фамилия";
                            dataGridViewReportResult.Columns[5].HeaderText = "Телефон";
                            dataGridViewReportResult.Columns[6].HeaderText = "Номер стола";
                            dataGridViewReportResult.Columns[7].HeaderText = "Кол-во гостей";
                            dataGridViewReportResult.Columns[8].HeaderText = "Статус";
                            ;
                        }



                    }
                    catch (Exception)
                    {

                        throw;
                    }
                    
                    
                    
                    
                    
                    
                    
                    break;
                case 2:

                    try
                    {
                        if (global.IsAdministrator == true)
                        {
                            var reportResultAdmin = from x in db.Banquets
                                                    join c in db.PrepaymentStatuses on x.PrepaymentId equals c.Id
                                                    join v in db.BanquetStatus on x.StatusId equals v.Id
                                                    join b in db.Users on x.ChangedBy equals b.Id
                                                    where x.Date >= dtFrom.Value && x.Date <= dtTo.Value
                                                    select new
                                                    {
                                                        x.Id,
                                                        x.Date,
                                                        x.Time,
                                                        x.NumberOfQuests,
                                                        x.CustomerFirstName,
                                                        x.CustomerLastName,
                                                        x.CustomerPhoneNumber,
                                                        c.Name,
                                                        Status = v.Name,
                                                        x.Service,
                                                        x.Discount,
                                                        b.Username,
                                                        x.ChangeDate

                                                    };





                            dataGridViewReportResult.DataSource = reportResultAdmin.ToList();
                            dataGridViewReportResult.EnableHeadersVisualStyles = false;
                            dataGridViewReportResult.Columns[0].HeaderText = "№";
                            dataGridViewReportResult.Columns[1].HeaderText = "Дата";
                            dataGridViewReportResult.Columns[2].HeaderText = "Время";
                            dataGridViewReportResult.Columns[3].HeaderText = "Кол-во гостей";
                            dataGridViewReportResult.Columns[4].HeaderText = "Имя";
                            dataGridViewReportResult.Columns[5].HeaderText = "Фамилия";
                            dataGridViewReportResult.Columns[6].HeaderText = "Телефон";
                            dataGridViewReportResult.Columns[7].HeaderText = "Предоплата";
                            dataGridViewReportResult.Columns[8].HeaderText = "Статус";
                            dataGridViewReportResult.Columns[9].HeaderText = "Обслуживание";
                            dataGridViewReportResult.Columns[10].HeaderText = "Скидка";
                            dataGridViewReportResult.Columns[11].HeaderText = "Изменено";
                            dataGridViewReportResult.Columns[12].HeaderText = "Дата изменения";

                        }
                        else
                        {
                            var reportResultUser = from x in db.Banquets
                                                    join c in db.PrepaymentStatuses on x.PrepaymentId equals c.Id
                                                    join v in db.BanquetStatus on x.StatusId equals v.Id
                                                    where x.Date >= dtFrom.Value && x.Date <= dtTo.Value
                                                    select new
                                                    {
                                                        x.Id,
                                                        x.Date,
                                                        x.Time,
                                                        x.Comment,
                                                        x.NumberOfQuests,
                                                        x.CustomerFirstName,
                                                        x.CustomerLastName,
                                                        x.CustomerPhoneNumber,
                                                        c.Name,
                                                        Status = v.Name,
                                                        x.Service,
                                                        x.Discount
                                                        

                                                    };





                            dataGridViewReportResult.DataSource = reportResultUser.ToList();
                            dataGridViewReportResult.EnableHeadersVisualStyles = false;
                            dataGridViewReportResult.Columns[0].HeaderText = "№";
                            dataGridViewReportResult.Columns[1].HeaderText = "Дата";
                            dataGridViewReportResult.Columns[2].HeaderText = "Время";
                            dataGridViewReportResult.Columns[3].HeaderText = "Комментарий";
                            dataGridViewReportResult.Columns[4].HeaderText = "Кол-во гостей";
                            dataGridViewReportResult.Columns[5].HeaderText = "Имя";
                            dataGridViewReportResult.Columns[6].HeaderText = "Фамилия";
                            dataGridViewReportResult.Columns[7].HeaderText = "Телефон";
                            dataGridViewReportResult.Columns[8].HeaderText = "Предоплата";
                            dataGridViewReportResult.Columns[9].HeaderText = "Статус";
                            dataGridViewReportResult.Columns[10].HeaderText = "Обслуживание";
                            dataGridViewReportResult.Columns[11].HeaderText = "Скидка";
                            

                        }



                    }
                    catch (Exception)
                    {

                        throw;
                    }


                    
                    break;
            }

        }

        private void btnExportToExcel_Click(object sender, EventArgs e)
        {
            try
            {
                //Creating DataTable
                DataTable dt = new DataTable();

                //Adding the Columns
                foreach (DataGridViewColumn column in dataGridViewReportResult.Columns)
                {
                    dt.Columns.Add(column.HeaderText, column.ValueType);
                }

                //Adding the Rows
                foreach (DataGridViewRow row in dataGridViewReportResult.Rows)
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
                    int selectedReport = (int)cmbListOfReprts.SelectedValue;

                    switch (selectedReport)
                    {
                        case 1:
                            wb.Worksheets.Add(dt, "Бронирования столов");
                            wb.SaveAs(folderPath + "ReportBookingTable.xlsx");
                            break;
                        case 2:
                            wb.Worksheets.Add(dt, "Бронирования банкетов");
                            wb.SaveAs(folderPath + "ReportBookingBanquets.xlsx");
                            break;
                        
                    }

                    









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
