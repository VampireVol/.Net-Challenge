using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeometricPrimitives
{
    class Program
    {
        static void Main(string[] args)
        {
            GraphicEditor graphicEditor = new GraphicEditor();
            graphicEditor.Add(new Line(4,4));
            graphicEditor.Add(new Circle(5, 2,2));
            graphicEditor.Add(new Triangle(4,8, 30));
            graphicEditor.Add(new Rectangle(10,20));
            graphicEditor.PrintAllInfo();
            Console.WriteLine("Площадь всех объектов: " + graphicEditor.CalcAllSquare());
            Console.WriteLine("\nНапример, переместим прямоугольник и удалим треугольник.\n");
            graphicEditor.MoveToPrimitive(3, 5,6);
            graphicEditor.Del(2);
            graphicEditor.PrintAllInfo();
            Console.WriteLine("Площадь всех объектов: " + graphicEditor.CalcAllSquare());
            Console.ReadKey();
        }
    }
}
