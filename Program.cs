using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Timezone.Properties;

namespace Timezone
{
    class Program
    {        
        static void Main(string[] args)
        {
            IParser timeZoneParser = new Parser();
            IReader<string> fileReader = new Reader();
            List<Tuple<string, string>> timezoneList = fileReader.Read(Resources.Timezone);

            foreach (Tuple<string, string> timeZone in timezoneList)
            {
                timeZoneParser.DisplayTime(timeZone.Item1, timeZone.Item2);
            }

            Console.WriteLine($"{Environment.NewLine}Press any key to exit.");
            Console.ReadKey();
        }
    }
}
