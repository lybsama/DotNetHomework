using System;
namespace calculator
{
    class Program
    {
        public static void Main(string[] args)
        {
            float a, b = 0;
            string x, y, z;
            Console.WriteLine("����һ������");
            x = Console.ReadLine();
            a = float.Parse(x);
            Console.WriteLine("���������(+ - * /)");
            y = Console.ReadLine();
            Console.WriteLine("������һ������");
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