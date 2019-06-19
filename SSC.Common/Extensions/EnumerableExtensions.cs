using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.Collections.Generic
{
    public static class EnumerableExtensions
    {
        public static void ForEach<T>(this IEnumerable<T> subject, Action<T> closure)
        {
            foreach (var item in subject)
                closure(item);
        }
    }
}
