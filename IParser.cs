using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Timezone
{
    public interface IParser
    {
        void DisplayTime(string time, string timezone);
    }
}
