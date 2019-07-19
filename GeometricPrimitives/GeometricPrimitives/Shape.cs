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
        public double x { get; set; }
        public double y { get; set; }
        public double square { get; set; }

        public Shape(double x = 0, double y = 0)
        {
            this.x = x;
            this.y = y;
            square = 0;
        }

        public void MoveTo(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        virtual protected double CalcSquare()
        {
            return 0;
        }
    }

    class Line : Shape
    {
        public double xTo { get; set; }
        public double yTo { get; set; }
        public double lenght { get; set; }

        public Line(double xTo = 0, double yTo = 0, double xFrom = 0, double yFrom = 0)
            : base(xFrom, yFrom)
        {
            this.xTo = xTo;
            this.yTo = yTo;
            lenght = CalcLenght();
        }

        private double CalcLenght()
        {
            return Math.Sqrt(Math.Pow(x - xTo, 2) + Math.Pow(y - yTo, 2));
        }

        public override string ToString()
        {
            return $"Прямая. Положение х: {x}, y: {y}.\nДо х: {xTo}, y: {yTo}.\nДлина: {lenght}.";
        }
    }

    class Circle : Shape
    {
        public double radius { get; set; }

        public Circle(double radius, double x = 0, double y = 0)
            : base(x, y)
        {
            this.radius = radius;
            square = CalcSquare();
        }

        protected override double CalcSquare()
        {
            return 2 * Math.PI * radius;
        }

        public override string ToString()
        {
            return $"Окружность. Положение х: {x}, y: {y}.\nРадиус: {radius}.\nПлощадь: {square}.";
        }
    }

    class Triangle : Shape
    {
        public double angle { get; set; }
        public double leftLenght { get; set; }
        public double rightLenght { get; set; }

        public Triangle(double leftLenght, double rightLenght, double angle = 0, double x = 0, double y = 0)
            : base(x, y)
        {
            this.leftLenght = leftLenght;
            this.rightLenght = rightLenght;
            this.angle = angle;
            square = CalcSquare();
        }

        protected override double CalcSquare()
        {
            return 0.5 * Math.Sin(angle * Math.PI / 180.0) * leftLenght * rightLenght;
        }

        public override string ToString()
        {
            return $"Треугольник. Положение х: {x}, y: {y}.\n" +
                   $"Угол: {angle}. Длина левой прямой: {leftLenght}. Длина правой прямой: {rightLenght}.\n" +
                   $"Площадь: {square}.";
        }
    }

    class Rectangle : Shape
    {
        public double leftLenght { get; set; }
        public double rightLenght { get; set; }

        public Rectangle(double leftLenght, double rightLenght, double x = 0, double y = 0)
            : base(x, y)
        {
            this.leftLenght = leftLenght;
            this.rightLenght = rightLenght;
            square = CalcSquare();
        }

        protected override double CalcSquare()
        {
            return leftLenght * rightLenght;
        }

        public override string ToString()
        {
            return $"Прямоугольник. Положение х: {x}, y: {y}.\n" +
                   $"Длина левой прямой: {leftLenght}. Длина правой прямой: {rightLenght}.\n" +
                   $"Площадь: {square}.";
        }
    }
}
