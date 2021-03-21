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
    public partial class Order_Materials : Form
    {
   
        public int i;
        public int activityNum;
        public string material;
        public Material material2;
        
        public Order_Materials()
        {
  
            InitializeComponent();
            foreach (Activity ar in Program.Activities)
            {
                if (ar.getEmbedRoom() == false)
                {
                    Activities act = ar.getActivity();
                    DateTime dt = ar.getStartTime();
                    activityNum = ar.getId();
                    comboBox1.Items.Add(String.Format("{0} | {1}", act, dt));

                }
            }

            foreach (Material matit in Program.Materials)
            {
                
                    material = matit.getTypeOfMaterial();
                if (!listBox1.Items.Contains(material)) {
                    listBox1.Items.Add(material);
                }
                    
            }


        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int tt = listBox1.SelectedIndex;
            material2 = Program.Materials[tt];

        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            int serialNum = Program.Activities.Count + 1;
            SqlCommand s = new SqlCommand();
            s.CommandText = "EXECUTE dbo.SP_Update_materialPerActivity @term_no	, @term_serialNumber, @term_quantity, @term_id";
            s.Parameters.AddWithValue("@term_no", activityNum);
            s.Parameters.AddWithValue("@term_serialNumber", material2.getSerialNumber());
            s.Parameters.AddWithValue("@term_quantity", int.Parse(textBox1.Text.ToString()));
            s.Parameters.AddWithValue("@term_id", i+23);
            i = i + 23;
           
            SQL_CON SC = new SQL_CON();
            SC.execute_non_query(s);
            Menu mn = new Menu();
            this.Hide();
            mn.Show();


        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
                string checkbox = "";
                if (textBox1.Text != null)
                {
                    checkbox = textBox1.Text.ToString();
                }

                if (checkbox != "")
                {
                    int check = int.Parse((checkbox));

                    if (check > 40)
                    {
                        textBox1.Text = null;
                        MessageBox.Show("Quantity field is not valid,the max quantity is 40!");
                    }
                }

            }

        private void Order_Materials_Load(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Return_Click(object sender, EventArgs e)
        {
            
            Menu mn = new Menu();
            mn.Show();
            this.Hide();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
