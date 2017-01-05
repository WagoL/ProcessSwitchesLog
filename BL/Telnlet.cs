using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using PrimS.Telnet;

namespace BL
{
    public class Telnlet
    {

        public static async Task ReadmeExample(string endpoint, string login, string password)
        {
            string s;
            using (Client client = new Client(endpoint, 23, new System.Threading.CancellationToken()))
            {
                client.IsConnected.Should().Be(true);
                (await client.TryLoginAsync(login, password, 3000)).Should().Be(true);
                client.WriteLine("sh ip int brief");
                s = await client.TerminatedReadAsync(">", TimeSpan.FromMilliseconds(3000));
                Console.Write(s);
            }
            string switchName = s.Substring(s.IndexOf("belugh", StringComparison.Ordinal)).Replace(">", "") + "_" + string.Format("{0:yyyyMMdd_HHmmss}", DateTime.Now);
            s = DeleteLines(s, 1);
            s = DeleteLines(s, 1, true);
            File.WriteAllText(switchName,s);
        }

        public static string DeleteLines(string stringToRemoveLinesFrom, int numberOfLinesToRemove, bool startFromBottom = false)
        {
            string toReturn = "";
            string[] allLines = stringToRemoveLinesFrom.Split(
                separator: Environment.NewLine.ToCharArray(),
                options: StringSplitOptions.RemoveEmptyEntries);
            if (startFromBottom)
                toReturn = String.Join(Environment.NewLine, allLines.Take(allLines.Length - numberOfLinesToRemove));
            else
                toReturn = String.Join(Environment.NewLine, allLines.Skip(numberOfLinesToRemove));
            return toReturn;
        }
    }


}

