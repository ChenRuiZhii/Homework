using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._4
{
    class Program
    {
        static void Main(string[] args)
        {
            Toeplitz toeplitz = new Toeplitz();
            toeplitz.Input();
            toeplitz.Output();
        }
    }

    class Toeplitz
    {
        int m;
        int n;
        int[,] array;

        public void Input()
        {
            Console.WriteLine("请输入矩阵的行、列：");
            string s;
            s=Console.ReadLine();
            m = int.Parse(s);
            s = Console.ReadLine();
            n = int.Parse(s);
            array = new int[m,n];
            Console.WriteLine("请依次输入每一个数据：");
            for(int i=0;i<m;i++)
            {
                for(int j=0;j<n;j++)
                {
                    s=Console.ReadLine();
                    array[i,j] = int.Parse(s);
                }
            }
        }
        public bool WheatherToeplitz()
        {
            for(int i=0;i<m-1; i++)
            {
                for(int j=0;j<n-1;j++)
                {
                    if (array[i, j] != array[i + 1, j + 1]) return false;
                }
            }
            return true;
        }
        public void Output()
        {
            if (WheatherToeplitz())
                Console.WriteLine("这是一个托普利茨矩阵！");
            else
                Console.WriteLine("这不是一个托普利茨矩阵！");


        }
    }
}
