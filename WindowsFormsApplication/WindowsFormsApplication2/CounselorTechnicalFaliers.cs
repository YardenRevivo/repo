using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WindowsFormsApplication2
{
    public partial class CounselorTechnicalFaliers : Form
    {
        public string EmployeeId;
        public CounselorTechnicalFaliers()
       
            {
                InitializeComponent();

                foreach (ActivityRoom ar in Program.ActivityRooms)
                {
                    int inti = ar.getId();
                    comboBox1.Items.Add(inti);
                }

                foreach (Employee e in Program.Employees)
                {
                    string stringi = e.getUserName();
                    //int intit = e.getId();
                    if (!comboBox2.Items.Contains(stringi))
                    {
                        comboBox2.Items.Add(stringi);
                    }
                }
                int serial = Program.TechnicalFailures.Count;
                DateTime dt = dateTimePicker1.Value.Date;
            }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            DateTime dt = dateTimePicker1.Value.Date;
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            int tt = comboBox2.SelectedIndex;
            EmployeeId = Program.Employees[tt].getId().ToString();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            int serialNum = Program.TechnicalFailures.Count() + 1;
            SqlCommand s = new SqlCommand();
            s.CommandText = "EXECUTE [dbo].[SP_create_technical_call] @term_no, @term_dt, @term_roomId, @term_employeeId, @term_description";
            s.Parameters.AddWithValue("@term_no", serialNum);
            s.Parameters.AddWithValue("@term_dt", DateTime.Parse(dateTimePicker1.Value.ToShortDateString()));
            s.Parameters.AddWithValue("@term_roomId ", comboBox1.Text.ToString());
            s.Parameters.AddWithValue("@term_employeeId ", EmployeeId);
            s.Parameters.AddWithValue("@term_description ", richTextBox1.Text.ToString());

            SQL_CON SC = new SQL_CON();
            SC.execute_non_query(s);
            Program.init_TechnicalFailures();
            CounselorMenu mn = new CounselorMenu();
            this.Hide();
            mn.Show();


        }

        private void button2_Click(object sender, EventArgs e)
        {
            CounselorMenu a = new CounselorMenu();
            a.Show();
            this.Hide();
        }

        private void CounselorTechnicalFaliers_Load(object sender, EventArgs e)
        {

        }
    }
    
}
