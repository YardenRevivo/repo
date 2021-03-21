using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication2
{
    public class MaterialsPerActivity
    {
        private Activity activityId;
        private Material serialNum;
        private int quantity;
        private int id;

        public MaterialsPerActivity(Activity activityId, Material serialNum, int quantity, int id)
        {
            this.activityId = activityId;
            this.serialNum = serialNum;
            this.quantity = quantity;
            this.id = id;
        }
    }
}