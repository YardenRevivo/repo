using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication2
{

    public class TechnicalFailure
    {
        private int serialNum;
        private DateTime openDT;
        private ActivityRoom roomId;
        private Employee employeeId;
        private string description;

        public TechnicalFailure(int serialNum, DateTime openDT, ActivityRoom roomId, Employee employeeId, string description)
        {
            this.serialNum = serialNum;
            this.openDT = openDT;
            this.roomId = roomId;
            this.employeeId = employeeId;
            this.description = description;

        }

        public void updateDT(int ac, DateTime openDT)
        {
            this.serialNum = ac;
            this.openDT = openDT;
        }


    }
}
