using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson01.Iterations
{
    class Program
    {
        static void Main(string[] args)
        {
            var gap = new Solution().solution(int.MaxValue);
        }
    }

    class Solution
    {
        public int solution(int n)
        {
            var binaryRepresenrationText = Convert.ToString(n, 2);

            var indexLocations = binaryRepresenrationText.Select((character, index) => character == '1' ? index : -1)
                .Where(index => index >= 0);

            var gap = 0;
            indexLocations.Aggregate((a, b) =>
            {
                var currentGap = b - a;
                if (currentGap >= gap)
                {
                    gap = currentGap;
                }

                return b;
            });

            return gap > 0 ? gap - 1 : 0;
        }
    }
}
