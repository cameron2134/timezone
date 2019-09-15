using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Timezone
{
    interface IReader<T> where T: class
    {
        List<Tuple<T, T>> Read();
    }
}
