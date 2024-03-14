using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class MathCalcs
    {
        public int CalculateLCM(List<int> numbers)
        {
            int lcm = numbers[0];
            for (int i = 1; i < numbers.Count; i++)
            {
                lcm = LCM(lcm, numbers[i]);
            }
            return lcm;
        }

        private int LCM(int a, int b)
        {
            return (a / GCD(a, b)) * b;
        }

        private int GCD(int a, int b)
        {
            while (b != 0)
            {
                int temp = b;
                b = a % b;
                a = temp;
            }
            return a;
        }
    }
}
