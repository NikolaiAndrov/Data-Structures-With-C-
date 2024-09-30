namespace Problem04.BalancedParentheses
{
    using System;
    using System.Collections.Generic;

    public class BalancedParenthesesSolve : ISolvable
    {
        public bool AreBalanced(string parentheses)
        {
            Stack<char> openParentheses = new Stack<char>();

            foreach (char ch in parentheses)
            {
                if (ch == '(' || ch == '{' || ch == '[')
                {
                    openParentheses.Push(ch);
                    continue;
                }

                char popped = default;

                try
                {
                    popped = openParentheses.Pop();
                }
                catch (Exception)
                {
                    return false;
                }

                if (popped == '(' && ch != ')' || 
                    popped == '{' && ch != '}' || 
                    popped == '[' && ch != ']')
                {
                    return false;
                }
            }

            return openParentheses.Count == 0;
        }
    }
}
