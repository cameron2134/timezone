using System;
using System.Collections.Generic;
using System.Linq;
using Timezone.Properties;

namespace Timezone
{
    public class Reader : IReader<string>
    {
        public List<Tuple<string, string>> Read(string inputFile)
        {
            List<Tuple<string, string>> timezoneList = new List<Tuple<string, string>>();

            if (string.IsNullOrWhiteSpace(inputFile)) return timezoneList;

            string[] fileParts = inputFile.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

            foreach (string part in fileParts)
            {
                string[] timezoneLineParts = part.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                if (timezoneLineParts.Length != 2)
                {
                    Console.WriteLine($"Error: cannot read {part} - missing or too much data.");
                    continue;
                }

                Tuple<string, string> timeZone = new Tuple<string, string>(timezoneLineParts.First(), timezoneLineParts.Last());

                timezoneList.Add(timeZone);
            }

            return timezoneList;
        }
    }
}
