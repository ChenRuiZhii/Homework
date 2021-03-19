using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4._2
{
    class Program
    {
        static void Main(string[] args)
        {
            Count count = new Count();
            count.clock1.SetTime(0);
        }
    }

    public delegate void Tick(object sender,Time args);
    public class Time
    {
        public int Second { get; set; }
    }
    public delegate void Alarm(object sender);

    public class Clock
    {
        public event Tick tick;
        public event Alarm alarm;

        public void SetTime(int s)
        {
            Console.WriteLine($"时间是：{s}秒");
            Time args = new Time()
            {
                Second = s
            };
            tick(this,args);
            alarm(this);
        }
    }

    public class Count

    {
        public Clock clock1 = new Clock();

        public Count()
        {
            clock1.tick += tick1;
            clock1.tick += tick2;
            clock1.tick += tick3;
            clock1.alarm += new Alarm(alarm1);
        }
        void tick1(object sender, Time args)
        {
            Console.WriteLine("Tick!Is' 1 now");
        }
        void tick2(object sender, Time args)
        {
            Console.WriteLine("Tick!Is' 2 now");
        }
        void tick3(object sender, Time args)
        {
            Console.WriteLine("Tick!Is' 3 now");
        }
        void alarm1(object sender)
        {
            Console.WriteLine("Alarm!");
        }
    }
}
