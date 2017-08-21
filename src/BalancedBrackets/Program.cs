using System;
using System.Collections.Generic;

namespace BalancedBrackets
{
    class Program
    {
        private static readonly char[] LeftBrackets = { '{', '(', '[' };
        private static readonly char[] RightBrackets = { '}', ')', ']' };
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
            Console.WriteLine($"Is this bracket ballanced? {input}");
            Console.WriteLine($"{IsBalanced(input)}!");
            Console.ReadLine();
        }

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