using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication2
{
    class EmbedActivityToActivityRoom
    {
        private int embededId;
        private ActivityRoom roomId;
        private Activity activityId;

        public EmbedActivityToActivityRoom(int embededId, ActivityRoom roomId, Activity activityId)
        {
            this.embededId = embededId;
            this.roomId = roomId;
            this.activityId = activityId;

            Program.EmbedActivitiesToActivityRooms.Add(this);
        }

        public Activity getactivity()
        {
            return this.activityId;
        }

        public ActivityRoom getActivityRoom()
        {
            return this.roomId;
        }

    
        public static List<ActivityRoom> availableRooms(Activity act) //פונקציה המקבלת פעילות ומחזירה רשימת חדרים פנויים
        {
            List<ActivityRoom> notEmbeded = new List<ActivityRoom>();
            foreach (EmbedActivityToActivityRoom room in Program.EmbedActivitiesToActivityRooms)
            {
                if (room.getactivity().getStartTime() != act.getStartTime())
                {
                    if (room.getActivityRoom().getisBoard() == act.getBoard() && room.getActivityRoom().getIsChair() == act.getChair() && room.getActivityRoom().getisCopmuter() == act.getComputer() && room.getActivityRoom().getisTable() == act.getTable())
                    {
                        if (!notEmbeded.Contains(room.getActivityRoom()))
                        {
                            notEmbeded.Add(room.getActivityRoom());
                        }
                    }
                }
            }
            return notEmbeded;
        }


    }
}
