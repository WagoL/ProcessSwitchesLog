using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper;

namespace BL
{
    public class ConvertToObjects
    {
        private List<Interface> _intList = new List<Interface>();
        public List<Interface> Interfaces { get { return _intList; } set { _intList = value; } }
        public string Name { get; set; }

        public ConvertToObjects(string filepath)
        {
            CsvReader csv = new CsvReader(new StringReader(File.ReadAllText(filepath)));
            while (csv.Read())
            {
                _intList.Add(new Interface
                {
                    Name = csv.GetField<string>("Interface"),
                    IpAddress = csv.GetField<string>("IP-Address"),
                    Method = csv.GetField<string>("Method"),
                    Ok = csv.GetField<string>("OK?"),
                    Protocol = csv.GetField<string>("Protocol"),
                    Status = csv.GetField<string>("Status")
                });
            }
            Name = stripFilePath(filepath);
        }

        private string stripFilePath(string absoluteFilePath)
        {
            //c:\tmp\picanol-psi-la-07_03012017
            string retString =absoluteFilePath.Remove(0,7);
            return retString.Remove(retString.Length-20);
        }
    }
}
