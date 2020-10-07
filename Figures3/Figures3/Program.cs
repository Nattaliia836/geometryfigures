using System;

namespace Figures3
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                //Console.WriteLine("Hello World!");
                IsoscelesTriangle it = new IsoscelesTriangle(2, 2, 0.7);
                Console.WriteLine(it.GetArea());
                Console.WriteLine(it.GetPerimeter());

                RightTriangle rt = new RightTriangle(2, 2, 0.7);
                Console.WriteLine(rt.GetArea());
                Console.WriteLine(rt.GetPerimeter());
            }
            catch (Exception e)
            {
                Console.WriteLine("{0} Exception caught.", e);
            }
        }
    }

    abstract class Triangle
    {
        protected double angle;
        protected double sideA;
        protected double sideB;
        public Triangle()
        {

        }

        public Triangle(double side1, double side2, double angle)
        {
            if((side1 > 0) && (side2 > 0) && (angle > 0))
            {
                sideA = side1;
                sideB = side2;
                this.angle = angle;
            }
            else
            {
                throw new Exception("Wrong size of side or a negative angle value");
            }
        }

        virtual public double GetPerimeter()
        {
            double sideC;
            sideC = Math.Sqrt(sideA * sideA + sideB * sideB - 2 * sideA * sideB * Math.Cos(angle));
            return (sideA + sideB + sideC);
        }

        virtual public double GetArea()
        {
            return (0.5 * sideA * sideB * Math.Sin(angle));
        }
    }

    class RightTriangle : Triangle
    {
        public RightTriangle(double sideA, double sideB, double angle) : base(sideA, sideB, angle)
        {

        }
        override public double GetPerimeter()
        {
            if (angle == (Math.PI / 2))
            {
                return (sideA + sideB + Math.Sqrt(sideA * sideA + sideB * sideB));
            }
            else
            {
                if (sideA > sideB)
                {
                    return (sideA + sideB + Math.Sqrt(sideA * sideA - sideB * sideB));
                }
                else
                {
                    return (sideA + sideB + Math.Sqrt(sideB * sideB - sideA * sideA));
                }
            }
        }

        override public double GetArea()
        {
            if (angle == (Math.PI / 2))
            {
                return (0.5 * sideA * sideB);
            }
            else
            {
                return (0.5 * sideA * sideB * Math.Sin(angle));
            }
        }
    }

    class IsoscelesTriangle : Triangle
    {
        public IsoscelesTriangle(double sideA, double sideB, double angle) : base(sideA, sideB,  angle)
        {

        }
    }
}
