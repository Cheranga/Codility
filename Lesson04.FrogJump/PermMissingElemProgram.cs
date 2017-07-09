using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson03.TimeComplexity.PermMissingElem
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = new[] {2,3,1,5};

            
            
            var result = new Solution().solution(numbers);
        }
    }


    class Solution
    {
        public int solution(int[] A)
        {
            long indexSum = 0;
            long arraySum = 0;
            var index = 0;

            for (; index < A.Length; index++)
            {
                indexSum += index+1;
                arraySum += A[index];
            }

            indexSum += (index+1);

            return (int) (indexSum - arraySum);
        }
    }
}
