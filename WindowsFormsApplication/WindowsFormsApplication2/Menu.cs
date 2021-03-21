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
    public partial class Menu : Form
    {
       
        public Menu()
        {
            InitializeComponent();
        }

        Assign_Activities_To_The_Schedule secondForm = new Assign_Activities_To_The_Schedule();
        Assign_Counserlor_To_An_Activity thirdForm = new Assign_Counserlor_To_An_Activity();
        Assign_Activity_To_A_Room forthForm = new Assign_Activity_To_A_Room();
        Order_Materials fifthForm = new Order_Materials();
        Unserviceable_Room sixthForm = new Unserviceable_Room();

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private void Menu_Load(object sender, EventArgs e)
        {

        }
        private void button1_Click(object sender, EventArgs e) //Assign_Activities_To_The_Schedule
        {
            this.Hide();
            secondForm.Show();

        }
        private void button2_Click(object sender, EventArgs e) //Assign_Counserlor_To_An_Activity
        {
            this.Hide();

            thirdForm.Show();
        }
        private void button3_Click(object sender, EventArgs e) //Assign_Activity_To_A_Room
        {
            this.Hide();

            forthForm.Show();
         
        }
        private void button4_Click(object sender, EventArgs e) //Order_Materials
        {
            this.Hide();

            fifthForm.Show();
        }

        private void button5_Click(object sender, EventArgs e) //Unserviceable_Room
        {
            this.Hide();

            sixthForm.Show();
        }

       
    }
}
