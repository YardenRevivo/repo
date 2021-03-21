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

    public partial class Assign_Activity_To_A_Room : Form
    {
        public int inti;
        public int activityNum;
        public Assign_Activity_To_A_Room()
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
                   // comboBox1.Items.Add(ar.getActivity());
                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox2.Items.Clear();
            int tt = comboBox1.SelectedIndex;
            Activity yy = Program.Activities[tt];
            List<ActivityRoom> arr = EmbedActivityToActivityRoom.availableRooms(yy);
            foreach (ActivityRoom i in arr)
            {
                comboBox2.Items.Add(i.getId());
            }
        }

        private void Assign_Activity_To_A_Room_Load(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Menu mn = new Menu();
            mn.Show();
            this.Hide();
         }

        private void button2_Click(object sender, EventArgs e)
        {
            int serialNum = Program.EmbedActivitiesToActivityRooms.Count() + 1;
            SqlCommand s = new SqlCommand();
            s.CommandText = "EXECUTE dbo.SP_Update_activityRoom @term_embedId, @term_RoomId, @term_no";
            s.Parameters.AddWithValue("@term_embedId", serialNum);
            s.Parameters.AddWithValue("@term_RoomId", comboBox2.Text.ToString());
            s.Parameters.AddWithValue("@term_no", activityNum);

            SQL_CON SC = new SQL_CON();
            SC.execute_non_query(s);
            Program.init_EmbedActivitiesToActivityRooms();
            Menu mn = new Menu();
            this.Hide();
            mn.Show();
        }
    }
}
