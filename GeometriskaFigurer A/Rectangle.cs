using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GeometriskaFigurer_A
{
    public class Rectangle : Shape
    {
        public override double Area 
        {   
            get
            {   
                return (Length * Width); 
            } 
        }

        public override double Perimeter 
        { 
            get
            {
                return ((2 * Length) + (2 * Width));
            }
        }

        // Anropar basklassens konstruktor
        public Rectangle(double length, double width) :base(length, width)
        {      
        }
    }
}
