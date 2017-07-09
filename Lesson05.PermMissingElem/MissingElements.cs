using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson05.PermMissingElem
{
    public class MissingElements
    {
        public int GetMissingElement(int[] array)
        {
            if (array == null || array.Any() == false)
            {
                return 0;
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


                if (numberArray.Length == 1 || numberArray.Length ==2)
                {
                    return numberArray.Last() - 1;
                }

                var arrayMid = size/2;
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


























        public int GetMissingElement(int[] array, int startIndex = 0)
        {
            //
            // Handle edge cases
            //
            if (array == null || array.Any() == false)
            {
                return 0;
            }
            //
            // Sort the array first
            //
            var list = new List<int>(array);
            if (startIndex == 0)
            {
                list.Sort();
            }
            //
            // If the first element is not "1" that's the missing number
            //
            if (startIndex == 0)
            {
                if (list.First() != 1)
                {
                    return 1;
                }
            }
            //
            // If the last element is the same as the length of the array, there is no missing element
            //
            var isLastValueSameAsLength = list.Last() == list.Count;
            if (isLastValueSameAsLength)
            {
                return 0;
            }
            //
            // If there are only two elements, then the difference between them gives the missing number
            //
            if (list.Count == 2)
            {
                return list.Last() - 1;
            }

            var mid = list.Count == 3 ? 2 : list.Count / 2;
            var expectedMidValue = Math.Abs(mid + startIndex);
            var isSameToMid = list[mid - 1] == expectedMidValue;
            //
            // If it's the same as "mid" then the right array will be considered
            //
            if (isSameToMid)
            {
                var rightArray = list.Skip(mid).ToArray();
                var leftRightDifference = rightArray.First() - list[mid - 1];
                if (leftRightDifference > 1)
                {
                    return rightArray.First() - 1;
                }

                return GetMissingElement(rightArray, mid);
            }

            var leftArray = list.Take(mid).ToArray();


            return GetMissingElement(leftArray, mid * -1);
        }
    }
}
