using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication2
{
    public class Employee
    {
        private int employeeId;
        private string userName;  
        private string password;
        private EmployeeStatus status;
        private EmployeeType type;
        private Activities capability;
        List<TechnicalFailure> tf;

        public Employee(int employeeId, string userName, string password, EmployeeStatus status, EmployeeType type, Activities capability)
        {
            this.employeeId = employeeId;
            this.userName = userName;
            this.password = password;
            this.status = status;
            this.type = type;
            this.capability = capability;


            tf = new List<TechnicalFailure>();

            Program.Employees.Add(this);
        }


        public void changeStatus(EmployeeStatus empStatus)
        {
            this.status = empStatus;
        }

        public int getId()
        {
            return this.employeeId;
        }

        public string getPassword()
        {
            return this.password;
        }

        public string getUserName()
        {
            return this.userName;
        }

        public EmployeeStatus getStatus()
        {
            return this.status;
        }
        public Activities getCapability()
        {
            return this.capability;
        }
        public EmployeeType getType()
        {
            return this.type;
        }

        public void addETechnicalFailure(TechnicalFailure t)
        {
            tf.Add(t);
        }
    }
}

