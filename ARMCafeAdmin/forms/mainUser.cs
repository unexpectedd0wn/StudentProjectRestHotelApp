using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FontAwesome.Sharp;

namespace ARMCafeAdmin
{
    public partial class mainUser : Form
    {
        public Form currentChildForm;
        //private IconButton currentBtn;
        //private Panel leftBorderBtn;
        public mainUser()
        {
            InitializeComponent();
            OpenChildForm(new userHome());
            CollapseMenu();
            lblWelcomeMsg.Text = "Добрый день, " + global.Firstname + " " + global.LastName;
            txtBarLebel.Text = "| Главная";
            //panelLeft.Controls.Add(leftBorderBtn);
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
            desctopPanel.Controls.Add(childForm);
            desctopPanel.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();

        }

        //private void ActivateButton(object senderBtn, Color color)
        //{
        //    if (senderBtn != null)
        //    {
        //        DisableButton();
        //        //Button
        //        currentBtn = (IconButton)senderBtn;
        //        currentBtn.BackColor = Color.FromArgb(37, 36, 81); //background of the batton
        //        currentBtn.ForeColor = color;
        //        currentBtn.TextAlign = ContentAlignment.MiddleCenter;
        //        currentBtn.IconColor = color;
        //        currentBtn.TextImageRelation = TextImageRelation.TextBeforeImage;
        //        currentBtn.ImageAlign = ContentAlignment.MiddleRight;
        //        //Left border button
        //        leftBorderBtn.BackColor = color;
        //        leftBorderBtn.Location = new Point(0, currentBtn.Location.Y);
        //        leftBorderBtn.Visible = true;
        //        leftBorderBtn.BringToFront();
        //        //Current Child Form Icon
        //        //iconCurrentChildForm.IconChar = currentBtn.IconChar;
        //        //iconCurrentChildForm.IconColor = color;
        //    }
        //}

        //private void DisableButton()
        //{
        //    //if (currentBtn != null)
        //    //{
        //    //    currentBtn.BackColor = Color.FromArgb(31, 30, 68);
        //    //    currentBtn.ForeColor = Color.Gainsboro;
        //    //    currentBtn.TextAlign = ContentAlignment.MiddleLeft;
        //    //    currentBtn.IconColor = Color.Gainsboro;
        //    //    currentBtn.TextImageRelation = TextImageRelation.ImageBeforeText;
        //    //    currentBtn.ImageAlign = ContentAlignment.MiddleLeft;
        //    //}
        //}

        private void CollapseMenu()
        {
            if (this.panelLeft.Width > 200) //Collapse menu
            {
                panelLeft.Width = 100;
                //pictureBox1.Visible = false;
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

        private void btnHome_Click(object sender, EventArgs e)
        {
            OpenChildForm(new userHome());
            txtBarLebel.Text = "| Главная";
        }


        private struct RGBColors
        {
            public static Color color1 = Color.FromArgb(172, 126, 241);
            public static Color color2 = Color.FromArgb(249, 118, 176);
            public static Color color3 = Color.FromArgb(253, 138, 114);
            public static Color color4 = Color.FromArgb(95, 77, 221);
            public static Color color5 = Color.FromArgb(249, 88, 155);
            public static Color color6 = Color.FromArgb(24, 161, 251);
        }

        private void btnNewOrder_Click(object sender, EventArgs e)
        {
            //ActivateButton(sender, RGBColors.color1);
            OpenChildForm(new bookTable());
            txtBarLebel.Text = "| Бронирование столов";
        }

        private void btnBanquet_Click(object sender, EventArgs e)
        {
            OpenChildForm(new banquetManagment());
            
            txtBarLebel.Text = "| Управление банкетом";
        }

        private void btnBanquetMenu_Click(object sender, EventArgs e)
        {
           OpenChildForm(new dishManagment());
            txtBarLebel.Text = "| Меню банкета";
        }

        private void btnWaiter_Click(object sender, EventArgs e)
        {
            OpenChildForm(new waiterManagment());
            txtBarLebel.Text = "| Управление официантами";
        }

        private void btnAbout_Click(object sender, EventArgs e)
        {
            OpenChildForm(new aboutProgramm());
            txtBarLebel.Text = "| О программе";
        }

        private void btnReports_Click(object sender, EventArgs e)
        {
            OpenChildForm(new reportForm());
            txtBarLebel.Text = "| Формирование отчетности";
        }


        private void btnExit_Click(object sender, EventArgs e)
        {

            this.Close();


        }


        public void mainUser_FormClosing(object sender, FormClosingEventArgs e)
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
