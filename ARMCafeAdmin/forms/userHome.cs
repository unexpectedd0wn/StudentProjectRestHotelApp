using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ARMCafeAdmin.DBModels;

namespace ARMCafeAdmin
{
    public partial class userHome : Form
    {
        DBEntity db = new DBEntity();

        public userHome()
        {
            InitializeComponent();
            GetNumberofBookingTables();
            GetNumberOfWaiters();
            GetNumberofBookingBanquets();
        }


        public void GetNumberOfWaiters()
        {
            try
            {
                var result = from a in db.WatersSchedules
                             join b in db.Waiters on a.WaterId equals b.Id
                             where a.WorkDate == DateTime.Today
                             select new
                             {
                                 b.Id
                             };


                int TTodays = result.Count();
                

                if (TTodays <= 1)
                {
                    waiterCounter.Text = "0";
                }
                else
                {
                    waiterCounter.Text = TTodays.ToString();
                }
            }
            catch (Exception error)
            {

                MessageBox.Show("Возникла ошибка при :" + error.Message);
            }
        }

        public void GetNumberofBookingTables()
        {
                try
                {
                    var result = from a in db.BookingTables
                                 where a.Date == DateTime.Today
                                 select new
                                 {
                                     Id = a.Id
                                 };


                    int TTodays = result.Count();
                    
                    if (TTodays < 1)
                    {
                        bookinTableCounter.Text = "0";
                    }
                    else
                    {
                        bookinTableCounter.Text = TTodays.ToString();
                    }
                }
                catch (Exception error)
                {

                    MessageBox.Show("Возникла ошибка при :" + error.Message);
                }
         }


        public void GetNumberofBookingBanquets()
        {
            try
            {
                var result = from a in db.Banquets
                             where a.Date == DateTime.Today
                             select new
                             {
                                 Id = a.Id
                             };


                int TTodays = result.Count();

                if (TTodays <= 1)
                {
                    BanquetCounter.Text = "0";
                }
                else
                {
                    BanquetCounter.Text = TTodays.ToString();
                }
            }
            catch (Exception error)
            {

                MessageBox.Show("Возникла ошибка при :" + error.Message);
            }
        }


        






    }
}
