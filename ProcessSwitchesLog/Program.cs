using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL;

namespace ProcessSwitchesLog
{
    public class Program
    {
        public static void Main(string[] args)
        {
            ConvertToObjects converter = new ConvertToObjects(@"C:\tmp\picanol-nf-la-03_02012017.csv");
            int j = 10;
        }
    }
}
