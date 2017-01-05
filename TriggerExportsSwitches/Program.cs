using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using BL;

namespace TriggerExportsSwitches
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string[] login = File.ReadAllLines("login");
            string[] switches = File.ReadAllLines("Switches");
            //trigger telnet session from code and store files
            foreach (string @switch in switches)
            {
                Telnlet.ReadmeExample(@switch, login[0], login[1]);
                Thread.Sleep(2000);
            }
        }
    }
}
