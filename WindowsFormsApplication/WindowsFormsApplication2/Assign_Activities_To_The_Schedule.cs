using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;


namespace WindowsFormsApplication2
{
    public partial class Assign_Activities_To_The_Schedule : Form
    {
        bool chairValue;
        bool computerValue;
        bool boardValue;
        bool tableValue;
        public Assign_Activities_To_The_Schedule()
        {

            InitializeComponent();
            comboBox1.DataSource = Enum.GetValues(typeof(Activities));//אתחול הקומבובוקס

        }

        private void Assign_Activities_To_The_Schedule_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)/////////////////שינינו מפרייבט
        {
    
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            dateTimePicker2.Format = DateTimePickerFormat.Time;
            dateTimePicker2.ShowUpDown = true;
        }

        private void button1_Click(object sender, EventArgs e) //return button
        {
           Menu mn = new Menu();
            mn.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {


            int serialNum = Program.Activities.Count() + 1; 
            SqlCommand c = new SqlCommand();
            c.CommandText = "EXECUTE dbo.SP_Update_activities @term_no,  @term_age, @term_activity, @term_needChair, @term_needtable, @term_needComputer, @term_needBoard, @term_startActivity, @term_endActivity, @term_numOfParticipants, @term_embedCounselor, @term_embedRoom";
            c.Parameters.AddWithValue("@term_no", serialNum);
            c.Parameters.AddWithValue("@term_age", int.Parse((textBox2.Text.ToString())));
            c.Parameters.AddWithValue("@term_activity", comboBox1.Text.ToString());

            c.Parameters.AddWithValue("@term_needChair", chairValue);
            c.Parameters.AddWithValue("@term_needtable", tableValue);
            c.Parameters.AddWithValue("@term_needComputer", computerValue);
            c.Parameters.AddWithValue("@term_needBoard", boardValue);

            c.Parameters.AddWithValue("@term_startActivity", DateTime.Parse(dateTimePicker2.Value.ToShortDateString()));
            c.Parameters.AddWithValue("@term_endActivity", DateTime.Parse(dateTimePicker1.Value.ToShortDateString()));
            c.Parameters.AddWithValue("@term_numOfParticipants",int.Parse( textBox9.Text.ToString()));
            c.Parameters.AddWithValue("@term_embedCounselor", 0);
            c.Parameters.AddWithValue("@term_embedRoom",0);


            SQL_CON SC = new SQL_CON();
            SC.execute_non_query(c);
            Program.init_Activities();
            Menu mn = new Menu();
            this.Hide();
            mn.Show();








        }

    private void label13_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            string checkbox = "";
            if (textBox2.Text != null)
            {
                 checkbox = textBox2.Text.ToString();
            }

            if (checkbox != "")
            {
                int check = int.Parse((checkbox));

                if (check > 20)
                {
                    textBox2.Text = null;
                    MessageBox.Show("age field is not valid,the max age is 20!");
                }
            }
           
        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {
            string checkbox = "";
            if (textBox9.Text != null)
            {
                checkbox = textBox9.Text.ToString();
            }

            if (checkbox != "")
            {
                int check = int.Parse((checkbox));

                if (check > 40)
                {
                    textBox9.Text = null;
                    MessageBox.Show("The field is not valid, max 40 participants!");
                }
            }

        }

        private void comboBox2_SelectedIndexChanged_1(object sender, EventArgs e)
        {

            if (comboBox2.Text.ToString() == "NO")
            {
                chairValue = false;
            }
            else
            {
                chairValue = true;
            }

        }


        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.Text.ToString() == "NO")
            {
                tableValue = false;
            }
            else
            {
                tableValue = true;
            }

        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.Text.ToString() == "NO")
            {
                computerValue = false;
            }
            else
            {
                computerValue = true;
            }
        }

        private void dateTimePicker1_ValueChanged_1(object sender, EventArgs e)
        {

        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.Text.ToString() == "NO")
            {
                boardValue = false;
            }
            else
            {
                boardValue = true;
            }

        }

        private void dateTimePicker3_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker3_ValueChanged_1(object sender, EventArgs e)
        {

        }



        //  if (e.ToString)

        //   if (System.Text.RegularExpressions.Regex.IsMatch(textBox2.Text, "50"))
        //  {
        //      MessageBox.Show("Please enter only numbers.");
        //     textBox2.Text = textBox2.Text.Remove(textBox2.Text.Length - 1);
        //    }
        //if (textBox2.Text.Length < 0 && textBox2.Text.Length > 2)
        //{
        //    MessageBox.Show("age field is not valid, must include max 2 digits");
        // }
    }

       /* private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
         //   char ch = e.KeyChar;
          //  if(!char.IsDigit(ch) && ch!=8 && ch != 46)
         //   {
         //       e.Handled = true;
         // }

          

            

               // MessageBox.Show("age field is not valid");
               // if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
               //{
               //   e.Handled = true;
               //}
               //else
               //  MessageBox.Show("age field is not valid");
        }*/
    }


            
         

                