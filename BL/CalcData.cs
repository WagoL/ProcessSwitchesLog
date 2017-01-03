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
        private readonly List<Interface> _data;


        public string Switch { get; set; }
        public int InterfacesFree { get; set; }
        public int InterfacesOccupied { get; set; }
        public int TotalPorts { get; set; }

        public CalcData(List<Interface> data, string @switch)
        {
            _data = data;
            Switch = @switch;
        }

        public void Calc()
        {
            countInterfaces();
            calcTotalPorts();
        }

        private void calcTotalPorts()
        {
            TotalPorts = InterfacesFree + InterfacesOccupied;
        }

        private void countInterfaces()
        {
            foreach (Interface @interface in _data)
            {
                if (!(@interface.Name.StartsWith("Vlan") || @interface.Name.StartsWith("Port"))) //check if the interface is not channeld or an vlan interface with ip
                    if (@interface.Protocol.Equals("down"))
                        InterfacesFree++;
                    else
                        InterfacesOccupied++;
            }
        }

        public new string ToString()
        {
            return Switch + " has "+ InterfacesFree + " free ports and is using " + InterfacesOccupied + " ports, with a total of " + TotalPorts + " ports";
        }

    }
}
