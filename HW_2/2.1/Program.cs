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
            prime.Factors();
            prime.Output();

        }
    }

    class PrimeNumber
    {
        int num;//素数因子数量
        int dividing;//正在被分割为因子的数据
        int data;//存放初始数据
        int[] dataRest;//存放素数因子数据的数组
        public void Input()
        {
            string s;
            Console.Write("请输入数据，将为您展示前十个素数因子：\n");
            s = Console.ReadLine();
            data = int.Parse(s);
        }
        
        public void Output()
        {
            Console.WriteLine("该组数据中的素数因子如下所示：\n");
            for (int i = 0; i < num; i++)
            {
                Console.WriteLine(dataRest[i]);
            }
        }

        public void Factors()
        {
            dividing = data;
            num = 0;
            dataRest = new int[10];
            
            for (int i=2;i<=10;i++)
            {
                if (dividing % i == 0)
                {
                    dataRest[num] = i;
                    num++;
                }
                while (dividing % i == 0) dividing = dividing / i;
            }
        }

       /* public bool Judge (float x )
        {
            while (x == 1) return false;
            while (x == 2) return true;
            for(int i=2; i<x; i++)
            {
                while (x % i == 0) return false;
            }
            return true;
        }*/

        /*public void Choose()
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
        }*/

    }
}
