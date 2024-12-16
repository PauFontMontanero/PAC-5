using System;

namespace PAC5___Calculadora
{
    public class CalculadoraCore
    {
        /// <summary>
        /// Calculates the result of a mathematical expression
        /// </summary>
        /// <param name="expression">The expression to calculate</param>
        /// <returns>The result as a string, or "Error" if invalid</returns>
        public string Calcula(string expression)
        {
            try
            {
                if (string.IsNullOrEmpty(expression))
                    throw new ArgumentException("Expression cannot be empty");

                // Remove spaces from expression
                expression = expression.Replace(" ", "");

                // Validate expression
                ValidateExpression(expression);

                // Handle parentheses first
                while (expression.Contains("("))
                {
                    int closeIndex = expression.IndexOf(')');
                    if (closeIndex == -1)
                        throw new FormatException("Unmatched parentheses");

                    int openIndex = expression.LastIndexOf('(', closeIndex);
                    if (openIndex == -1)
                        throw new FormatException("Unmatched parentheses");

                    string subExpression = expression.Substring(openIndex + 1, closeIndex - openIndex - 1);
                    string subResult = CalculateBasicExpression(subExpression);

                    expression = expression.Substring(0, openIndex) + subResult + expression.Substring(closeIndex + 1);
                }

                return CalculateBasicExpression(expression);
            }
            catch (DivideByZeroException)
            {
                throw;
            }
            catch (InvalidOperationException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new FormatException($"Invalid expression: {ex.Message}");
            }
        }

        private string CalculateBasicExpression(string expression)
        {
            // Handle square roots
            while (expression.Contains("√"))
            {
                int sqrtIndex = expression.IndexOf('√');
                int endIndex = FindNumberEnd(expression, sqrtIndex + 1);

                // Check if there's anything after the √
                if (sqrtIndex + 1 >= expression.Length)
                    throw new FormatException("Missing number after square root");

                string number = expression.Substring(sqrtIndex + 1, endIndex - (sqrtIndex + 1));

                double value;
                if (!double.TryParse(number, out value))
                {
                    throw new FormatException("Invalid number format");
                }

                if (value < 0)
                {
                    throw new InvalidOperationException("Cannot calculate square root of negative number");
                }

                string sqrtResult = Math.Sqrt(value).ToString();
                expression = expression.Substring(0, sqrtIndex) + sqrtResult + expression.Substring(endIndex);
            }

            // Split into parts and calculate
            String[] parts = ButcherOperation(expression);

            // Handle powers first
            for (int i = 1; i < parts.Length; i += 2)
            {
                if (parts[i] == "^")
                {
                    double a = double.Parse(parts[i - 1]);
                    double b = double.Parse(parts[i + 1]);
                    parts[i - 1] = Math.Pow(a, b).ToString();
                    parts[i] = "";
                    parts[i + 1] = "";
                    parts = ResizeArray(parts);
                    i = -1;
                }
            }

            // Then multiplication and division
            for (int i = 1; i < parts.Length; i += 2)
            {
                if (parts[i] == "*" || parts[i] == "/")
                {
                    String result = Operator(parts[i - 1], parts[i + 1], parts[i]);
                    parts[i - 1] = result;
                    parts[i] = "";
                    parts[i + 1] = "";
                    parts = ResizeArray(parts);
                    i = -1;
                }
            }

            // Finally addition and subtraction
            for (int i = 1; i < parts.Length; i += 2)
            {
                if (parts[i] == "+" || parts[i] == "-")
                {
                    String result = Operator(parts[i - 1], parts[i + 1], parts[i]);
                    parts[i - 1] = result;
                    parts[i] = "";
                    parts[i + 1] = "";
                    parts = ResizeArray(parts);
                    i = -1;
                }
            }

            return parts[0];
        }

