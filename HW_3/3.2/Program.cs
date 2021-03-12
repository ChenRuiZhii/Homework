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
            Shape squ = ShapeFactory.CreatShape("Sqare", 11, 11);
            Console.WriteLine(rec.Area() + tri.Area() + squ.Area());//啊这
        }
    }
    interface Shape
    {
        double Area();

    }

    class Rectangle : Shape
    {
        private double width;
        private double height;
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
        public static Shape CreatShape(String shape,double width,double height )
        {
            if ("Sqare".Equals(shape)) return new Square(width);
            else if ("Rectangle".Equals(shape)) return new Rectangle(width, height);
            else if ("Triangle".Equals(shape)) return new Triangle(width, height);
            else return null;
        }
    }
}
