using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeometricPrimitives
{
    class GraphicEditor
    {
        public List<Shape> primitives;

        public GraphicEditor()
        {
            primitives = new List<Shape>();
        }

        public void Add(Shape shape)
        {
            primitives.Add(shape);
        }

        public void Del(int num)
        {
            primitives.RemoveAt(num);
        }

        public double CalcAllSquare()
        {
            double square = 0;
            int size = primitives.Count;
            for (int i = 0; i < size; ++i)
            {
                square += primitives[i].square;
            }

            return square;
        }

        public void MoveToPrimitive(int num, double x, double y)
        {
            primitives[num].MoveTo(x, y);
        }

        public void PrintAllInfo()
        {
            int size = primitives.Count;
            for (int i = 0; i < size; ++i)
            {
                Console.WriteLine(i + ": " + primitives[i]);
            }
        }
    }
}
