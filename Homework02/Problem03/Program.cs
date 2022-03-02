using System;
namespace Problem03
{
    public class Program
    {
        public static void Main(string[] args)
        {
            bool[] a = new bool[101];
            for (int i = 0; i < a.Length; i++)
            {
                a[i] = true;
            }
            for (int i = 2; i <= Math.Sqrt(100); i++)
            {
                if (a[i] == true)
                {
                    for (int j = 2; i * j <= 100; j++)
                    {
                        a[i * j] = false;
                    }
                }
            }
            for (int i = 2; i < 100; i++)
            {
                if (a[i] == true) Console.Write(i+" ");
            }
        }
    }
}
