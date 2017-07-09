using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson05.PermMissingElem
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = new[] {1,4};

            
            
            var result = new Solution().solution(numbers);
        }
    }


    class Solution
    {
        public int solution(int[] array)
        {
            if (array == null)
            {
                return 0;
            }
            if (array.Any() == false)
            {
                return 1;
            }

            var numberOfItems = array.Length;

            var list = new List<int>(array);
            list.Sort();
            //
            // Sanity checks
            //
            var isWithinBounds = list.First() >= 1 &&
                                 (list.Last() == numberOfItems || list.Last() == numberOfItems + 1);

            if (isWithinBounds == false)
            {
                return 0;
            }
            if (list.First() == 1 && list.Last() == list.Count)
            {
                return 0;
            }
            if (list.First() != 1 && list.Last() == list.Count + 1)
            {
                return 1;
            }
            //
            // Do the recursive check
            //
            Func<int, int, int[], int> recursive = null;
            recursive = (start, size, numberArray) =>
            {
                var first = numberArray.First();
                var last = numberArray.Last();

                if (first == start && last == numberOfItems)
                {
                    return 0;
                }
                if (first != start && last == size + 1)
                {
                    return 1;
                }


                if (numberArray.Length == 1 || numberArray.Length == 2)
                {
                    return numberArray.Last() - 1;
                }

                var arrayMid = size / 2;
                var expectedArrayMid = start + arrayMid;
                var actualArrayMid = numberArray[arrayMid];

                if (expectedArrayMid < actualArrayMid)
                {
                    numberArray = numberArray.Take(arrayMid + 1).ToArray();
                }
                else
                {
                    numberArray = numberArray.Skip(arrayMid).ToArray();
                }


                return recursive(numberArray.First(), numberArray.Length, numberArray);
            };

            var result = recursive(list.First(), list.Count, list.ToArray());
            return result;
        }
    }
}
