using System;
using System.Collections.Generic;
using System.Linq;
using Timezone.Properties;

namespace Timezone
{
    class Reader : IReader<string>
    {
        public List<Tuple<string, string>> Read()
        {
            List<Tuple<string, string>> timezoneList = new List<Tuple<string, string>>();

            string[] fileParts = Resources.Timezone.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

            foreach (string part in fileParts)
            {
                string[] timezoneLineParts = part.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                if (timezoneLineParts.Length < 2)
                {
                    Console.WriteLine($"Error: cannot read {part} - time and/or timezone is missing.");
                    continue;
                }

                Tuple<string, string> timeZone = new Tuple<string, string>(timezoneLineParts.First(), timezoneLineParts.Last());

                timezoneList.Add(timeZone);
            }

            return timezoneList;
        }
    }
}
