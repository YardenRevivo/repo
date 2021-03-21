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
    public partial class Login : Form
    {

   
        public Login()
        {
            InitializeComponent();
        }

        Menu menu = new Menu();
        CounselorMenu CounselorMenu = new CounselorMenu();


        private void pictureBox1_Click(object sender, EventArgs e) //picture
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void fontDialog1_Apply(object sender, EventArgs e)
        {

        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void maskedTextBox2_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            maskedTextBox2.PasswordChar = '*';
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Employee empl = Program.searchEmployee(int.Parse(maskedTextBox1.Text));
            
            
            if (empl != null && (empl.getPassword() == maskedTextBox2.Text))
            {
                MessageBox.Show("You are now logged in");
               if (empl.getType().ToString().Equals("counselor"))
              {
                    this.Hide();
                    CounselorMenu.Show();
                }
                else
                {
                    this.Hide();
                    menu.Show();
                }
            }
            else
            {
                MessageBox.Show("Incorrect user name and/or password, please try again");
            }
        }
  
        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime dt = DateTime.Now;
            label5.Text = dt.ToString();
        }
        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
