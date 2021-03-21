using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication2
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        /// 
        public static System.Collections.Generic.List<Employee> Employees;
        public static System.Collections.Generic.List<ActivityRoom> ActivityRooms;
        public static System.Collections.Generic.List<TechnicalFailure> TechnicalFailures;
        public static System.Collections.Generic.List<Activity> Activities;
        public static System.Collections.Generic.List<Material> Materials;
        public static System.Collections.Generic.List<EmbedActivityToActivityRoom> EmbedActivitiesToActivityRooms;
        public static System.Collections.Generic.List<EmbedEmployeeToActivity> EmbedEmployeesToActivities;
        [STAThread]

        public static void initLists()//מילוי הרשימות מתוך בסיס הנתונים
        {
            init_Employees();
            init_ActivityRooms();
            init_TechnicalFailures();
            init_Activities();
            init_Materials();
            init_EmbedActivitiesToActivityRooms();
            init_EmbedEmployeesToActivities();
        }

        public static void init_Employees()//מילוי המערך מתוך בסיס הנתונים
        {
            SqlCommand c = new SqlCommand();
            c.CommandText = "EXECUTE dbo.Get_all_employees";
            SQL_CON SC = new SQL_CON();
            SqlDataReader rdr = SC.execute_query(c);
            Employees = new List<Employee>();
            while (rdr.Read())
            {
                Employee e = new Employee(rdr.GetValue(0).ToString(), rdr.GetValue(1).ToString(), rdr.GetValue(2).ToString(), rdr.GetValue(3).ToString(), rdr.GetValue(4).ToString(), int.Parse(rdr.GetValue(5).ToString()));
                Employees.Add(e);
            }
        }

        public static void init_ActivityRooms()
        {
            SqlCommand c = new SqlCommand();
            c.CommandText = "EXECUTE dbo.Get_all_activityRooms";
            SQL_CON SC = new SQL_CON();
            SqlDataReader rdr = SC.execute_query(c);
            ActivityRooms = new List<ActivityRoom>();
            while (rdr.Read())
            {
                ActivityRoom ar = new ActivityRoom(int.Parse(rdr.GetValue(0).ToString()), bool.Parse(rdr.GetValue(1).ToString()), bool.Parse(rdr.GetValue(2).ToString()), bool.Parse(rdr.GetValue(3).ToString()), bool.Parse(rdr.GetValue(4).ToString()), rdr.GetValue(5).ToString();
                ActivityRooms.Add(ar);
            }
        }

        public static void init_TechnicalFailures()
        {
            SqlCommand c = new SqlCommand();
            c.CommandText = "EXECUTE dbo.Get_all_technicalFailure";
            SQL_CON SC = new SQL_CON();
            SqlDataReader rdr = SC.execute_query(c);
            TechnicalFailures = new List<TechnicalFailure>();
            while (rdr.Read())
            {
                TechnicalFailure tf = new ActivityRoom(int.Parse(rdr.GetValue(0).ToString()), DateTime.Parse((rdr.GetValue(1).ToString())), DateTime.Parse((rdr.GetValue(2).ToString())), int.Parse(rdr.GetValue(3).ToString());
                TechnicalFailures.Add(tf);
            }
        }

        public static void init_Activities()
        {
            SqlCommand c = new SqlCommand();
            c.CommandText = "EXECUTE dbo.Get_all_activities";
            SQL_CON SC = new SQL_CON();
            SqlDataReader rdr = SC.execute_query(c);
            Activities = new List<Activity>();
            while (rdr.Read())
            {
                Activity a = new ActivityRoom(int.Parse(rdr.GetValue(0).ToString()), rdr.GetValue(1).ToString(), int.Parse(rdr.GetValue(2).ToString()), int.Parse(rdr.GetValue(3).ToString()), rdr.GetValue(4).ToString());
                Activities.Add(a);
            }
        }

        public static void init_Materials()
        {
            SqlCommand c = new SqlCommand();
            c.CommandText = "EXECUTE dbo.Get_all_materials";
            SQL_CON SC = new SQL_CON();
            SqlDataReader rdr = SC.execute_query(c);
            Materials = new List<Material>();
            while (rdr.Read())
            {
                Material m = new ActivityRoom(int.Parse(rdr.GetValue(0).ToString()), rdr.GetValue(1).ToString());
                Materials.Add(m);
            }
        }

        public static void init_EmbedActivitiesToActivityRooms()
        {
            SqlCommand c = new SqlCommand();
            c.CommandText = "EXECUTE dbo.Get_all_embedActivitiesToActivityRooms";
            SQL_CON SC = new SQL_CON();
            SqlDataReader rdr = SC.execute_query(c);
            EmbedActivitiesToActivityRooms = new List<EmbedActivityToActivityRoom>();
            while (rdr.Read())
            {
                EmbedActivityToActivityRoom eatar = new ActivityRoom(int.Parse(rdr.GetValue(0).ToString()), DateTime.Parse((rdr.GetValue(1).ToString())), DateTime.Parse((rdr.GetValue(2).ToString())), int.Parse(rdr.GetValue(3).ToString()), int.Parse(rdr.GetValue(4).ToString()));
                EmbedActivitiesToActivityRooms.Add(eatar);
            }
        }

        public static void init_EmbedEmployeesToActivities()
        {
            SqlCommand c = new SqlCommand();
            c.CommandText = "EXECUTE dbo.Get_all_embedEmployeesToActivities";
            SQL_CON SC = new SQL_CON();
            SqlDataReader rdr = SC.execute_query(c);
            EmbedEmployeesToActivities = new List<EmbedEmployeeToActivity>();
            while (rdr.Read())
            {
                EmbedEmployeeToActivity eetar = new ActivityRoom(int.Parse(rdr.GetValue(0).ToString()), DateTime.Parse((rdr.GetValue(1).ToString())), DateTime.Parse((rdr.GetValue(2).ToString())), int.Parse(rdr.GetValue(3).ToString()), int.Parse(rdr.GetValue(4).ToString()));
                EmbedEmployeesToActivities.Add(eetar);
            }
        }









        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            initLists();//אתחול כל הרשימות
            Application.Run(new Form1());
        }
    }
}
