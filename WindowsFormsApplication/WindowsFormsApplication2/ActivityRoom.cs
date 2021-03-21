using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication2
{
    public class ActivityRoom
    {
        private int roomId;
        private int maxParticipants;
        private bool isChair;
        private bool isTable;
        private bool isBoard;
        private bool isComputer;
        private RoomStatus status;
        private List<TechnicalFailure> TechnicalFailures;


        public ActivityRoom(int roomId, int maxParticipants, bool isChair, bool isTable, bool isBoard, bool isComputer, RoomStatus status )
        {
            this.roomId = roomId;
            this.maxParticipants = maxParticipants;
            this.isChair = isChair;
            this.isTable = isTable;
            this.isBoard = isBoard;
            this.isComputer = isComputer;
            this.status = status;
            TechnicalFailures= new List<TechnicalFailure>();
        }

        public int getId()
        {
            return this.roomId;
        }

        public RoomStatus getStatus()
        {
            return this.status;
        }

        public bool getIsChair()
        {
            return this.isChair;
        }


        public bool getisTable()
        {
            return this.isTable;
        }
        public bool getisBoard()
        {
            return this.isBoard;
        }
        public bool getisCopmuter()
        {
            return this.isComputer;
        }
        public void addToTechnichalList(TechnicalFailure tf)
        {
            TechnicalFailures.Add(tf);

        }
    }
}
