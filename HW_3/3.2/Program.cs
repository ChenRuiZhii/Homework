using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3._2
{
    class Program
    {
        static void Main(string[] args)
        {
            Shape rec = ShapeFactory.CreatShape("Rectangle", 12.5, 8);
            Shape tri = ShapeFactory.CreatShape("Triangle",12.5, 8);
            Shape squ = ShapeFactory.CreatShape("Sqare", 11, 11);//创建三个自主创建的形状
            if (!rec.IsLegal() || !tri.IsLegal() || !squ.IsLegal())
            {
                Console.WriteLine("出现非法！");
                return;
                    }
            Console.WriteLine("自主创建的形状面积之和：");
            Console.WriteLine(rec.Area() + tri.Area() + squ.Area());
            Shape randomShape;

            double area;
            area = 0;
            for(int i=0;i<10;i++)
            {
                randomShape = ShapeFactory.CreateRandom();
                area += randomShape.Area();
            }
            Console.WriteLine("随机创建的形状面积之和：");
            Console.WriteLine(area);
        }
    }
    interface Shape
    {
        double Area();
        bool IsLegal();
    }

    class Rectangle : Shape
    {
        private double width;
        private double height;
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
        public Rectangle(double width, double height)
        {
            this.width = width;
            this.height = height;
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

    class Triangle : Shape
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
        public Triangle(double wid, double hei)
        {
            width = wid;
            height = hei;
        }

        public double Area()
        {
            return 0.5 * width * height;
        }
    }

    class ShapeFactory
    {
        readonly static Random rd = new Random();

        public static Shape CreateRandom()
        {
            
            int a = rd.Next(1, 3);
            int w, h;
            switch (a)
            {
                case 1:
                    w = rd.Next(1, 3);
                    return new Square(w);
                case 2:
                    w = rd.Next(1, 3);
                    h = rd.Next(1, 3);
                    return new Rectangle(w, h);
                case 3:
                    w = rd.Next(1, 3);
                    h = rd.Next(1, 3);
                    return new Triangle(w, h);
                default :
                    return null;
            }

        }

        public static Shape CreatShape(String shape,double width,double height )
        {
            if ("Sqare".Equals(shape) && width == height) return new Square(width);
            else if ("Rectangle".Equals(shape)) return new Rectangle(width, height);
            else if ("Triangle".Equals(shape)) return new Triangle(width, height);
            else return null;
        }
    }
}
