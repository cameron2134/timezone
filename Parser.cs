using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Timezone
{
    class Parser : IParser
    {
        private readonly TimeZoneInfo _ukTimeZoneInfo;
        private readonly IEnumerable<TimeZoneInfo> _systemTimeZones;

        public Parser()
        {
            _systemTimeZones = TimeZoneInfo.GetSystemTimeZones();
            _ukTimeZoneInfo = _systemTimeZones.FirstOrDefault(o => o.Id == "GMT Standard Time");
        }

        public void DisplayTime(string time, string timezone)
        {
            var isValidDateTime = DateTime.TryParse(time, out DateTime parsedUkTime);
            if (!isValidDateTime)
            {
                Console.WriteLine($"Error: Could not parse time {time} - not a valid DateTime.");
                return;
            }

            // Use the DisplayName to attempt to find the relevant timezone as we cannot be sure what format it will
            // be received in.
            var parsedTimeZoneInfo = _systemTimeZones.FirstOrDefault(o => o.DisplayName.Contains(timezone));
            if (parsedTimeZoneInfo == null)
            {
                Console.WriteLine($"Error: Could not find timezone {timezone} in system time zone list.");
                return;
            }

            var convertedTime = TimeZoneInfo.ConvertTime(parsedUkTime, _ukTimeZoneInfo, parsedTimeZoneInfo);
            Console.WriteLine($"The time in the UK is {parsedUkTime.ToString("HH:mm")} " +
                $"and the time in {timezone} is {convertedTime.ToString("HH:mm")}");
        }

    }
}
