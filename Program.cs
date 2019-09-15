using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Timezone
{
    class Program
    {        
        static void Main(string[] args)
        {
            Parser timeZoneParser = new Parser();
            Reader fileReader = new Reader();
            List<Tuple<string, string>> lTimes = fileReader.Read();

            foreach (Tuple<string, string> timeZone in lTimes)
            {
                timeZoneParser.DisplayTime(timeZone.Item1, timeZone.Item2);
            }

            Console.WriteLine($"{Environment.NewLine}Press any key to exit.");
            Console.ReadKey();
        }
    }
}
