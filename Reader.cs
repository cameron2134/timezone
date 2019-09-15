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
            List<Tuple<string, string>> lReturn = new List<Tuple<string, string>>();

            string[] fileParts = Resources.Timezone.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

            foreach (string part in fileParts)
            {
                string[] sLineParts = part.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                Tuple<string, string> timeZone = new Tuple<string, string>(sLineParts.First(), sLineParts.Last());

                lReturn.Add(timeZone);
            }

            return lReturn;
        }
    }
}
