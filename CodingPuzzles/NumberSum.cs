using System;
using System.Collections.Generic;
using System.Linq;

namespace CodingPuzzles
{
    public class NumberSum
    {
        /// <summary>
        /// 给定整数的一个数组，找出这样的两个数，它们的加和等于一个特定的目标数字
        /// </summary>
        /// <param name="numbers"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public static bool TwoSum(int[] numbers, int target)
        {
            if (numbers == null || numbers.Length < 2)
                return false;
            Array.Sort(numbers);

            var low_index = 0;
            var high_index = numbers.Length - 1;
            while (low_index < high_index)
            {
                var sum = numbers[low_index] + numbers[high_index];
                if (sum == target)
                {
                    return true;
                }
                if (sum < target)
                {
                    low_index++;
                }
                else
                {
                    high_index--;
                }
            }

            return false;
        }

        /// <summary>
        /// 给定一个正整数的集合，找出其中所有组合，满足和为target
        /// [2,3,6,7] target=7 (item_reused=true)
        /// [7]
        /// [2,2,3]
        /// </summary>
        /// <param name="candidates"></param>
        /// <param name="target"></param>
        /// <param name="item_reused"></param>
        /// <returns></returns>
        public static List<int[]> CombinationSum(int[] candidates, int target, bool item_reused)
        {
            if (candidates == null || candidates.Length == 0)
                return new List<int[]>();
            var result = new List<int[]>();
            Array.Sort(candidates);
            for (int i = 0; i < candidates.Length; i++)
            {
                GetCombinations(i, candidates, target, result, item_reused);
            }
            return result;
        }

        private static void GetCombinations(int start_index, int[] candidates, int target, List<int[]> result, bool item_reused)
        {
            var queue = new Queue<List<int>>();
            var list = new List<int> {candidates[start_index]};
            queue.Enqueue(list);
            while (queue.Count > 0)
            {
                var to_theck = queue.Dequeue();
                var sum = to_theck.Sum();

                if (sum == target)
                {
                    result.Add(to_theck.ToArray());
                    continue;
                }
                if (sum > target) continue;
                if (!item_reused) start_index++;
                for (int i = start_index; i < candidates.Length; i++)
                {
                    var candidate_list = new List<int>(to_theck) {candidates[i]};
                    queue.Enqueue(candidate_list);
                }
            }
        }


    }
}