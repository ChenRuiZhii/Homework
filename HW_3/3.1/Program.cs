using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3._1
{
    class Program
    {
        static void Main(string[] args)
        {
            Rectangle rectangle = new Rectangle(3.5,4);
            Square square = new Square(5.4);
            Triangle triangle = new Triangle(5.2,2);
            if(rectangle.IsLegal())
                Console.WriteLine("合法的长方形！");
            else Console.WriteLine("合法的长方形！");
            if (square.IsLegal())
                Console.WriteLine("合法的正方形！");
            else Console.WriteLine("非法的正方形！");

            if (triangle.IsLegal())
                Console.WriteLine("合法的三角形！");
            else Console.WriteLine("非法的三角形！");

            Console.WriteLine(rectangle.Area());
            Console.WriteLine(square.Area());
            Console.WriteLine(triangle.Area());
        }
    }
    interface Shape
    {
        bool IsLegal();
        double Area();

    }

    class Rectangle : Shape
    {
        private double width;
        private double height;
        public double Width {
            get => width;
            set => width = value;
        }
        public double Height {
            get => height;
            set => height = value;
        }


        public Rectangle(double width,double height)
        {
            this.width = width;
            this.height = height;
        }
        public bool IsLegal()
        {
            if (width >= 0 && height >= 0)
            { 
                return true;

            }
            else
            {
                return false;
            }
        }
        public double Area()
        {
            
                return width * height;
           
        }
    }

    class Square : Rectangle
    {
        public Square(double side) : base(side, side) { }
     
    }

    class Triangle :Shape
    {
        double width;
        double height;
        public double Width
        {
            get => width;
            set => width = value;
        }
        public double Height
        {
            get => height;
            set => height = value;
        }

        public Triangle(double wid,double hei)
        {
            width = wid;
            height = hei;
        }
        public bool IsLegal()
        {
            if (width >= 0 && height >= 0)
            {
                return true;

            }
            else
            {
                return false;
            }
        }
        public double Area()
        {
            return 0.5 * width * height;
        }
    }
}
