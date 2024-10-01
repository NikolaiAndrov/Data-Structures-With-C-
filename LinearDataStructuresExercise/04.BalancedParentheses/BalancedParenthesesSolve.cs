namespace Problem04.BalancedParentheses
{
    using System;
    using System.Collections.Generic;

    public class BalancedParenthesesSolve : ISolvable
    {
        public bool AreBalanced(string parentheses)
        {

            if (parentheses.Length % 2 != 0)
            {
                return false;
            }

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
