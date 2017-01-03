using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class CalcData
    {
        private List<Interface> _data;


        public string Name { get; set; }
        public int InterfacesFree { get; set; }
        public int InterfacesOccupied { get; set; }

        public CalcData(List<Interface> data)
        {
            _data = data;
        }




    }
}
