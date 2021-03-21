using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication2
{
    public partial class CounselorMenu : Form
    {
        public CounselorMenu()
        {
            InitializeComponent();
        }
        CounselorOrderMterial fifthForm = new CounselorOrderMterial();
        CounselorTechnicalFaliers sixthForm = new CounselorTechnicalFaliers();
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            fifthForm.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            sixthForm.Show();
        }
    }
}
