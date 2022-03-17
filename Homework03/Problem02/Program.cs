using System;
namespace Problem02
{
    public abstract class Shape
    {
        public abstract double getArea();
        public abstract void setArea();
        public abstract string getType();
        
    }
    public class Rectangle : Shape
    {
        double width;double height;string type = "rectangle";
        public Rectangle() { }
        public Rectangle(double width,double height)
        {
            this.width = width;
            this.height = height;
        }
        public override string getType()
        {
            return type;
        }
        public override void setArea()
        {
            Console.WriteLine("Enter the width:");
            string Width =Console.ReadLine();
            Console.WriteLine("Enter the height:");
            string Height =Console.ReadLine();

        }
        public override double getArea()
        {
            return width * height;
            throw new NotImplementedException();
        }
    }

    class Square : Shape
    {
        double side; string type = "square";
        public Square() { }
        public Square(double side)
        {
            this.side = side;
        }
        public override void setArea()
        {
            Console.WriteLine("Enter the side:");
            string Side = Console.ReadLine();
        }
        public override string getType()
        {
            return type;
        }
        public override double getArea()
        {
            return side * side;
        }
    }
    public class Triangle :Shape
    {
        double side1, side2, side3;
        string type = "triangle";
        public Triangle() { }
        public Triangle(double side1, double side2, double side3)
        {
            this.side1 = side1;
            this.side2 = side2;
            this.side3 = side3;
        }
        public override void setArea()
        {
            Console.WriteLine("Enter the side1:");
            string Side1=Console.ReadLine();
            Console.WriteLine("Enter the side2:");
            string Side2=Console.ReadLine();
            Console.WriteLine("Enter the side3:");
            string Side3=Console.ReadLine();
        }
        public override string getType()
        {
            return type;
        }
        public override double getArea()
        {
            if (((side1 + side2) > side3) && ((side1 + side3) > side2) && ((side2 + side3) > side1) && (side1 > 0) && (side2 > 0) && (side3 > 0))
            {
                return Math.Sqrt(((side1 + side2 + side3) / 2) * (((side1 + side2 + side3) / 2) - side1) * (((side1 + side2 + side3) / 2) - side2) * (((side1 + side2 + side3) / 2) - side3));
            }
            else
            {
                return 0;
            }
        }
    }
    public class ShapeFactory
    {
        public static Shape MakeShape(int name, double width, double height, double side, double side1, double side2,double side3)
        { 
            switch (name)
            {
                case 1:
                    return new Rectangle(width,height);
                    break;
                case 2:
                    return new Square(side);
                    break;
                case 3:
                    return new Triangle(side1,side2,side3);
                    break;
                default:
                    return null;
                    //throw new InvalidOperationException("Invalid");
            }
        }
    }
    public class Program
    {
        public static void Main(params string[] args)
        {
            double Sum = 0;
            int i = 0;
            Random ran = new Random();
            while (i < 10)
            {
                int name = ran.Next(1,4);

                double width = ran.Next(10);

                double height = ran.Next(10);

                double side = ran.Next(10);

                double side1 = ran.Next(10);

                double side2 = ran.Next(10);

                double side3 = ran.Next(10);
                Shape shape = ShapeFactory.MakeShape(name, width, height, side,side1,side2,side3);
                if (shape != null)
                {
                    Console.WriteLine("生成：{0}\n面积为：{1}", shape.getType(), shape.getArea().ToString());
                    Sum += shape.getArea();
                    i++;
                }
            }
            Console.WriteLine("面积和为：{0}", Sum.ToString());
            Console.ReadKey();
        }
    }
}