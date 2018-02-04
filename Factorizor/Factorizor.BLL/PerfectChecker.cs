using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factorizor.BLL
{
    public class PerfectChecker
    {
        public bool IsPerfect(int number, List<int> factors)
        {
            int sum = 0;
            for(int i =0; i < factors.Count(); i++)
            {
                sum += factors[i];
            }
            if(sum == number)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
