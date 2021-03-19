using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4._1
{       
    class Program
    {

        static void Main(string[] args)
        {
            int max = int.MinValue;
            int min = int.MaxValue;
            int sum = 0;

            GenericList<int> genericList = new GenericList<int>();
            genericList.Add(1);
            genericList.Add(2);
            genericList.Add(3);
            genericList.Add(4);
            genericList.Add(6);
            genericList.Add(5);
            genericList.Add(7);

            genericList.ForEach(s => { if (max < s) max = s; });
            genericList.ForEach(s => { if (min > s) min = s; });
            genericList.ForEach(s => sum += s);

            Console.WriteLine("最大值：" + max);
            Console.WriteLine("最小值：" + min);
            Console.WriteLine("加  和：" + sum);
        }
    }
    public class Node<T>
    {
        public Node<T> Next { get; set; }
        public T Data { get; set; }
        public Node(T t)
        {
            Next = null;
            Data = t;
        }
    }

    public class GenericList<T>
    {
        private Node<T> head;
        private Node<T> tail;



        public GenericList()
        {
            tail = head = null;
        }
        public Node<T> Head
        {
            get => head;
        }
        public void Add(T t)
        {
            Node<T> n = new Node<T>(t);
            if (tail == null)
            {
                head = tail = n;
            }
            else
            {
                tail.Next = n;
                tail = n;
            }
        }

        public void ForEach(Action<T> action)
        {
            Node<T> p = head;
            while(p!=null)
            {
                action(p.Data);
                p = p.Next;
            }
        }
    }

}
