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

    public partial class Unserviceable_Room : Form
    {
        public string EmployeeId;

        public Unserviceable_Room()
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
            //ActivityRoom acr = Program.searchActivityRoom(int.Parse(comboBox1.ValueMember.ToString()));
            //Employee emp = Program.searchEmployee(int.Parse(comboBox2.ValueMember.ToString())); //בעיה עם הטו סטרינג, צריך לבדוק את כל הרעיון
            //string stri = richTextBox1.Text.ToString();



        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //ActivityRoom acr = Program.searchActivityRoom(int.Parse(comboBox1.ValueMember.ToString()));


        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
           //omboBox2.Items.Clear();
            int tt = comboBox2.SelectedIndex;
            EmployeeId = Program.Employees[tt].getId().ToString();
            //Employee emp = Program.searchEmployee(int.Parse(comboBox2.ValueMember.ToString()));

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
            /* int serial = Program.TechnicalFailures.Count;
              DateTime dt = dateTimePicker1.Value.Date;
              ActivityRoom acr = Program.searchActivityRoom(int.Parse(comboBox1.ValueMember.ToString()));
              Employee emp = Program.searchEmployee(int.Parse(comboBox2.ValueMember.ToString()));
              string stri = richTextBox1.Text.ToString();
              TechnicalFailure tf = new TechnicalFailure(serial, dt, acr, emp, stri);
              Program.TechnicalFailures.Add(tf); */
        } 
        
        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
           // string stri = richTextBox1.Text.ToString();
        }

        private void Unserviceable_Room_Load(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            DateTime dt = dateTimePicker1.Value.Date;
        }

     /*   private void button2_Click(object sender, EventArgs e)
        {
         //   Menu mn = new Menu();
         //   mn.Show();
         //   this.Hide();

        }

        private void button2_Click_1(object sender, EventArgs e)
        {

        }

        private void button2_Click_2(object sender, EventArgs e)
        {
             Menu mn = new Menu();
             mn.Show();
            this.Hide();
        }
        */
        private void button2_Click_3(object sender, EventArgs e)
        {
            Menu a = new Menu();
            a.Show();
            this.Hide();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
