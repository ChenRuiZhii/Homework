using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._2
{
    class Program
    {
        static void Main(string[] args)
        {
            ArrayCalculator arrayCalculator = new ArrayCalculator();
            arrayCalculator.Input();
            arrayCalculator.Max();
            arrayCalculator.Min();
            arrayCalculator.Sum();
            arrayCalculator.Average();
            arrayCalculator.Output();
        }
    }
    class ArrayCalculator
    {
        int[] data;
        int num;
        int max;
        int min;
        double average;
        int sum;
        public void Input()
        {
            string s;
            Console.Write("请输入需要运算的数据数量：");
            s = Console.ReadLine();
            this.num = Int32.Parse(s);
            data = new int[num];
            Console.Write("请依次输入数据，每一个数据后回车以完成输入：\n");
            for (int i = 0; i < num; i++)
            {
                s = Console.ReadLine();
                this.data[i] = int.Parse(s);
            }
        }

        public void Output()
        {
            Console.WriteLine("最大值：\n");
            Console.WriteLine(max);
            Console.WriteLine("最小值：\n");
            Console.WriteLine(min);
            Console.WriteLine("所有元素之和：\n");
            Console.WriteLine(sum);
            Console.WriteLine("平均值：\n");
            Console.WriteLine(average);

        }
        public int Max()
        {
            max = data[0];
            for (int i = 1; i < num; i++)
            {
                if (max < data[i])
                    max = data[i];
            }
            return max;
        }
        public int Min()
        {
            min = data[0];
            for (int i = 1; i < num; i++)
            {
                if (min > data[i])
                    min = data[i];
            }
            return min;
        }

        public int Sum()
        {
            for (int i = 0; i < num; i++)
            {
                sum += data[i];
            }
            return sum;
        }
        public double Average()
        {
            average = (double)sum / num;
            return average;
        }

    }
}
