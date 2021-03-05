using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._1
{
    class Program
    {
        static void Main(string[] args)
        {
            PrimeNumber prime = new PrimeNumber();
            prime.Input();
            prime.Choose();
            prime.Output();

        }
    }

    class PrimeNumber
    {
        int num;//初始输入数组中的数据个数
        int numRest;//素数的个数
        int[] data;//存放初始数据
        int[] dataRest;//存放数组数据
        public void Input()
        {
            string s;
            Console.Write("请输入需要运算的数据数量：");
            s = Console.ReadLine();
            this.num = Int32.Parse(s);
            data= new int[num];
            Console.Write("请依次输入数据，每一个数据后回车以完成输入：\n");
            for(int i=0;i<num;i++)
            {
                s = Console.ReadLine();
                this.data[i] = int.Parse(s);
            }
        }
        
        public void Output()
        {
            Console.WriteLine("该组数据中的素数如下所示：\n");
            for (int i = 0; i < numRest; i++)
            {
                Console.WriteLine(dataRest[i]);
            }
        }

        public bool Judge (float x )
        {
            while (x == 1) return false;
            while (x == 2) return true;
            for(int i=2; i<x; i++)
            {
                while (x % i == 0) return false;
            }
            return true;
        }

        public void Choose()
        {
            numRest = 0;
            dataRest = new int[num];

            for (int j =0;j<num;j++)
            {
                if(Judge(data[j]))
                {
                    dataRest[numRest] = data[j];
                    numRest++;
                }
               
            } 
        }

    }
}
