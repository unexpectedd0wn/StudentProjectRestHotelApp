using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using ARMCafeAdmin.DBModels;



namespace ARMCafeAdmin
{
    public partial class catalogsManagment : Form
    {

        DBEntity db = new DBEntity();

        RestTable table = new RestTable();
        DishType dishtype = new DishType();
        TablePosition tableposition = new TablePosition();
        PrepaymentStatus prepayment = new PrepaymentStatus();
        Report report = new Report();

        int tableId = 0;
        int dishtypeId = 0;
        int tablepositionId = 0;
        int prepaymentId = 0;
        int reportId = 0;
        public catalogsManagment()
        {
            InitializeComponent();


        }

        private void catalogsManagment_Load(object sender, EventArgs e)
        {
            //Tables 
            SetDataGridViewTables();
            GetListOfTablePosition();
            SetDataGridViewDishType();
            SetDataGridViewPrepayment();
            SetDataGridViewReports();
            SetDataGridViewTablePosition();
            SetIdtoInactive();

        }


        //Getting DatagridData
        public void GetListOfTablePosition()
        {
            var result = from x in db.TablePositions
                         where x.IsActive == true
                         select new
                         { 
                            x.Id,
                            x.Name
                         };

            cbTablePosition.DataSource = result.ToList();
            cbTablePosition.ValueMember = "Id";
            cbTablePosition.DisplayMember = "Name";
        }
        public void SetDataGridViewDishType()
        {
            var result = from t in db.DishTypes
                         join y in db.Users on t.ChangedBy equals y.Id
                         select new
                         {
                             t.Id,
                             t.Name,
                             t.IsActive,
                             y.Username,
                             t.ChangedDate

                         };


            dataGridViewDishTypes.DataSource = result.ToList();
            dataGridViewDishTypes.EnableHeadersVisualStyles = false;
            dataGridViewDishTypes.Columns[0].HeaderText = "#";
            dataGridViewDishTypes.Columns[1].HeaderText = "Название";
            dataGridViewDishTypes.Columns[2].HeaderText = "Активен";
            dataGridViewDishTypes.Columns[3].HeaderText = "Изменено";
            dataGridViewDishTypes.Columns[4].HeaderText = "Дата изменения";


        }
        public void SetDataGridViewTablePosition()
        {
            var result = from t in db.TablePositions
                         join y in db.Users on t.ChangedBy equals y.Id
                         select new
                         {
                             t.Id,
                             t.Name,
                             t.IsActive,
                             y.Username,
                             t.ChangedDate
                         };


            dataGridViewTablePosition.DataSource = result.ToList();
            dataGridViewTablePosition.EnableHeadersVisualStyles = false;
            dataGridViewTablePosition.Columns[0].HeaderText = "#";
            dataGridViewTablePosition.Columns[1].HeaderText = "Название";
            dataGridViewTablePosition.Columns[2].HeaderText = "Активен";
            dataGridViewTablePosition.Columns[3].HeaderText = "Изменено";
            dataGridViewTablePosition.Columns[4].HeaderText = "Дата изменения";


        }
        public void SetDataGridViewPrepayment()
        {
            var result = from t in db.PrepaymentStatuses
                         join y in db.Users on t.ChangedBy equals y.Id
                         select new
                         {
                             t.Id,
                             t.Name,
                             t.IsActive,
                             y.Username,
                             t.ChangedDate
                         };


            dataGridViewPrepayment.DataSource = result.ToList();
            dataGridViewPrepayment.EnableHeadersVisualStyles = false;
            dataGridViewPrepayment.Columns[0].HeaderText = "#";
            dataGridViewPrepayment.Columns[1].HeaderText = "Название";
            dataGridViewPrepayment.Columns[2].HeaderText = "Активен";
            dataGridViewPrepayment.Columns[3].HeaderText = "Изменено";
            dataGridViewPrepayment.Columns[4].HeaderText = "Дата изменения";


        }
        public void SetDataGridViewReports()
        {
            var result = from t in db.Reports
                         join y in db.Users on t.ChangedBy equals y.Id
                         select new
                         {
                             t.Id,
                             t.Name,
                             t.IsActive,
                             y.Username,
                             t.ChangedDate
                         };


            dataGridViewReports.DataSource = result.ToList();
            dataGridViewReports.EnableHeadersVisualStyles = false;
            dataGridViewReports.Columns[0].HeaderText = "#";
            dataGridViewReports.Columns[1].HeaderText = "Название";
            dataGridViewReports.Columns[2].HeaderText = "Активен";
            dataGridViewReports.Columns[3].HeaderText = "Изменено";
            dataGridViewReports.Columns[4].HeaderText = "Дата изменения";


        }
        public void SetDataGridViewTables()
        {
            var result = from t in db.RestTables
                         join tp in db.TablePositions on t.PositionId equals tp.Id
                         select new
                         {
                             Id = t.Id,
                             TableNumber = t.TableNumber,
                             Position = tp.Name,
                             IsActive = t.IsActive,
                             Comment = t.Comment
                         };


            dataGridViewеtables.DataSource = result.ToList();
            dataGridViewеtables.EnableHeadersVisualStyles = false;
            dataGridViewеtables.Columns[0].Visible = false;
            dataGridViewеtables.Columns[1].HeaderText = "Номер столика";
            dataGridViewеtables.Columns[2].HeaderText = "Расположение";
            dataGridViewеtables.Columns[3].HeaderText = "Активен?*";
            dataGridViewеtables.Columns[4].HeaderText = "Комментарий";

        }
        /////
        public void SetIdtoInactive()
        {
            txtDishTypeId.Enabled = false;
            txtPrepaymentId.Enabled = false;
            txtReportId.Enabled = false;
            txtTablePositionId.Enabled = false;
        }

