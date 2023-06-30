using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Abstract
{
    public class Square : AreaClass
    {
        int side = 0;

        // constructor
        public Square(int n)
        {
            side = n;
        }

        // the abstract method
        // 'Area' is overridden here
        public override double Area()
        {
            return side * side;
        }
    }
}
