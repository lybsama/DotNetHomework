using System;
namespace Problem02
{
    static class Program
    {
        static void Main()
        {
        int num = 0; int max=0, min=0, sum = 0; float ave = 0;
        string Num;
            int[] a1;
            a1 = new int[10];
            Console.WriteLine("输入一个10位整数数组");
            for (int i = 0; i < 10; i++)
            {
                Num = Console.ReadLine();
                num = int.Parse(Num);
                a1[i] = num;
            }
            for (int i = 1; i < num; i++)
            {
                if (max < a1[i])
                    max = a1[i];
                if (min > a1[i])
                    min = a1[i];
                sum += a1[i];
            }
            ave = (float)sum / num;
            Console.WriteLine("该数组最大值是" + max);
            Console.WriteLine("该数组最小值是" + min);
            Console.WriteLine("该数组平均数是" + ave);
            Console.WriteLine("该数组总和是" + sum);

        }
    }
}