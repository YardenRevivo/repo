
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication2
{
    public class Activity
    {
        private int num;
        private int ages;
      
        private Activities activity;
        private bool needChair;
        private bool needTable;
        private bool needComputer;
        private bool needBoard;
        private DateTime startActivity;
        private DateTime endActivity;
        private int numOfParticipants;
        private bool embedCounselor;
        private bool embedRoom;
        List<MaterialsPerActivity> MaterialQuantity;

        public Activity(int num, int ages, Activities activity, bool needChair, bool needTable, bool needComputer, bool needBoard, DateTime startActivity, DateTime endActivity, int numOfParticipants, bool embedCounselor, bool embedRoom)
        {
            this.num = num;
            this.ages = ages;
            this.activity = activity;
            this.needChair = needChair;
            this.needTable = needTable;
            this.needComputer = needComputer;
            this.needBoard = needBoard;
            this.startActivity = startActivity;
            this.endActivity = endActivity;
            this.numOfParticipants = numOfParticipants;
            this.embedCounselor = embedCounselor;
            this.embedRoom = embedRoom;

            MaterialQuantity = new List<MaterialsPerActivity>();

        }



        public bool getEmbedRoom()
        {
            return this.embedRoom;
        }

        public List<MaterialsPerActivity> getMaterialQuantity()
        {
            return this.MaterialQuantity;
        }

        public bool getEmbedCounselor()
        {
            return this.embedCounselor;
        }

        public Activities getActivity()
        {
            return this.activity;
            
        }


        public bool getChair()
        {
            return this.needChair;
        }
        public bool getBoard()
        {
            return this.needBoard;
        }
        public bool getTable()
        {
            return this.needTable;
        }
        public bool getComputer()
        {
            return this.needComputer;
        }



        public DateTime getStartTime()
        {
            return this.startActivity;
        }

        public DateTime getendTime()
        {
            return this.endActivity;
        }

        public int getId()
        {
            return this.num;
        }


        public void addMaterial(MaterialsPerActivity mpa)
        {
            MaterialQuantity.Add(mpa);
        }

    }


}
