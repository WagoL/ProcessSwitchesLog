using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using BL;
using PrimS.Telnet;
using PrimS;

namespace ProcessSwitchesLog
{
    public class Program
    {
        public static void Main(string[] args)
        {
            /*//single conversion
            //format whitespace to csv
            ReformatLog format = new ReformatLog(@"C:\tmp\picanol-nf-lc-01_03012017");
            format.Format();
            //execute calculation
            ConvertToObjects converter = new ConvertToObjects(@"C:\tmp\picanol-nf-lc-01_03012017.csv");
            CalcData niceData = new CalcData(converter.Interfaces,converter.Name);
            niceData.Calc();
            Console.WriteLine(niceData.ToString());*/


            //batch conversion
            //conversion to csv from withspace file
            /*
            List<string> files = getFiles();
            foreach (string file in files)
            {
                ReformatLog format = new ReformatLog(file);
                format.Format();
            }
            List<string> filesCsv = getFiles("*.csv");

            //calculation
            foreach (string file in filesCsv)
            {
                ConvertToObjects converter = new ConvertToObjects(file);
                CalcData niceData = new CalcData(converter.Interfaces,converter.Name);
                niceData.Calc();
                Console.WriteLine(niceData.ToString());
            }
            Console.ReadLine();*/



        }

        private static List<string> getFiles()
        {
            List<string> files = new List<string>();
            DirectoryInfo d = new DirectoryInfo(@"C:\tmp");//Assuming Test is your Folder
            FileInfo[] Files = d.GetFiles(); //Getting  files
            foreach (FileInfo file in Files)
            {
                files.Add(file.FullName);
            }
            return files;
        }

        private static List<string> getFiles(string searchParam)
        {
            List<string> files = new List<string>();
            DirectoryInfo d = new DirectoryInfo(@"C:\tmp");//Assuming Test is your Folder
            FileInfo[] Files = d.GetFiles(searchParam); //Getting  files
            foreach (FileInfo file in Files)
            {
                files.Add(file.FullName);
            }
            return files;
        }


    }
}
