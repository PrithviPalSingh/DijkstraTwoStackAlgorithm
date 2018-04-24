using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DijkstraTwoStackAlgorithm
{
    /// <summary>
    /// (1+((2+3)*(4*5)))
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            var str = Console.ReadLine();
            Evaluate(str);
            Console.Read();
        }

        private static void Evaluate(string str)
        {
            Stack<string> Operators = new Stack<string>();
            Stack<int> Operands = new Stack<int>();

            while (!string.IsNullOrWhiteSpace(str))
            {
                if (int.TryParse(str, out int value))
                {
                    Operands.Push(value);
                }
                else
                {
                    if (str == "(")
                    {
                    }
                    else if (str == ")" && Operands.Count > 1)
                    {
                        var item1 = Operands.Pop();
                        var item2 = Operands.Pop();
                        var op = Operators.Pop();

                        switch (op)
                        {
                            case "+":
                                Operands.Push(item1 + item2);
                                break;
                            case "*":
                                Operands.Push(item1 * item2);
                                break;
                            case "/":
                                Operands.Push(item1 / item2);
                                break;
                            case "-":
                                Operands.Push(item1 - item2);
                                break;
                        }
                    }
                    else
                    {
                        Operators.Push(str);
                    }
                }

                str = Console.ReadLine();
            }

            Console.WriteLine(Operands.Pop());
        }
    }
}
