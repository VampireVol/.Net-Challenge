using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeometricPrimitives
{
    class GraphicEditor
    {
        private List<Shape> _primitives;

        public GraphicEditor()
        {
            _primitives = new List<Shape>();
        }

        public void Add(Shape shape)
        {
            _primitives.Add(shape);
        }

        public void Del(int num)
        {
            _primitives.RemoveAt(num);
        }

        public double CalcAllSquare()
        {
            double square = 0;
            int size = _primitives.Count;
            for (int i = 0; i < size; ++i)
            {
                square += _primitives[i].Square;
            }

            return square;
        }

        public void MoveToPrimitive(int num, double x, double y)
        {
            _primitives[num].MoveTo(x, y);
        }

        public void PrintAllInfo()
        {
            int size = _primitives.Count;
            for (int i = 0; i < size; ++i)
            {
                Console.WriteLine(i + ": " + _primitives[i]);
            }
        }
    }
}
