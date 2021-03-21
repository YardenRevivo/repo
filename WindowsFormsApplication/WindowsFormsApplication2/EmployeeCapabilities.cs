using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication2
{

    public class EmployeeCapabilities
    {
        private int activityId;
        private string EmployeeId;

        public EmployeeCapabilities()
        {
            throw new NotImplementedException();
        }

        public EmployeeCapabilities(int activityId, string employeeId)
        {
            this.activityId = activityId;
            EmployeeId = employeeId;
        }
    }

        
}
