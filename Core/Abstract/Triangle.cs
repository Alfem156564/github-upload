using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Abstract
{
    public class Triangle : AreaClass
    {
        int side1 = 0;
        int side2 = 0;

        // constructor
        public Triangle(int a, int b)
        {
            side1 = a;
            side2 = b;
        }

        // the abstract method
        // 'Area' is overridden here
        public override double Area()
        {
            return side1 * side2 / 2;
        }
    }
}
