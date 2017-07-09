using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson02.Arrays.OddOccurency
{
    class Program
    {
        static void Main(string[] args)
        {
            var result = new Solution().solution(new[] { 9, 3, 9, 3, 9, 7, 9 });
        }
    }

    class Solution
    {
        public int solution(int[] A)
        {
            // write your code in C# 6.0 with .NET 4.5 (Mono)

            if (A == null)
            {
                throw new ArgumentNullException("A", "Passed array is null");
            }
            if (A.Any() == false)
            {
                throw new Exception("Array does not contain any numbers");
            }

            if (A.Length == 1)
            {
                return A[0];
            }

            var list = A.GroupBy(num => num).Select(key => new
            {
                key.Key,
                KeyCount = key.Count()
            }).ToList();

            var item = list.Single(x => x.KeyCount % 2 > 0);
            return item.Key;


        }
    }
}
