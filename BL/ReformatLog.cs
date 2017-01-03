using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class ReformatLog
    {
        /* Log file  */
        /* **Interface              IP-Address      OK? Method Status                Protocol**   */
        /* **GigabitEthernet1/0/1   unassigned      YES unset  up                    up      **   */

        private readonly string _path;
        private string _text;

        public ReformatLog(string fileName)
        {
            _path = fileName;
            loadUpText();
        }

        private void loadUpText()
        {
            try
            {
                _text = File.ReadAllText(_path);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        public void Format()
        {
            replace();
        }

        private void replace()
        {
            findAndReplaceAll(" ", ";");
            findAndReplaceAll(";;;;;;;;;;;;;;;;;;;;", ";");
            findAndReplaceAll(";;;;;;;;;;;;;;;;;;", ";");
            findAndReplaceAll(";;;;;;;;;;;;;;;;", ";");
            findAndReplaceAll(";;;;;;;;;;;;;;", ";");
            findAndReplaceAll(";;;;;;", ";");
            findAndReplaceAll(";;;;", ";");
            findAndReplaceAll(";;;", ";");
            findAndReplaceAll(";;", ";");
            findAndReplaceAll("administratively;down", "administratively down");
            findAndReplaceAll("Protocol","Protocol;");
            findAndReplaceAll(";",",");
        }

        private void findAndReplaceAll(string find, string replace)
        {
            _text = _text.Replace(find, replace);
            saveFile();
        }

        private void saveFile()
        {
            try
            {
                File.WriteAllText(_path,_text);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
    }
}
