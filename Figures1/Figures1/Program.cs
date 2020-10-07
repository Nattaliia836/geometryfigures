using System;

namespace Figures1
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Triangle tr = new Triangle(2, 2, 1);
                tr.ChangeSide("Third", 3);
                Console.WriteLine(tr.GetAngle("Alpha"));
                Console.WriteLine(tr.GetPerimeter());

                EquilateralTriangle etr = new EquilateralTriangle(4);
                Console.WriteLine(etr.GetArea());
            }
            catch (Exception e)
            {
                Console.WriteLine("{0} Exception caught.", e);
            }
        }
    }

    class Triangle
    {
        private double sideA;
        private double sideB;
        private double sideC;

        public Triangle() { }

        public Triangle(double side1, double side2, double side3)
        {
            if (SideCheck(side1, side2, side3))
            {
                sideA = side1;
                sideB = side2;
                sideC = side3;
            }
            else
            {
                throw new Exception("The sides of the triangle are of the wrong size");
            }
        }

        public bool SideEqualityCheck(double side1, double side2, double side3)
        {
            if (side1 < (side2 + side3))
            {
                return true;
            }

            return false;
        }

        public bool SideCheck(double side1, double side2, double side3)
        {
            if((side1 < 0) || (side2 < 0) || (side3 < 0))
            {
                throw new Exception("The side of the triangle has a negative value");
            }

            if( !( SideEqualityCheck(side1, side2, side3)
                   && SideEqualityCheck(side2, side1, side3)
                   && SideEqualityCheck(side3, side2, side1)) )
            {
                throw new Exception("The sides of the triangle are of the wrong size");
            }

            return true;
        }

        public void ChangeSide(string nameSide, double newSide)
        {
            if(nameSide == "First")
            {
                if(SideCheck(newSide, sideB, sideC))
                {
                    sideA = newSide;
                }
            }
            else if (nameSide == "Second")
            {
                if (SideCheck(sideA, newSide, sideC))
                {
                    sideB = newSide;
                }
            }
            else if (nameSide == "Third")
            {
                if (SideCheck(sideA, sideB, newSide))
                {
                    sideC = newSide;
                }
            }
            else
            {
                throw new Exception("Wrongly chosen side");
            }
        }

        public double GetPerimeter()
        {
            return (sideA + sideB + sideC);
        }

        public double GetAngle(string angle)
        {
            if(angle == "Alpha")
            {
                return (Math.Acos((sideB * sideB + sideC * sideC - sideA * sideA) / (2 * sideB * sideC)));
            }
            else if (angle == "Beta")
            {
                return (Math.Acos((sideA * sideA + sideC * sideC - sideB * sideB) / (2 * sideA * sideC)));
            }
            else if (angle == "Gamma")
            {
                return (Math.Acos((sideB * sideB + sideA * sideA - sideC * sideC) / (2 * sideB * sideA)));
            }
            else
            {
                throw new Exception("Invalid angle name");
            }

            //return 1;
        }
    }

    class EquilateralTriangle : Triangle
    {
        private double Area;
        private double side;

        public EquilateralTriangle(double side) 
        {
            this.side = side;
        }

        public double GetArea()
        {
            return (side * side * Math.Sqrt(3)/4);
        }
    }
}