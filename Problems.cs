﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Dynamic;
using System.Linq;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Security.Cryptography.X509Certificates;

namespace LeetConsoleApp
{
    internal class Problems
    {
        private Stopwatch stopWatch;

        private Problems()
        {
            stopWatch = null;
        }

        private static Problems Create()
        {
            Problems problems = new Problems();
            return problems;
        }

        public static Problems getInstance()
        {
            return Problems.Create();
        }

        internal string printArray<T>(T[] array)
        {
            string result = String.Format("[{0}]", string.Join(", ", array));

            return result;
        }

        /**
         * Two Sum  - https://leetcode.com/problems/two-sum/
         * 
         * Given an array of integers, return indices of the two numbers such that they add up to a specific target.
         * You may assume that each input would have exactly one solution, and you may not use the same element twice.
         * 
         * Given nums = [2, 7, 11, 15], target = 9,
         *   Because nums[0] + nums[1] = 2 + 7 = 9,
         *   return [0, 1].
         */
        public int[] TwoSum(int[] nums, int target)
        {
            stopWatch = Stopwatch.StartNew();

            int[] indices = new int[2] { 0, 0 };

            Dictionary<int, int> numbersDict = new Dictionary<int, int>();

            for (int i = 0, difference = 0; i < nums.Length; i++)
            {
                difference = target - nums[i];
                if (numbersDict.TryGetValue(difference, out int secondIndex))
                {
                    indices[1] = i;
                    indices[0] = secondIndex;

                    break;
                }

                if (!numbersDict.ContainsKey(nums[i]))
                {
                    numbersDict.Add(nums[i], i);
                }
            }

            stopWatch.Stop();
            Console.WriteLine("Time Elapsed : {0}", stopWatch.Elapsed);
            stopWatch = null;

            numbersDict = null;
            return indices;
        }

        /**
         * Two Sum II - https://leetcode.com/problems/two-sum-ii-input-array-is-sorted/
         * 
         * Given an array of integers that is already sorted in ascending order, find two numbers such that they add up to a specific target number.
         * The function twoSum should return indices of the two numbers such that they add up to the target, where index1 must be less than index2.
         * 
         * Your returned answers (both index1 and index2) are not zero-based.
         * You may assume that each input would have exactly one solution and you may not use the same element twice.
         */
        public int[] TwoSumII(int[] numbers, int target)
        {
            for (int leftIndex = 0, rightIndex = numbers.Length - 1, sum = 0; leftIndex < rightIndex;)
            {
                sum = numbers[leftIndex] + numbers[rightIndex];

                if (sum == target)
                {
                    return new int[] { leftIndex + 1, rightIndex + 1 };
                }

                if (sum > target)
                    --rightIndex;
                else
                    leftIndex++;
            }

            return null;
        }

        /**
         * Two Sum IV - Input is a BST - https://leetcode.com/problems/two-sum-iv-input-is-a-bst/
         * 
         *Given a Binary Search Tree and a target number, return true if there exist two elements in the BST such that their sum is equal to the given target.
         * 
         * Your returned answers (both index1 and index2) are not zero-based.
         * You may assume that each input would have exactly one solution and you may not use the same element twice.
         */
        public bool TwoSumIV(TreeNode root, int target)
        {
            /*
            // Method 1
            stopWatch = Stopwatch.StartNew();

            HashSet<int> set = new HashSet<int>();
            bool found = find_TwoSumIV(root, target, set);

            Console.WriteLine("Method 1 - Found Sum of 2 nodes as {0} = {1}", target, found);
            stopWatch.Stop();
            Console.WriteLine("Time Elapsed : " + stopWatch.Elapsed);

            Console.WriteLine("--------------");
            */

            // Method 2

            List<int> list = new List<int>();
            // Add all elements from Treenode to List in ascending order
            inorder_TwoSumIV(root, list);

            int left = 0, right = list.Count - 1, sum = 0;
            while(left < right)
            {
                sum = list[left] + list[right];
                if (sum == target)
                    return true;
                if (sum < target)
                    left++;
                else
                    // As list is in ascending order, this part is never reached
                    right--;
            }

            return false;
        }

        private bool find_TwoSumIV(TreeNode root, int target, HashSet<int> set)
        {
            if (root == null)
                return false;

            if (set.Contains(target - root.val))
                return true;
            set.Add(root.val);
            return find_TwoSumIV(root.left, target, set) || find_TwoSumIV(root.right, target, set);
        }

        private void inorder_TwoSumIV(TreeNode root, List<int> list)
        {
            if (root == null)
                return;
            inorder_TwoSumIV(root.left, list);
            list.Add(root.val);
            inorder_TwoSumIV(root.right, list);
        }

        /**
         * Add Two Numbers - https://leetcode.com/problems/add-two-numbers/
         * 
         * You are given two non-empty linked lists representing two non-negative integers. The digits are stored in reverse order and 
         * each of their nodes contain a single digit. Add the two numbers and return it as a linked list.
         * 
         * Input: (2 -> 4 -> 3) + (5 -> 6 -> 4)
         * Output: 7 -> 0 -> 8
         * Explanation: 342 + 465 = 807.          
         */
        public ListNode AddTwoNumbers(ListNode number1, ListNode number2)
        {

            // Trans Listnode to int[]  ==> [] {2, 4, 3}
            // Reverse the [] to int ==> {3, 4, 2} 342
            int firstNumber = ListNodeToInt(number1);
            int secondNumber = ListNodeToInt(number2);

            int sum = firstNumber + secondNumber;

            // Reverse the sum digits 
            IntToListNode(sum);
            // Add to Listnode

            return null;
        }

