using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace ARMCafeAdmin
{
    public partial class mainAdmin : Form
    {
        
        private Form currentChildForm;
        public mainAdmin()
        {
            InitializeComponent();
            
        }

        private void mainAdmin_Load(object sender, EventArgs e)
        {
            OpenChildForm(new userManagment());
            lblWelcomeMsg.Text = "Добрый день " + global.Firstname + " " + global.LastName;
            labelTopPanel.Text = "| Управление пользователями";
        }

        private void CollapseMenu()
        {
            if (this.panelLeft.Width > 200) 
            {
                panelLeft.Width = 100;
                btnMenu.Dock = DockStyle.Top;
                foreach (Button menuButton in panelLeft.Controls.OfType<Button>())
                {
                    menuButton.Text = "";
                    menuButton.ImageAlign = ContentAlignment.MiddleCenter;
                    menuButton.Padding = new Padding(0);
                }
            }
            else
            { //Expand menu
                panelLeft.Width = 230;
                //pictureBox1.Visible = true;
                btnMenu.Dock = DockStyle.None;
                foreach (Button menuButton in panelLeft.Controls.OfType<Button>())
                {
                    menuButton.Text = "   " + menuButton.Tag.ToString();
                    menuButton.ImageAlign = ContentAlignment.MiddleLeft;
                    menuButton.Padding = new Padding(10, 0, 0, 0);
                }
            }
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            CollapseMenu();
        }

        private void OpenChildForm(Form childForm)
        {

            if (currentChildForm != null)
            {
                currentChildForm.Close();
            }
            currentChildForm = childForm;

            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelDesctop.Controls.Add(childForm);
            panelDesctop.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnUserManagment_Click(object sender, EventArgs e)
        {
            
            OpenChildForm(new userManagment());
            labelTopPanel.Text = "| Управление пользователями";
        }

        private void btnBanquetManagment_Click(object sender, EventArgs e)
        {
            OpenChildForm(new banquetManagment());
            labelTopPanel.Text = "| Управление бронированием банкетов";
        }

        private void btnBookTable_Click(object sender, EventArgs e)
        {
            OpenChildForm(new bookTable());
            labelTopPanel.Text = "| Управление бронированием столов";
        }

        private void btnBanquetMenu_Click(object sender, EventArgs e)
        {
            OpenChildForm(new dishManagment());
            labelTopPanel.Text = "| Управление меню банкета";
        }

        private void btnCatalogs_Click(object sender, EventArgs e)
        {
            OpenChildForm(new catalogsManagment());
            labelTopPanel.Text = "| Управление справочниками";
        }

        private void btnAboutProgramm_Click(object sender, EventArgs e)
        {
            OpenChildForm(new aboutProgramm());
            labelTopPanel.Text = "| О программе";
        }

        private void btnWaiters_Click(object sender, EventArgs e)
        {
            OpenChildForm(new waiterManagment());
            labelTopPanel.Text = "| Управление официантами";
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            OpenChildForm(new reportForm());
            labelTopPanel.Text = "| Формирование отчетов";
        }

        private void mainAdmin_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show("Вы уверены что хотите закрыть приложение?", "Подтверждение", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (result == DialogResult.OK)
            {
                System.Environment.Exit(0);
            }
            else
            {
                e.Cancel = true;
            }
        }

        
    }
}
