using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PW_LAB5.Tests
{
    public class ComparingClass
    {
        public static Comparer<U> GetComparer<U>(Func<U, U, bool> func)
        {
            return new Comparer<U>(func);
        }

    }

    public class Comparer<U> : ComparingClass, IEqualityComparer<U>
    {
        private Func<U, U, bool> comparisonFunction;
        public Comparer(Func<U, U, bool> func)
        {
            comparisonFunction = func;
        }
        public bool Equals(U x, U y)
        {
            return comparisonFunction(x, y);
        }

        public int GetHashCode([DisallowNull] U obj)
        {
            return obj.GetHashCode();
        }
    }

}