        // Convert the ListNode to number as int
        private int ListNodeToInt(ListNode list)
        {
            Stack<int> stack = new Stack<int>();
            do
            {
                stack.Push(list.val);
                list = list.next;
            } while (list != null);

            // convert Stack to array - Reverse the numbers
            int[] numbers = stack.ToArray();
            stack = null;
            int number = 0;
            // Convert int of the int[]
            for(int i = 0; i < numbers.Length; i++)
            {
                number += numbers[i] * Convert.ToInt32(Math.Pow(10, numbers.Length - i - 1));
            }
            Console.WriteLine("Number : " + number);
            numbers = null;

            return number;
        }

        // Convert digits of int in Listnode in reverse order
        // 807 == Output: 7 -> 0 -> 8
        private ListNode IntToListNode(int digits)
        {
            ListNode listNode = null;

            // Convert int to int[]  ==> {8, 0, 7}
            int[] digitsArr =  digits.ToString().Select(t => int.Parse(t.ToString())).ToArray<int>();

            Console.WriteLine("Number Arr = " + printArray(digitsArr));

            LinkedList<int> linkedList = new LinkedList<int>(digitsArr);

            listNode = new ListNode(linkedList.First.Value);
            listNode = null;
            ListNode node = null;
            ListNode headNode = listNode;
            for (int i=1; i < linkedList.Count; i++)
            {
                node = new ListNode(linkedList.ElementAt(i));
                node = null;
                headNode.next = node;
                headNode = node;
            }

            /*
            // Convert int[] to Stack ==> {7, 0, 8}
            Stack digitsStack = new Stack(digitsArr.Length);
            foreach(int i in digitsArr)
            {
                digitsStack.Push(i);
            }

            // Add elements of Stack to ListNode
            do
            {
                int i = (int)digitsStack.Pop();
                listNode = new ListNode(i);
            }*/

            return listNode;
        }

        /**
         * https://leetcode.com/contest/weekly-contest-181/problems/create-target-array-in-the-given-order/
         * 
         * Given two arrays of integers nums and index. Your task is to create target array under the following rules:
         * 
         * Initially target array is empty.
         *  From left to right read nums[i] and index[i], insert at index index[i] the value nums[i] in target array.
         *  Repeat the previous step until there are no elements to read in nums and index.
         *  Return the target array.
         * 
         * 
         * Input: nums = [1,2,3,4,0], index = [0,1,2,3,0]
         * Output: [0,1,2,3,4]
         * Explanation:
         * nums       index     target
         *  1            0        [1]
         *  2            1        [1,2]
         *  3            2        [1,2,3]
         *  4            3        [1,2,3,4]
         *  0            0        [0,1,2,3,4]
         * 
         * Constraints:
         * 
         *   1 <= nums.length, index.length <= 100
         *   nums.length == index.length
         *   0 <= nums[i] <= 100
         *   0 <= index[i] <= i
         */
         public int[] CreateTargetArray(int[] nums, int[] index)
         {
            var arrayList = new List<int>();
            for(int i=0; i < nums.Length; i++)
            {
                arrayList.Insert(index[i], nums[i]);
            }

            return arrayList.ToArray();
         }

        /*
         * Remove Duplicates from Sorted Array
         * https://leetcode.com/problems/remove-duplicates-from-sorted-array/
         * 
         * Given a sorted array nums, remove the duplicates in-place such that
         * each element appear only once and return the new length.
         *
         * Do not allocate extra space for another array, you must do this by 
         * modifying the input array in-place with O(1) extra memory.
         *
         * Eg 1: Given nums = [1,1,2],
         * Your function should return length = 2, with the first two elements 
         * of nums being 1 and 2 respectively.
         * 
         * It doesn't matter what you leave beyond the returned length.
         * 
         * Eg 2: Given nums = [0,0,1,1,1,2,2,3,3,4],
         * Your function should return length = 5, with the first five elements 
         * of nums being modified to 0, 1, 2, 3, and 4 respectively.
         */
        public int RemoveDuplicatesFromSortedArray(int[] nums)
        {
            if (nums.Length == 0)
                return 0;
            int val = nums[0];
            int prevIndex = 0;
            for(int i=1; i < nums.Length; i++)
            {
                if (val != nums[i])
                {
                    val = nums[i];
                    prevIndex++;
                    nums[prevIndex] = val;
                }
            }
            return 1+prevIndex;
        }

        /*
         * Remove Duplicates from Sorted Array
         * https://leetcode.com/problems/remove-duplicates-from-sorted-array-ii/
         * 
         * Given a sorted array nums, remove the duplicates in-place such that
         * duplicates appeared at most twice and return the new length.
         *
         * Do not allocate extra space for another array, you must do this by 
         * modifying the input array in-place with O(1) extra memory.
         *
         * Eg 1: Given nums = [1,1,1,2,2,3],
         * Your function should return length = 5, with the first five elements 
         * of nums being 1, 1, 2, 2 and 3 respectively.
         * 
         * It doesn't matter what you leave beyond the returned length.
         * 
         * Eg 2: Given nums = [0,0,1,1,1,1,2,3,3],
         * Your function should return length = 7, with the first seven elements 
         * of nums being modified to 0, 0, 1, 1, 2, 3 and 3 respectively.
         */
        public int RemoveDuplicatesFromSortedArray_II(int[] nums)
        {
            if (nums.Length == 0)  return 0;

            int length = 0, duplicates = 1, index = 0;

            while (index < nums.Length)
            {
                if (index > 0 && nums[index] == nums[index - 1])
                {
                    if (duplicates == 2)
                    {
                        index++;
                        continue;
                    }
                    else
                    {
                        nums[length] = nums[index];
                        duplicates++;
                    }
                }
                else
                {
                    nums[length] = nums[index];
                    duplicates = 1;
                }
                index++; length++;
            }
            return length;
        }
    }
}
