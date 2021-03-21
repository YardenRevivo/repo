using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication2
{
    class EmbedEmployeeToActivity
    {
        private int serialNum;
        private Activity ActivityNum;
        private Employee EmployeeId;

        public EmbedEmployeeToActivity(int serialNum, Activity activityNum, Employee employeeId)
        {
            this.serialNum = serialNum;
            ActivityNum = activityNum;
            EmployeeId = employeeId;

            Program.EmbedEmployeesToActivities.Add(this);
        }


        public Activity getActivity()
        {
            return this.ActivityNum;
        }

      public Activities getCapabilities()
        {
         return this.EmployeeId.getCapability();
          

        }
  

        public Employee getEmployeeId()
        {
            return this.EmployeeId;
        }

        public static List<Employee> availableCounselor(Activity act) //פונקציה המקבלת פעילות ומחזירה רשימת מדריכים פנויים
        {
            List<Employee> notEmbeded = new List<Employee>();
            
            foreach (EmbedEmployeeToActivity employee1 in Program.EmbedEmployeesToActivities)
            {

                if (employee1.getActivity().getStartTime() != act.getStartTime())
                {
                    

                    if (employee1.getEmployeeId() != null)
                    {
                        if (!notEmbeded.Contains(employee1.getEmployeeId()))
                        {

                            notEmbeded.Add(employee1.getEmployeeId());
                        }
                    }
                        
                }
            }
            return notEmbeded;
        }
    }
}

