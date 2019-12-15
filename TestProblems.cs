using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Diagnostics;

namespace LeetConsoleApp
{
    [TestClass]
    internal class TestProblems
    {
        private Problems problems;

        public TestProblems()
        {
            this.ClearInstances();
        }

        [TestCleanup]
        [TestCategory("Easy")]
        [TestCategory("Array")]
        private void ClearInstances()
        {
            problems = null;
        }

        [TestMethod]
        [TestCategory("Easy")]
        [TestCategory("Array")]
        public void TestTwoSum()
        {
            problems = Problems.getInstance();

            int target = 7;
            int[] numbers = { 3, 3, 4, 3 };
            int[] indicies = null;

            Console.WriteLine("Two Sum \n Find the sum i.e. " + target + " form the array " + problems.printArray(numbers) + " and display indicies of those numbers.");

            indicies = problems.TwoSum(numbers, target);

            Console.WriteLine("Indicies that match the target of " + target + " are " + indicies[0] + " and " + indicies[1]);

            this.ClearInstances();
            return;
        }

        [TestMethod]
        [TestCategory("Easy")]
        [TestCategory("Array")]
        [TestCategory("HashMap")]
        public void TestTwoSumII()
        {
            problems = Problems.getInstance();

            int target = 9;
            int[] numbers = { 2, 7, 11, 15 };
            int[] indicies = null;

            Console.WriteLine("Two Sum II \n Find the sum i.e. " + target + " form the sorted array " + problems.printArray(numbers) + " and display non-zero based indicies of those numbers.");
            Stopwatch stopWatch = Stopwatch.StartNew();

            indicies = problems.TwoSumII(numbers, target);

            stopWatch.Stop();
            Console.WriteLine("Time Elapsed : {0}", stopWatch.Elapsed);
            stopWatch = null;
            
            if (indicies != null)
                Console.WriteLine("Indicies that match the target of " + target + " are " + problems.printArray(indicies));

            this.ClearInstances();
            return;
        }

        [TestMethod]
        [TestCategory("Easy")]
        [TestCategory("BST")]
        public void TestTwoSumIV()
        {
            TreeNode treeNode = new TreeNode(5);

            TreeNode leftTN = new TreeNode(3);
            leftTN.left = new TreeNode(2);
            leftTN.right = new TreeNode(4);


            TreeNode rightTN = new TreeNode(6);
            rightTN.right = new TreeNode(7);

            treeNode.left = leftTN;
            treeNode.right = rightTN;

            int target = 28;

            problems = Problems.getInstance();
            Console.WriteLine("Two Sum IV \n Find if the sum of " + target + " results by adding 2 nodes in the provided Binary Search Tree.");
            Stopwatch stopWatch = Stopwatch.StartNew();

            bool result = problems.TwoSumIV(treeNode, target);

            stopWatch.Stop();
            Console.WriteLine("Time Elapsed : " + stopWatch.Elapsed);
            stopWatch = null;

            Console.WriteLine("Found Sum of 2 nodes as {0} = {1}", target, result);

            this.ClearInstances();
            return;
        }

        [TestMethod]
        [TestCategory("Medium")]
        [TestCategory("LinkedList")]
        public void AddTwoNumbers()
        {
            ListNode number1 = new ListNode(2);
            number1.next = new ListNode(4);
            number1.next.next = new ListNode(3);

            ListNode number2 = new ListNode(5);
            number2.next = new ListNode(6);
            number2.next.next = new ListNode(4);

            problems = Problems.getInstance();
            Console.WriteLine("Add Two Numbers \n Two LinkedList have numbers in reverse order. Add 2 numbers and produce the result as LinkedList in reverse order.");
            Stopwatch stopWatch = Stopwatch.StartNew();

            problems.AddTwoNumbers(number1, number2);

            stopWatch.Stop();
            Console.WriteLine("Time Elapsed : " + stopWatch.Elapsed);
            stopWatch = null;

            //Console.WriteLine("Found Sum of 2 nodes as {0} = {1}", target, result);

            this.ClearInstances();
            return;
        }


    }
}
