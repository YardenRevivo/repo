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

    public partial class Assign_Counserlor_To_An_Activity : Form
    {
        public int activityNum;
        public int EmployeeId;
        public Assign_Counserlor_To_An_Activity()
        {
            InitializeComponent();

            foreach (Activity ar in Program.Activities)
            {
                if (ar.getEmbedCounselor() == false)
                {
                    activityNum = ar.getId();
                    Activities act = ar.getActivity();
                    DateTime dt = ar.getStartTime();
                    comboBox1.Items.Add(String.Format("{0} | {1}", act, dt));

                }


            }

        }


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            //     IEnumerable<object> valArray = null;
            //      foreach (object obj in valArray)
            //      {
            //          comboBox1.Items.Add(obj);
        }
        //  }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void Assign_Counserlor_To_An_Activity_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
            {
                Menu mn = new Menu();
                mn.Show();
                 this.Hide();


        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
          
        }

        private void button2_Click(object sender, EventArgs e)
        {
  
        }

        private void checkedListBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
          
        }

      private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
             
            comboBox2.Items.Clear();
            List<Employee> arr = new List<Employee>();
            int tt = comboBox1.SelectedIndex;
            Activity yy = Program.Activities[tt];
            arr = EmbedEmployeeToActivity.availableCounselor(yy);
            foreach (Employee i in arr)
            {
                if (i != null)
                    Console.WriteLine(i.getId());

                comboBox2.Items.Add(i.getId());
            }
            activityNum = Program.Activities[tt].getId();




        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            int tt = comboBox2.SelectedIndex;
            EmployeeId = Program.Activities[tt].getId();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            int serialNum = Program.EmbedEmployeesToActivities.Count() + 6;
            SqlCommand s = new SqlCommand();
            s.CommandText = "EXECUTE [dbo].[SP_Update_embed_employee_to_activities] @term_embedId, @term_no, @term_employeeId";
            s.Parameters.AddWithValue("@term_embedId", serialNum);
            s.Parameters.AddWithValue("@term_no", activityNum);
            s.Parameters.AddWithValue("@term_employeeId", comboBox2.Text.ToString());

            SQL_CON SC = new SQL_CON();
            SC.execute_non_query(s);
            Program.init_EmbedEmployeesToActivities();
            Menu mn = new Menu();
            this.Hide();
            mn.Show();
        }

    }
}
