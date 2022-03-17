using System;
namespace problem02
    {
        public delegate void TickHandler(object sender, TickEvent e);

        public class TickEvent
        {
            public int timeLeft { get; set; }
        }

        public class Clock
        {
            public event TickHandler OnTick;
            public void Tick(int tleft)
            {
                Console.WriteLine("开始倒计时：");
                TickEvent args = new TickEventArgs() { timeLeft = tleft };
                OnTick(this, args);


            }
        }

        public class Tick
        {
            public Clock clock1 = new Clock();
            public Tick()
            {
                clock1.OnTick += new TickHandler(clk_OnTick);
                clock1.OnTick += clk_OnTick2;
            }

            void clk_OnTick(object sender, TickEvent args)
            {
                while (args.timeLeft > 0)
                {
                    Console.WriteLine("剩余时间:{0}", args.timeLeft);
                    System.Threading.Thread.Sleep(1000);
                    args.timeLeft -= 1;
                }
            }

            void clk_OnTick2(object sender, TickEvent args)
            {
                while (args.timeLeft == 0)
                {
                    Console.WriteLine("响铃");
                    args.timeLeft = -1;
                }
            }
        }


        class Program02
        {
            static void Main(string[] args)
            {
                Tick tick1 = new Tick();
                tick1.clock1.Tick(10);
                Console.ReadKey();
            }
        }
    }
}