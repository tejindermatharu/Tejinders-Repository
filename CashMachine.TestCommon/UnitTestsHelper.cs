using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashMachine.TestCommon
{
    public static class UnitTestsHelper
    {
        public const int InitialBalance =  343800;

        public static Dictionary<int, int> CashItems
        {
            get {
                var _cashItems = new Dictionary<int, int>()
            {
                {1, 100},
                {2, 100},
                {5, 100},
                {10, 100},
                {20, 100},
                {50, 100},
                {100, 100},
                {200, 100},
                {500, 10},
                {1000, 10},
                {2000, 20},
                {5000, 50}
            };

                return _cashItems;
            }
        }
    }
}