        //Подгрузка данных при двойном клике
        private void dataGridViewеtables_CellDoubleClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridViewеtables.CurrentCell.RowIndex != -1)
            {


                tableId = Convert.ToInt32(dataGridViewеtables.CurrentRow.Cells["Id"].Value);
                table = db.RestTables.Where(x => x.Id == tableId).FirstOrDefault();
                txtTableNumber.Text = table.TableNumber.ToString();
                cbTablePosition.SelectedValue = (int)table.PositionId;
                chbIsActive.Checked = table.IsActive;
                txtComment.Text = table.Comment;

                

            }

            btnSave.Text = "Обновить";
        }
        private void dataGridViewTablePosition_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridViewTablePosition.CurrentCell.RowIndex != -1)
            {
                tablepositionId = Convert.ToInt32(dataGridViewTablePosition.CurrentRow.Cells["Id"].Value);
                tableposition = db.TablePositions.Where(x => x.Id == tablepositionId).FirstOrDefault();
                txtTablePositionId.Text = tableposition.Id.ToString();
                txtTablePostionName.Text = tableposition.Name;
                tablePositionIsActive.Checked = tableposition.IsActive;



            }
            btnSaveTablePosition.Text = "Обновить";
        }
        private void dataGridViewPrepayment_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridViewPrepayment.CurrentCell.RowIndex != -1)
            {
                prepaymentId = Convert.ToInt32(dataGridViewPrepayment.CurrentRow.Cells["Id"].Value);
                prepayment = db.PrepaymentStatuses.Where(x => x.Id == prepaymentId).FirstOrDefault();
                txtPrepaymentId.Text = prepayment.Id.ToString();
                txtPrepaymentName.Text = prepayment.Name;
                PrepaymentIsActive.Checked = prepayment.IsActive;



            }
            btnSavePrepayment.Text = "Обновить";
        }
        private void dataGridViewReports_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridViewReports.CurrentCell.RowIndex != -1)
            {
                reportId = Convert.ToInt32(dataGridViewReports.CurrentRow.Cells["Id"].Value);
                report = db.Reports.Where(x => x.Id == reportId).FirstOrDefault();
                txtReportId.Text = report.Id.ToString();
                txtReportName.Text = report.Name;
                ReportPositionIsActive.Checked = report.IsActive;



            }
            btnSaveReports.Text = "Обновить";
        }
        private void dataGridViewDishTypes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridViewDishTypes.CurrentCell.RowIndex != -1)
            {
                dishtypeId = Convert.ToInt32(dataGridViewDishTypes.CurrentRow.Cells["Id"].Value);
                dishtype = db.DishTypes.Where(x => x.Id == dishtypeId).FirstOrDefault();
                txtDishTypeId.Text = dishtype.Id.ToString();
                txtDishTypeName.Text = dishtype.Name;
                DishTypePositionIsActive.Checked = dishtype.IsActive;



            }
            btnSaveDishType.Text = "Обновить";
        }

        //Сохранение данных при нажатии на Сохранить или обновить
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                table.PositionId = (int)cbTablePosition.SelectedValue;
                table.TableNumber = Convert.ToInt32(txtTableNumber.Text);
                table.IsActive = chbIsActive.Checked;
                table.Comment = txtComment.Text.Trim();

                if (tableId > 0)
                {
                    table.ChangedBy = global.userId;
                    table.ChangedDate = System.DateTime.Now;
                    db.Entry(table).State = System.Data.Entity.EntityState.Modified;
                }
                else
                {
                    table.ChangedBy = global.userId;
                    table.ChangedDate = System.DateTime.Now;
                    db.RestTables.Add(table);
                }

                db.SaveChanges();
                CancelTables();
                SetDataGridViewTablePosition();
                MessageBox.Show("Успешно обновлено");



            }
            catch (Exception error)
            {

                MessageBox.Show("Возникла ошибка: " + error.Message, "Свяжитесь с Администратором");
            }



            


        }
        private void btnSaveTablePosition_Click(object sender, EventArgs e)
        {
            try
            {
                tableposition.Name = txtTablePostionName.Text.Trim();
                tableposition.IsActive = tablePositionIsActive.Checked;
                if (tablepositionId > 0)
                {
                    tableposition.ChangedBy = global.userId;
                    tableposition.ChangedDate = System.DateTime.Now;
                    db.Entry(tableposition).State = System.Data.Entity.EntityState.Modified;
                }
                else
                {
                    tableposition.ChangedBy = global.userId;
                    tableposition.ChangedDate = System.DateTime.Now;
                    db.TablePositions.Add(tableposition);
                }

                db.SaveChanges();
                ClearDataTablePosition();
                SetDataGridViewTablePosition();
                MessageBox.Show("Успешно обновлено");



            }
            catch (Exception error)
            {

                MessageBox.Show("Возникла ошибка: " + error.Message, "Свяжитесь с Администратором");
            }
        }
        private void btnSavePrepayment_Click(object sender, EventArgs e)
        {
            try
            {
                prepayment.Name = txtPrepaymentName.Text.Trim();
                prepayment.IsActive = PrepaymentIsActive.Checked;
                if (prepaymentId > 0)
                {
                    prepayment.ChangedBy = global.userId;
                    prepayment.ChangedDate = System.DateTime.Now;
                    db.Entry(prepayment).State = System.Data.Entity.EntityState.Modified;
                }
                else
                {
                    prepayment.ChangedBy = global.userId;
                    prepayment.ChangedDate = System.DateTime.Now;
                    db.PrepaymentStatuses.Add(prepayment);
                }

                db.SaveChanges();
                ClearDataPrepayment();
                SetDataGridViewPrepayment();
                MessageBox.Show("Успешно обновлено");



            }
            catch (Exception error)
            {

                MessageBox.Show("Возникла ошибка: " + error.Message, "Свяжитесь с Администратором");
            }
        }
        private void btnSaveReports_Click(object sender, EventArgs e)
        {
            try
            {
                report.Name = txtReportName.Text.Trim();
                report.IsActive = ReportPositionIsActive.Checked;
                if (reportId > 0)
                {
                    report.ChangedBy = global.userId;
                    report.ChangedDate = System.DateTime.Now;
                    db.Entry(report).State = System.Data.Entity.EntityState.Modified;
                }
                else
                {
                    report.ChangedBy = global.userId;
                    report.ChangedDate = System.DateTime.Now;
                    db.Reports.Add(report);
                }

                db.SaveChanges();
                ClearDataReports();
                SetDataGridViewReports();
                MessageBox.Show("Успешно обновлено");



            }
            catch (Exception error)
            {

                MessageBox.Show("Возникла ошибка: " + error.Message, "Свяжитесь с Администратором");
            }
        }
        private void btnSaveDishType_Click(object sender, EventArgs e)
        {
            try
            {
                dishtype.Name = txtDishTypeName.Text.Trim();
                dishtype.IsActive = DishTypePositionIsActive.Checked;
                if (dishtypeId > 0)
                {
                    dishtype.ChangedBy = global.userId;
                    dishtype.ChangedDate = System.DateTime.Now;
                    db.Entry(dishtype).State = System.Data.Entity.EntityState.Modified;
                }
                else
                {
                    dishtype.ChangedBy = global.userId;
                    dishtype.ChangedDate = System.DateTime.Now;
                    db.DishTypes.Add(dishtype);
                }

                db.SaveChanges();
                ClearDataDishType();
                SetDataGridViewDishType();
                MessageBox.Show("Успешно обновлено");



            }
            catch (Exception error)
            {

                MessageBox.Show("Возникла ошибка: " + error.Message, "Свяжитесь с Администратором");
            }
        }

        //Отмена 
        private void btnCancel_Click(object sender, EventArgs e)
        {
            CancelTables();
        }
        private void btnCancelDishType_Click(object sender, EventArgs e)
        {
            ClearDataDishType();
        }
        private void btnCancelReports_Click(object sender, EventArgs e)
        {
            ClearDataReports();
        }
        private void btnCancelPrepayment_Click(object sender, EventArgs e)
        {
            ClearDataPrepayment();
        }
        private void btnCancelTablePosition_Click(object sender, EventArgs e)
        {
            ClearDataTablePosition();
        }


        //Отчистка полей
        private void CancelTables()
        {
            txtComment.Text = txtTableNumber.Text = string.Empty;
            cbTablePosition.ResetText();
            chbIsActive.Checked = false;

            btnSave.Text = "Сохранить";
            tableId = 0;
        }
        public void ClearDataDishType()
        {
            txtDishTypeId.Text = txtDishTypeName.Text = string.Empty;
            DishTypePositionIsActive.Checked = false;
            btnSaveDishType.Text = "Сохранить";
            dishtypeId = 0;
        }
        public void ClearDataReports()
        {
            txtReportId.Text = txtReportName.Text = string.Empty;
            ReportPositionIsActive.Checked = false;
            btnSaveReports.Text = "Сохранить";
            reportId = 0;
        }
        public void ClearDataPrepayment()
        {
            txtPrepaymentId.Text = txtPrepaymentName.Text = string.Empty;
            PrepaymentIsActive.Checked = false;
            btnSavePrepayment.Text = "Сохранить";
            prepaymentId = 0;
        }
        public void ClearDataTablePosition()
        {
            txtTablePositionId.Text = txtTablePostionName.Text = string.Empty;
            tablePositionIsActive.Checked = false;
            btnSaveTablePosition.Text = "Сохранить";
            tablepositionId = 0;
        }

        

        

       

        

       

        
    }
}
