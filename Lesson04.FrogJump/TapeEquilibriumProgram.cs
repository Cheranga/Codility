using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson03.TimeComplexity.TapeEquilibrium
{
    public class TapeEquilibriumProgram
    {
        static void Main(string[] args)
        {
            var array = new[] {3,-1,-2, 4,14,6};
            var result2 = new Solution().solution(array);
        }
    }

    public class Solution
    {
        public int solution(int[] A)
        {
            if (A == null || A.Any() == false)
            {
                return 0;
            }

            if (A.Length == 1)
            {
                return Math.Abs(A[0]);
            }
            if (A.Length == 2)
            {
                return Math.Abs(A[0] - A[1]);
            }

            var sum = A.Sum();
            var leftSum = A[0];
            var rightSum = sum - leftSum;
            var min = Math.Abs(leftSum - rightSum);

            for (var index = 1; index < A.Length - 1; index++)
            {
                var currentValue = A[index];
                leftSum += currentValue;
                rightSum -= currentValue;
                var difference = Math.Abs(rightSum - leftSum);

                if (difference < min)
                {
                    min = difference;
                }
            }

            return min;

        }
    }
}
