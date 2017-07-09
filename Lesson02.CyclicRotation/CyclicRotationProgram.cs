using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson02.Arrays.CyclicRotation
{
    class CyclicRotationProgram
    {
        static void Main(string[] args)
        {
            var array = new[]{ 3, 8, 9, 7, 6 };
            var result = new Solution().solution(array, 12);
        }
    }

    class Solution
    {
        public int[] solution(int[] A, int K)
        {
            if (A == null || A.Any() == false || K <= 0)
            {
                return A;
            }

            var arrayLength = A.Length;
            var remainder = K%arrayLength;
            var takeIndex = remainder == 0 ? (arrayLength - K) : (arrayLength - remainder);
            if (takeIndex <= 0)
            {
                return A;
            }

            var firstPortion = A.Take(takeIndex).ToArray();
            var secondPortion = A.Skip(takeIndex).ToArray();

            var finalArray = new int[arrayLength];
            Array.Copy(secondPortion, finalArray, secondPortion.Length);
            Array.Copy(firstPortion, 0,finalArray,secondPortion.Length, firstPortion.Length);

            return finalArray;
        }
    }
}
