using System;
using System.Collections.Generic;

namespace BalancedBrackets
{
    class Program
    {
        private static readonly Dictionary<char, char> BracketMap = new Dictionary<char, char>()
        {
            {'}', '{'},
            {']', '['},
            {')', '('}
        };

        static void Main(string[] args)
        {
            Console.WriteLine("Enter your brackets - ie {{[]]]((( :");
            var input = Console.ReadLine();
            Console.WriteLine($"Is this bracket balanced? {input}");
            Console.WriteLine($"{IsBalanced(input)}!");
            Console.ReadLine();
        }

        /**************************************************************************************************************************************
         * 
         * Uses a stack to solve the problem. If the bracket doesn't exist push onto the stack. If the bracket does exist, pop it off the stack.
         * Keep doing this until you reach the last bracket. Afterwards if the stack is empty, the string is balanced.
         * 
         **************************************************************************************************************************************/
        private static bool IsBalanced(string source)
        {
            Stack<char> brackets = new Stack<char>();

            foreach (char bracket in source)
            {
                if (BracketMap.ContainsValue(bracket))
                    brackets.Push(bracket);

                if (BracketMap.ContainsKey(bracket) && (brackets.Count == 0 || brackets.Pop() != BracketMap[bracket]))
                    return false;
            }

            return brackets.Count == 0;
        }
    }
}