using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication2
{
    public class Material
    {
        private int serialNum;
        private string type;



        public Material(int serialNum, string type)
        {
            this.serialNum = serialNum;
            this.type = type;

            Program.Materials.Add(this);
        }

        public int getSerialNumber()
        {
            return this.serialNum;
        }

        public string getTypeOfMaterial()
        {
            return this.type;
        }

    }
}