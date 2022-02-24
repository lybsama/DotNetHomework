using System;
namespace calculator
{
    class Program
    {
        public static void Main(string[] args)
        {
            float a, b = 0;
            string x, y, z;
            Console.WriteLine("键入一个数字");
            x = Console.ReadLine();
            a = float.Parse(x);
            Console.WriteLine("键入运算符(+ - * /)");
            y = Console.ReadLine();
            Console.WriteLine("键入另一个数字");
            z = Console.ReadLine();
            b = float.Parse(z);
            Console.WriteLine("The answer is ");
            if (y == "+") Console.WriteLine(a + b);
            if (y == "-") Console.WriteLine(a - b);
            if (y == "*") Console.WriteLine(a * b);
            if (y == "/") Console.WriteLine(a / b);

        }
    }
}