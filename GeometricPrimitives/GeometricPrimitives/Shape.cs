using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace GeometricPrimitives
{
    abstract class Shape
    {
        private double _x;
        public double X
        {
            get => _x;
            private set
            {
                _x = value;
                Update();
            }
        }

        private double _y;
        public double Y
        {
            get => _y;
            private set
            {
                _y = value;
                Update();
            }
        }
        public double Square { get; set; }

        protected Shape(double x = 0, double y = 0)
        {
            X = x;
            Y = y;
            Square = 0;
        }

        public void MoveTo(double x, double y)
        {
            X = x;
            Y = y;
        }

        protected virtual double CalcSquare()
        {
            return 0;
        }

        protected virtual void Update()
        {

        }
    }

    class Line : Shape
    {
        public double Length { get; private set; }
        public double XTo { get; }
        public double YTo { get; }

        public Line(double xTo = 0, double yTo = 0, double xFrom = 0, double yFrom = 0)
            : base(xFrom, yFrom)
        {
            XTo = xTo;
            YTo = yTo;
            Length = CalcLength();
        }

        private double CalcLength()
        {
            return Math.Sqrt(Math.Pow(X - XTo, 2) + Math.Pow(Y - YTo, 2));
        }

        public override string ToString()
        {
            return $"Прямая. Положение х: {X}, y: {Y}.\nДо х: {XTo}, y: {YTo}.\nДлина: {Length}.";
        }

        protected override void Update()
        {
            Length = CalcLength();
        }
    }

    class Circle : Shape
    {
        public double Radius { get; }

        public Circle(double radius, double x = 0, double y = 0)
            : base(x, y)
        {
            Radius = radius;
            Square = CalcSquare();
        }

        protected override double CalcSquare()
        {
            return 2 * Math.PI * Radius;
        }

        public override string ToString()
        {
            return $"Окружность. Положение х: {X}, y: {Y}.\nРадиус: {Radius}.\nПлощадь: {Square}.";
        }
    }

    class Triangle : Shape
    {
        public double Angle { get; }
        public double LeftLength { get; }
        public double RightLength { get; }

        public Triangle(double leftLength, double rightLength, double angle = 0, double x = 0, double y = 0)
            : base(x, y)
        {
            LeftLength = leftLength;
            RightLength = rightLength;
            Angle = angle;
            Square = CalcSquare();
        }

        protected override double CalcSquare()
        {
            return 0.5 * Math.Sin(Angle * Math.PI / 180.0) * LeftLength * RightLength;
        }

        public override string ToString()
        {
            return $"Треугольник. Положение х: {X}, y: {Y}.\n" +
                   $"Угол: {Angle}. Длина левой прямой: {LeftLength}. Длина правой прямой: {RightLength}.\n" +
                   $"Площадь: {Square}.";
        }
    }

    class Rectangle : Shape
    {
        public double LeftLength { get; }
        public double RightLength { get; }

        public Rectangle(double leftLength, double rightLength, double x = 0, double y = 0)
            : base(x, y)
        {
            LeftLength = leftLength;
            RightLength = rightLength;
            Square = CalcSquare();
        }

        protected sealed override double CalcSquare()
        {
            return LeftLength * RightLength;
        }

        public override string ToString()
        {
            return $"Прямоугольник. Положение х: {X}, y: {Y}.\n" +
                   $"Длина левой прямой: {LeftLength}. Длина правой прямой: {RightLength}.\n" +
                   $"Площадь: {Square}.";
        }
    }
}