        private void ValidateExpression(string expression)
        {
            // Check for balanced parentheses
            int parenthesesCount = 0;
            for (int i = 0; i < expression.Length; i++)
            {
                if (expression[i] == '(') parenthesesCount++;
                else if (expression[i] == ')') parenthesesCount--;

                if (parenthesesCount < 0)
                    throw new FormatException("Invalid parentheses placement");
            }
            if (parenthesesCount != 0)
                throw new FormatException("Unmatched parentheses");

            // Check for invalid operator combinations
            string operators = "+-*/^";
            for (int i = 0; i < expression.Length - 1; i++)
            {
                if (operators.Contains(expression[i]) && operators.Contains(expression[i + 1]))
                    throw new FormatException("Invalid operator combination");
            }

            // Check for missing operators between parentheses or numbers
            for (int i = 0; i < expression.Length - 1; i++)
            {
                if ((char.IsDigit(expression[i]) && expression[i + 1] == '(') ||
                    (expression[i] == ')' && (char.IsDigit(expression[i + 1]) || expression[i + 1] == '(')))
                {
                    throw new FormatException("Missing operator between terms");
                }
            }

            // Check for invalid square root placement
            int sqrtIndex = expression.IndexOf('√');
            while (sqrtIndex != -1)
            {
                // Check if there's a number before the √
                if (sqrtIndex > 0 && char.IsDigit(expression[sqrtIndex - 1]))
                {
                    throw new FormatException("Square root operator must be placed before the number");
                }
                sqrtIndex = expression.IndexOf('√', sqrtIndex + 1);
            }
        }

        private int FindNumberEnd(string expression, int startIndex)
        {
            int i = startIndex;
            // Skip leading whitespace
            while (i < expression.Length && char.IsWhiteSpace(expression[i]))
                i++;

            // Handle negative numbers
            if (i < expression.Length && expression[i] == '-')
                i++;

            // Find the end of the number
            while (i < expression.Length && (char.IsDigit(expression[i]) || expression[i] == '.'))
                i++;

            return i;
        }

        private String[] ButcherOperation(String expression)
        {
            // First count the actual number of operators and numbers
            List<string> parts = new List<string>();
            string currentNumber = "";

            for (int i = 0; i < expression.Length; i++)
            {
                char character = expression[i];
                if (char.IsDigit(character) || character == '.' ||
                    (character == '-' && (i == 0 || !char.IsDigit(expression[i - 1]))))
                {
                    currentNumber += character;
                }
                else
                {
                    if (!string.IsNullOrEmpty(currentNumber))
                    {
                        parts.Add(currentNumber);
                        currentNumber = "";
                    }
                    parts.Add(character.ToString());
                }
            }

            // Add the last number if exists
            if (!string.IsNullOrEmpty(currentNumber))
            {
                parts.Add(currentNumber);
            }

            return parts.ToArray();
        }

        private String Operator(String a, String b, String o)
        {
            try
            {
                double result = 0;
                switch (o)
                {
                    case "+":
                        result = double.Parse(a) + double.Parse(b);
                        break;
                    case "-":
                        result = double.Parse(a) - double.Parse(b);
                        break;
                    case "*":
                        result = double.Parse(a) * double.Parse(b);
                        break;
                    case "/":
                        double divisor = double.Parse(b);
                        if (divisor == 0)
                            throw new DivideByZeroException();
                        result = double.Parse(a) / divisor;
                        break;
                    case "^":
                        result = Math.Pow(double.Parse(a), double.Parse(b));
                        break;
                }
                return result.ToString();
            }
            catch (DivideByZeroException)
            {
                throw;
            }
            catch
            {
                throw new FormatException("Invalid number format");
            }
        }

        private String[] ResizeArray(String[] butcheredOperation)
        {
            int count = 0;
            for (int i = 0; i < butcheredOperation.Length; i++)
            {
                if (!string.IsNullOrEmpty(butcheredOperation[i]))
                    count++;
            }

            String[] resizedArray = new String[count];
            int newIndex = 0;

            for (int i = 0; i < butcheredOperation.Length; i++)
            {
                if (!string.IsNullOrEmpty(butcheredOperation[i]))
                {
                    resizedArray[newIndex] = butcheredOperation[i];
                    newIndex++;
                }
            }

            return resizedArray;
        }
    }
}