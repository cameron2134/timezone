using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Timezone
{
    public class Parser : IParser
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
            bool areInputsValid = ValidateInputs(time, timezone, out Tuple<DateTime, TimeZoneInfo> validatedInputs);
            if (!areInputsValid) return;

            try
            {
                DateTime convertedTime = TimeZoneInfo.ConvertTime(validatedInputs.Item1, _ukTimeZoneInfo, validatedInputs.Item2);
                Console.WriteLine($"The time in the UK is {validatedInputs.Item1.ToString("HH:mm")} " +
                $"and the time in {timezone} is {convertedTime.ToString("HH:mm")}");
            }

            catch (ArgumentException argEx)
            {
                Console.WriteLine($"Error: Invalid argument for ConvertTime - {argEx}");
            }

            catch (Exception ex)
            {
                Console.WriteLine($"Error: Unable to display time conversion for timezone {timezone} - {ex}");
            }
        }

        private bool ValidateInputs(string time, string timezone, out Tuple<DateTime, TimeZoneInfo> timezoneData)
        {
            timezoneData = null;

            bool isValidDateTime = DateTime.TryParse(time, out DateTime parsedUkTime);
            if (!isValidDateTime)
            {
                Console.WriteLine($"Error: Could not parse time {time} - not a valid DateTime.");
                return false;
            }

            if (string.IsNullOrWhiteSpace(timezone))
            {
                Console.WriteLine($"Error: Timezone does not contain data.");
                return false;
            }

            // Use the DisplayName to attempt to find the relevant timezone as we cannot be sure what format it will
            // be received in.
            TimeZoneInfo parsedTimeZoneInfo = _systemTimeZones.FirstOrDefault(o => o.DisplayName.Contains(timezone));
            if (parsedTimeZoneInfo == null)
            {
                Console.WriteLine($"Error: Could not find timezone {timezone} in system time zone list.");
                return false;
            }

            timezoneData = new Tuple<DateTime, TimeZoneInfo>(parsedUkTime, parsedTimeZoneInfo);
            return true;
        }
    }
}
