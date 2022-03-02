using System;
namespace program01
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int num = 0;
            string Num ;
            Console.WriteLine("键入一个正整数");
            Num=Console.ReadLine();
            num=int.Parse(Num);
            Console.WriteLine("它的所有素数因子为：");
            for(int i = 2; i <= num; i++)
            {
                while(num % i== 0)
                {
                    Console.WriteLine(i);
                    num = num / i;
                }
            }
        }
    }
}
