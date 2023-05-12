
using System.Linq.Expressions;

namespace Calculator
{
    public static class Calculator
    {
        private static List<char> funcSymbols = new List<char>()
        {
            '+','-','*','/','^'
        };

        public static void Input(string expression)
        {
            try
            {
                ValidateInput(expression);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Непарвильное выражение, {e.Message}");
            }

            ProcessExpression(expression);
        }

        public static void ProcessExpression(string expression, int startIndex = 0)
        {
            for (int i = 0; i < expression.Length; i++)
            {
                foreach (char c in funcSymbols)
                {
                    if (c == expression[i])
                    {
                        CheckBetween(expression, i);
                    }
                }
            }

            try
            {
                
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private static void CheckBetween(string expression, int index)
        {
            bool isFindPreviousFunc;
            bool isFindNextFunc;
            int previousFuncIndex;
            int previousNumIndex;
            int nextFuncIndex;
            int nextNumIndex;

            float num1 = 0;
            float num2 = 0;
            float answer = 0;

            FindPreviousNum(expression, index, out previousNumIndex);
            FindPreviousFunc(expression, index, out isFindPreviousFunc, out previousFuncIndex);
            FindNextNum(expression, index, out nextNumIndex);
            FindNextFunc(expression, index, out isFindNextFunc, out nextFuncIndex);

            if (previousNumIndex == index)
            {
                if (isFindPreviousFunc)
                {

                }
                else if (previousFuncIndex == index)
                {
                    
                }
            }
            else
            {
                if (nextNumIndex == index)
                {
                    if (isFindNextFunc)
                    {

                    }
                    else if (nextFuncIndex == index)
                    {

                    }
                }
                else
                {
                    num1 = ConvertToNumber(expression, index, previousNumIndex);
                    num2 = ConvertToNumber(expression, index + 1, nextNumIndex); // Here
                }
            }
            Console.WriteLine(Math(expression[index], num1, num2));
        }

        private static float ConvertToNumber(string expression, int startIndex, int endIndex)
        {
            string num = "";

            if (startIndex > endIndex)
            {
                for (int i = endIndex; i < startIndex; i++)
                {
                    num += expression[i].ToString();
                }
            }
            else
            {
                for (int i = startIndex; i < endIndex; i++)
                {
                    num += expression[i].ToString();
                }
            }

            return float.Parse(num);
        }

        private static void FindPreviousFunc(string expression, int index, out bool isFindFunc, out int outIndex)
        {
            isFindFunc = false;
            outIndex = 0;

            if (index > 0)
            {
                for (int i = index; i > 0; i--)
                {
                    if (IsFuncSymbol(expression[i]))
                    {
                        isFindFunc = true;
                        outIndex = i;
                        break;
                    }
                }
            }
        }

        private static void FindPreviousNum(string expression, int index, out int outIndex)
        {
            outIndex = 0;

            if (index > 0)
            {
                for (int i = index - 1; i > 0; i--)
                {
                    if (IsFuncSymbol(expression[i]))
                    {
                        outIndex = i + 1;
                        break;
                    }
                }
            }
        }

        private static void FindNextFunc(string expression, int index, out bool isFindFunc, out int outIndex)
        {
            isFindFunc = false;
            outIndex = 0;

            for (int i = expression.Length - 1; i > index; i--)
            {
                if (IsFuncSymbol(expression[i]))
                {
                    isFindFunc = true;
                    outIndex = i;
                    break;
                }
            }
        }

        private static void FindNextNum(string expression, int index, out int outIndex)
        {
            outIndex = 0;

            for (int i = index + 1; i < expression.Length; i++)
            {
                if (IsFuncSymbol(expression[i]))
                {
                    outIndex = i;
                    break;
                }
            }

            if (outIndex == 0)
                outIndex = expression.Length;
        }

        private static bool IsFuncSymbol(char symbol)
        {
            foreach (char c in funcSymbols)
            {
                if (symbol == c)
                {
                    return true;
                }
            }

            return false;
        }

        private static float Math(char func, float a, float b)
        {
            switch (func)
            {
                case '+':
                    return a + b;
                case '-':
                    return a - b;
                case '*':
                    return a * b;
                case '/':
                    return a / b;
                default:
                    return 0;
            }
        }

        private static bool ValidateInput(string expression)
        {
            return true;
        }
    }
}
