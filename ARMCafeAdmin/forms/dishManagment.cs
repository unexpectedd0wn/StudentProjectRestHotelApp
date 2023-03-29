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
    public partial class dishManagment : Form
    {

        DBEntity db = new DBEntity();
        Dish dish = new Dish();
        int dishId = 0;
        public dishManagment()
        {
            InitializeComponent();

        }

        private void dishManagment_Load(object sender, EventArgs e)
        {
            SetDataInGridView();
            GetListOfDishTypes();
            CheckDeleteBtn();
        }

        

        public void GetListOfDishTypes()
        {
            try
            {
                var result = from x in db.DishTypes
                             where x.IsActive == true
                             select new
                             { 
                                x.Id,
                                x.Name
                             };

                cmbDishTypes.DataSource = result.ToList();
                cmbDishTypes.ValueMember = "Id";
                cmbDishTypes.DisplayMember = "Name";
            }
            catch (Exception error)
            {

                MessageBox.Show("Возникла ошибка: " + error.Message);
            }
        }
        public void SetDataInGridView()
        {
            if (global.IsAdministrator == true)
            {
                try
                {
                    var resultAdmin = from d in db.Dishes
                                 join t in db.DishTypes on d.Type equals t.Id
                                 join f in db.Users on d.ChangedBy equals f.Id

                                 select new
                                 {
                                     d.Id,
                                     d.Name,
                                     d.Price,
                                     d.Weight,
                                     d.IsAvalible,
                                     DishType = t.Name,
                                     d.Сomposition,
                                     f.Username,
                                     d.ChangedDate
                                 };


                    dataGridViewDish.DataSource = resultAdmin.ToList();
                    SetDataGridStyle();
                }
                catch (Exception error)
                {

                    MessageBox.Show("Возникла ошибка: " + error.Message);
                }
            }
            else
            {
                try
                {
                    var resultUser = from d in db.Dishes
                                 join t in db.DishTypes on d.Type equals t.Id


                                 select new
                                 {
                                     d.Id,
                                     d.Name,
                                     d.Price,
                                     d.Weight,
                                     d.IsAvalible,
                                     Dishtype = t.Name,
                                     d.Сomposition
                                 };


                    dataGridViewDish.DataSource = resultUser.ToList();
                    SetDataGridStyle();
                }
                catch (Exception error)
                {

                    MessageBox.Show("Возникла ошибка: " + error.Message);
                }
            }
        }
        private void ClearData()
        {
            try
            {
                txtDishName.Text = txtPrice.Text = txtWeight.Text = txtСomposition.Text = string.Empty;
                cmbDishTypes.ResetText();
                cbIsActive.Checked = false;
                btnDelete.Enabled = false;
                btnSave.Text = "Сохранить";
                dishId = 0;
            }
            catch (Exception error)
            {

                MessageBox.Show("Возникла ошибка: " + error.Message);
            }
        }

        private void dataGridViewDish_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridViewDish.CurrentCell.RowIndex != -1)
            {
                try
                {
                    dishId = Convert.ToInt32(dataGridViewDish.CurrentRow.Cells["Id"].Value);
                    dish = db.Dishes.Where(x => x.Id == dishId).FirstOrDefault();
                    txtDishName.Text = dish.Name;
                    txtPrice.Text = dish.Price.ToString();
                    cmbDishTypes.SelectedValue = (int)dish.Type;
                    txtWeight.Text = dish.Weight.ToString();
                    cbIsActive.Checked = dish.IsAvalible;
                    txtСomposition.Text = dish.Сomposition;

                    btnSave.Text = "Обновить";
                    btnDelete.Enabled = true;
                }
                catch (Exception error)
                {

                    MessageBox.Show("Возникла ошибка: " + error.Message);
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtDishName.Text == null)
            {
                MessageBox.Show("Обязательное поле не заполнено");
            }
            else
            {
                dish.Name = txtDishName.Text.Trim();
                dish.Price = Convert.ToInt32(txtPrice.Text);
                dish.Type = (int)cmbDishTypes.SelectedValue;
                dish.Weight = Convert.ToInt32(txtWeight.Text);
                dish.IsAvalible = cbIsActive.Checked;
                dish.Сomposition = txtСomposition.Text;
                

                if (dishId > 0)
                {
                    dish.ChangedBy = global.userId;
                    dish.ChangedDate = System.DateTime.Now;
                    db.Entry(dish).State = System.Data.Entity.EntityState.Modified;
                }
                else
                {
                    dish.ChangedBy = global.userId;
                    dish.ChangedDate = System.DateTime.Now;
                    db.Dishes.Add(dish);
                }

                db.SaveChanges();
                ClearData();
                SetDataInGridView();
                MessageBox.Show("Успешно обновлено");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Вы уверены что хотите удалить блюдо ?", "Удалить ?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                db.Dishes.Remove(dish);
                db.SaveChanges();
                ClearData();
                SetDataInGridView();

                MessageBox.Show("Блюдо успешно удалено");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ClearData();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (global.IsAdministrator == true)
            {
                try
                {
                    var searchResultAdmin = from d in db.Dishes
                                            join t in db.DishTypes on d.Type equals t.Id
                                            join f in db.Users on d.ChangedBy equals f.Id
                                            where d.Name.Contains(txtSearch.Text)

                                       select new
                                       {
                                           d.Id,
                                           d.Name,
                                           d.Price,
                                           d.Weight,
                                           d.IsAvalible,
                                           DishType = t.Name,
                                           d.Сomposition,
                                           f.Username,
                                           d.ChangedDate
                                       };

                    dataGridViewDish.DataSource = searchResultAdmin.ToList();
                    SetDataGridStyle();
                }
                catch (Exception error)
                {

                    MessageBox.Show("Возникла ошибка: " + error.Message);
                }
            }
            else
            {
                try
                {
                    var searchResultUser = from d in db.Dishes
                                       join t in db.DishTypes on d.Type equals t.Id
                                       where d.Name.Contains(txtSearch.Text)

                                       select new
                                       {
                                           Id = d.Id,
                                           Name = d.Name,
                                           Price = d.Price,
                                           Weight = d.Weight,
                                           IsAvalible = d.IsAvalible,
                                           DishType = t.Name,
                                           Сomposition = d.Сomposition
                                       };

                    dataGridViewDish.DataSource = searchResultUser.ToList();
                    SetDataGridStyle();
                }
                catch (Exception error)
                {

                    MessageBox.Show("Возникла ошибка: " + error.Message);
                }
            }
            
            
            
            
            
            
        }

        private void btnClearSearch_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
            SetDataInGridView();
        }

        

        private void btnExportToExcel_Click(object sender, EventArgs e)
        {
            try
            {
                //Creating DataTable
                DataTable dt = new DataTable();

                //Adding the Columns
                foreach (DataGridViewColumn column in dataGridViewDish.Columns)
                {
                    dt.Columns.Add(column.HeaderText, column.ValueType);
                }

                //Adding the Rows
                foreach (DataGridViewRow row in dataGridViewDish.Rows)
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


        public void SetDataGridStyle()
        {
            if (global.IsAdministrator == true)
            {
                dataGridViewDish.EnableHeadersVisualStyles = false;
                dataGridViewDish.Columns[0].Visible = false;
                dataGridViewDish.Columns[1].HeaderText = "Название";
                dataGridViewDish.Columns[2].HeaderText = "Цена(руб.)";
                dataGridViewDish.Columns[3].HeaderText = "Вес(г.)";
                dataGridViewDish.Columns[4].HeaderText = "Доступен";
                dataGridViewDish.Columns[5].HeaderText = "Вид";
                dataGridViewDish.Columns[6].HeaderText = "Состав";
                dataGridViewDish.Columns[7].HeaderText = "Изменено";
                dataGridViewDish.Columns[8].HeaderText = "Дата изменения";
            }
            else
            {
                dataGridViewDish.EnableHeadersVisualStyles = false;
                dataGridViewDish.Columns[0].Visible = false;
                dataGridViewDish.Columns[1].HeaderText = "Название";
                dataGridViewDish.Columns[2].HeaderText = "Цена(руб.)";
                dataGridViewDish.Columns[3].HeaderText = "Вес(г.)";
                dataGridViewDish.Columns[4].HeaderText = "Доступен";
                dataGridViewDish.Columns[5].HeaderText = "Вид";
                dataGridViewDish.Columns[6].HeaderText = "Состав";
            }

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
    }
}
