using System;
namespace Problem01
{
    interface Area
    {
        void getArea();
    }
    abstract class isLegal
    {
        abstract public void Islegal();
    }
    class Rectangle : isLegal,Area
    {
        private int width;
        private int height; 
        public void setWidth(int width)
        {
            this.width = width;
        }
        public void setHeight(int height)
        {
            this.height = height;
        }
        public void getArea()
        {
            if (width > height)
            {
                Console.WriteLine("This area is " + width * height);
            }
        }
        public override void Islegal()
        {
            if (width > height) Console.WriteLine("The rectangle is legal.");
            else Console.WriteLine("The rectangle is illegal.");
        }
    }

    class Square :Rectangle
    {
        private int width;
        private int height; 
        public void setWidth(int width)
        {
            this.width = width;
        }
        public void setHeight(int height)
        {
            this.height= height;
        }
        public void getArea()
        {
            if (width == height)
            {
                Console.WriteLine("This area is " + width * height);
            }
        }
        public override void Islegal()
        {
            if (width == height) Console.WriteLine("This Square is legal.");
            else Console.WriteLine("The Square is illegal");
        }
    }
    class Triangle : isLegal, Area
    {
        private int side1;
        private int side2; 
        private int side3; 
        public void setSide(int side1,int side2,int side3)
        {
            this.side1 = side1;
            this.side2 = side2;
            this.side3 = side3;
        }
        public void getArea()
        {
            if (((side1 + side2) > side3)&&((side1+side3)>side2)&&((side2+side3)>side1)&&(side1>0)&&(side2>0)&&(side3>0))
            {
                int p = (side1 + side2 + side3) / 2;
                Console.WriteLine("The area is " + Math.Sqrt(p * (p - side1) * (p - side2) * (p - side3)));
            }
        }
        public override void Islegal()
        {
            if ((side1 + side2) > side3) Console.WriteLine("The triangle is legal.");
            else Console.WriteLine("The triangle is illegal.");
        }
    }
    public class Problem01
    {
        public static void Main(string[] args)
        {
            Rectangle r = new Rectangle();
            r.setWidth(6);
            r.setHeight(4);
            r.getArea();
            r.Islegal();
            Square s = new Square();
            s.setWidth(4);
            s.setHeight(5);
            s.getArea();
            s.Islegal();
            Triangle t = new Triangle();
            t.setSide( 3, 4,5);
            t.getArea();
            t.Islegal();


        }
    }
}