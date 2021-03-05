using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._3
{
    class Program
    {
        static void Main(string[] args)
        {
            Eratosthenes eratosthenes = new Eratosthenes();
            eratosthenes.Input();
            eratosthenes.Sieve();
            eratosthenes.Output();
        }
    }
    class Eratosthenes/*埃拉托斯特尼筛法sieve of Eratosthenes*/
    {//采取用数组data[i]的0、1值来判定是否是素数，1为素数，0非素数！
        int num;//需要判定的范围为：2到num；
        int[] data;
        public void Input ()
        {
            string s;
            Console.Write("请输入需要运算的数据数量：");
            s = Console.ReadLine();
            this.num = Int32.Parse(s);
            num = num + 1;//逻辑序号与物理序号对应，方便之后的运算！
            if(num<2)
            {
                Console.Write("错误！即将默认为您计算2到100之内的素数！");
                num = 101;
            }
            data = new int[num];
        }
        public void Sieve()
        {
            int t;//作为从2开始递增的一个除数；
            for(int i=2;i<num;i++)
            {
                data[i] = 1;//先将初始属性全部设置为素数
            }
           for (t=2;t<num;t++)
            {
                for (int i = t+1; i < num; i++)
                {
                    if (i % t == 0) data[i] = 0;
                }
            }
        }
        public void Output()
        {
            int linefeed = 0;//用作换行标记！
            Console.WriteLine("素数如下：\n");
            for(int i=2;i<num;i++)
            {
                if (data[i] == 1)
                {
                    Console.Write(i + " ");
                    linefeed++;
                    if (linefeed % 5 == 0) Console.Write("\n");
                }
            }
        }
    }
}
