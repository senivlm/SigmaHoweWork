namespace CalculatorHomeWork22
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string expr = "sin(-1/2*3)";
            Calculator mather = new Calculator(expr);
            Console.WriteLine($"Entered: {mather.Infix}");
            Console.WriteLine($"Polish: {mather.Postfix}");
            Console.WriteLine($"Result: {mather.Calculate()}");
        }
    }
    internal class Calculator
    {
        internal string Infix { get; private set; }
        internal string Postfix { get; private set; }

        private Dictionary<char, int> operationPriority = new()
        {
            { '(', 0 },
            { '+', 1 },
            { '-', 1 },
            { '*', 2 },
            { '/', 2 },
            { '^', 3 },
            { '~', 4 },
            { 's', 1 },
            { 'c', 1}
        };

        internal Calculator(string expression)
        {
            Infix = expression;
            Postfix = ToPostfix(Infix + "\r");
        }
        private string GetStringNumber(string expr, ref int pos)
        {
            string strNumber = "";
            for (; pos < expr.Length; pos++)
            {
                char num = expr[pos];
                if (Char.IsDigit(num))
                {
                    strNumber += num;
                }
                else
                {
                    pos--;
                    break;
                }
            }
            return strNumber;
        }
        private string ToPostfix(string infixExpr)
        {
            string postfix = "";
            Stack<char> stack = new();

            for (int i = 0; i < infixExpr.Length; i++)
            {
                char c = infixExpr[i];

                if (Char.IsDigit(c))
                {
                    postfix += GetStringNumber(infixExpr, ref i) + " ";
                }
                else if (c == '(')
                {
                    stack.Push(c);
                }
                else if (c == ')')
                {
                    while (stack.Count > 0 && stack.Peek() != '(')
                    {
                        postfix += stack.Pop();
                    }
                    stack.Pop();
                }
                else if (operationPriority.ContainsKey(c))
                {
                    char op = c;
                    if (op == '-' && (i == 0 || (i > 1 && operationPriority.ContainsKey(infixExpr[i - 1]))))
                    {
                        op = '~';
                    }
                    while (stack.Count > 0 && (operationPriority[stack.Peek()] >= operationPriority[op]))
                    {
                        postfix += stack.Pop();
                    }
                    stack.Push(op);
                }
            }
            foreach (char op in stack)
            {
                postfix += op;
            }
            return postfix;
        }
        private double Execute(char op, double first, double second) => op switch
        {
            '+' => first + second,
            '-' => first - second,
            '*' => first * second,
            '/' => first / second,
            '^' => Math.Pow(first, second),
            's' => Math.Sin(first),
            'c' => Math.Cos(first),
            _ => 0
        };
        private double Execute(char op, double last) => op switch
        {
            's' => Math.Sin(last),
            'c' => Math.Cos(last),
            _ => 0
        };
        internal double Calculate()
        {
            Stack<double> locals = new();

            for (int i = 0; i < Postfix.Length; i++)
            {
                char c = Postfix[i];

                if (Char.IsDigit(c))
                {
                    string number = GetStringNumber(Postfix, ref i);
                    locals.Push(Convert.ToDouble(number));
                }
                else if (operationPriority.ContainsKey(c))
                {
                    if (c == '~')
                    {
                        double last = locals.Count > 0 ? locals.Pop() : 0;
                        locals.Push(Execute('-', 0, last));
                        continue;
                    }
                    if (c == 's' || c == 'c')
                    {
                        double last = locals.Count > 0 ? locals.Pop() : 0;
                        locals.Push(Execute(c, last));
                        continue;

                    }
                    double second = locals.Count > 0 ? locals.Pop() : 0,
                    first = locals.Count > 0 ? locals.Pop() : 0;

                    locals.Push(Execute(c, first, second));
                }
            }
            return locals.Pop();
        }
    }
}