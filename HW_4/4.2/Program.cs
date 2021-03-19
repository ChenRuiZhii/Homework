using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4._2
{
    class Program
    {
        static void Main(string[] currentTime)
        {
            Count count = new Count();
            count.clock1.SetTime(23,59,57);
            count.clock1.AlarmScond = 3;
            count.clock1.AlarmMinute = 0;
            count.clock1.AlarmHour = 0;
            count.clock1.Run();
        }
    }

    public delegate void Tick(object sender,Time currentTime);
    public class Time
    {
        public int Second { get; set; }
        public int Hour { get; set; }
        public int Minute { get; set; }
    }
    public delegate void Alarm(object sender);

    public class Clock
    {
        public event Tick tick;
        public event Alarm alarm;
        public int AlarmScond { get; set; }
        public int AlarmMinute { get; set; }
        public int AlarmHour { get; set; }
        Time currentTime = new Time();
        public void SetTime(int h, int m,int s)
        {
            currentTime.Hour = h;
            currentTime.Minute = m;
            currentTime.Second = s;
        }


        public void Run()
        {
           while(true)
            {
                if (currentTime.Second < 59)
                {
                    currentTime.Second += 1;
                }
                else
                {
                    currentTime.Second = 0;
                    if (currentTime.Minute < 59)
                    {
                        currentTime.Minute += 1;
                    }
                    else
                    {
                        currentTime.Minute = 0;
                        if (currentTime.Hour < 23)
                            currentTime.Hour += 1;
                        else
                            currentTime.Hour = 0;
                    }
                }
                


                tick(this, currentTime);
                Console.WriteLine($"时间是：{currentTime.Hour}时{currentTime.Minute}分{currentTime.Second}秒");
                if((AlarmScond == currentTime.Second) &&(AlarmMinute == currentTime.Minute) && (AlarmHour == currentTime.Hour))
                    alarm(this);
                System.Threading.Thread.Sleep(1000);
            }

        }
    }

    public class Count

    {
        public Clock clock1 = new Clock();

        public Count()
        {
            clock1.tick += tick1;
            clock1.alarm += new Alarm(alarm1);
        }
        void tick1(object sender, Time currentTime)
        {
            Console.WriteLine("Tick!");
        }
  
        void alarm1(object sender)
        {
            Console.WriteLine("Alarm! Alarm! Alarm!Alarm! Alarm! Alarm!");
        }
    }
}
