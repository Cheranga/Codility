using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson03.TimeComplexity.FrogJump
{
    class FrogJumpProgram
    {
        static void Main(string[] args)
        {
            var result = new Solution().solution(10, 85, 30);
        }
    }

    class Solution
    {
        public int solution(int X, int Y, int D)
        {
            //
            // If the start and the destinations are the same (and of course 'D' is always greater than zero)
            //
            if (X == Y)
            {
                return 0;
            }

            var distance = Y - X;

            var requiredJumps = (distance / D) + (distance % D == 0 ? 0 : 1);

            return requiredJumps;
        }
    }
}
