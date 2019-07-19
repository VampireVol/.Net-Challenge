using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Complex
{
    class ComplexNumber
    {
        private int _real;
        private int _image;

        public ComplexNumber(int real = 0, int image = 0)
        {
            _real = real;
            _image = image;
        }

        public static ComplexNumber operator +(ComplexNumber left, ComplexNumber right)
        {
            return new ComplexNumber(left._real + right._real, left._image + right._image);
        }

        public static ComplexNumber operator -(ComplexNumber left, ComplexNumber right)
        {
            return new ComplexNumber(left._real - right._real, left._image - right._image);
        }

        public static ComplexNumber operator *(ComplexNumber left, ComplexNumber right)
        {
            return new ComplexNumber(left._real * right._real - left._image * right._image, left._real * right._image + left._image * right._real);
        }

        public override string ToString()
        {
            string sign;
            if (_image < 0)
                sign = "-";
            else
                sign = "+";
            return _real + " " + sign + " i" + Math.Abs(_image);
        }
    }
}
