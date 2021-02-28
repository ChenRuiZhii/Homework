using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1._1
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = " ";
            double a = 0;
            double b = 0;
            string c = " ";
            Console.Write("请输入第一个运算数字：");
            s = Console.ReadLine();
            a = Int32.Parse(s);
            Console.Write("请输入第二个运算数字：");
            s = Console.ReadLine();
            b = Int32.Parse(s);
            Console.Write("请输入一个运算符号：");
            c = Console.ReadLine();

            switch (c)
            {
                case "+":
                    Console.WriteLine($"{a} {c} {b} = {a + b}");
                    break;
                case "-":
                    Console.WriteLine($"{a} {c} {b} = {a - b}");
                    break;
                case "*":
                    Console.WriteLine($"{a} {c} {b} = {a * b}");
                    break;
                case "/":
                    Console.WriteLine($"{a} {c} {b} = {a / b}");
                    break;

            }
        }
    }
}
