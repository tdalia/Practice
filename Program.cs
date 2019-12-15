using System;
using System.Diagnostics;

namespace LeetConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            TestProblems testCases = new TestProblems();

            // Two sum
            //testCases.TestTwoSum();

            //testCases.TestTwoSumII();

            //testCases.TestTwoSumIV();

            testCases.AddTwoNumbers();

            testCases = null;
            Console.ReadLine();
        }
    }
}
