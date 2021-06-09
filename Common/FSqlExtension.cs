using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FreeSql;

namespace Common
{
    public static class ISelectExt
    {
        public static IEnumerable<T> AsEnumerable<T>(this ISelect<T> selectResult)
        {
            var i = 0;
            while (true)
            {
                var obj = selectResult.Skip(i++).Take(1).First();
                if (obj != null)
                {
                    yield return obj;
                }
                else
                {
                    break;
                }
            }
        }
    }
}
