using System.Text.RegularExpressions;

namespace StringIntegerCalculator_API.Extensions
{
    public static class StringExtension
    {
        public static bool IsValidMathExpression(this string expression)
        {
            // Defined a regular expression pattern for a valid expression
            string pattern = @"^\s*(\d+(\.\d+)?\s*[+\-*/]\s*)*\d+(\.\d+)?\s*$";

            // Using Regex.IsMatch to check if the expression matches the pattern
            return Regex.IsMatch(expression, pattern);
        }
    }
}
