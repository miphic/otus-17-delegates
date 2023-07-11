using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Data.SqlTypes;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Main
{
    static public class Ext
    {
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="e"></param>
        /// <param name="getParameter"> функция извлекающая данные для сравнения из класса</param>
        /// <returns></returns>
        public static T GetMax<T>(this IEnumerable e, Func<T, float> getParameter)
            where T : class
        {
            var elems = e.OfType<T>();
            if (!elems.Any())
                throw new ArgumentException("список пустой!");
            T max = elems.First();
            foreach (T item in elems.Skip(1))
                if (getParameter(item) > getParameter(max) )
                    max = item;
            return max;
        }
    }
}
