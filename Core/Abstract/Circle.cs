using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Abstract
{
    public class Circle : AreaClass
    {
        double pi = 3.1416;
        int side = 0;

        // constructor
        public Circle(int n)
        {
            side = n;
        }

        // the abstract method
        // 'Area' is overridden here
        public override double Area()
        {
            return side * pi;
        }
    }
}
