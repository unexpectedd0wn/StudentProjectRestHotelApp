using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Reflection;
using ARMCafeAdmin.DBModels;


namespace ARMCafeAdmin
{
    public partial class aboutProgramm : Form
    {

        DBEntity db = new DBEntity();
        
        public aboutProgramm()
        {
            InitializeComponent();
        }

        private void aboutProgramm_Load(object sender, EventArgs e)
        {
            string appDir1 = Path.GetDirectoryName(
            Assembly.GetExecutingAssembly().GetName().CodeBase);
            webBrowser2.Url = new Uri(Path.Combine(appDir1, @"Resources\ReleaseNote.html"));

            string appDir2 = Path.GetDirectoryName(
            Assembly.GetExecutingAssembly().GetName().CodeBase);
            webBrowser1.Url = new Uri(Path.Combine(appDir2, @"Resources\Instruction.html"));
        }
    }
}
