using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GeometriskaFigurer_A
{
    public enum ShapeType {Undefined, Ellipse, Rectangle };

    public abstract class Shape
    {
        private double _length;
        private double _width;

        public abstract double Area { get; }
        public abstract double Perimeter { get; }

        // Validerar längden som ska tilldelas
        public double Length 
        {
            get { return _length; }
            set 
            { 
                if (value < 0) 
                { 
                    throw new ArgumentException("Längden måste vara större än noll!"); 
                } 
                _length = value; 
            } 
        } 

        // Validerar bredden som ska tilldelas
        public double Width
        {
            get { return _width; }
            set 
            { 
                if (value < 0) 
                { 
                    throw new ArgumentException("Bredden måste vara större än noll!"); 
                }
                _width = value;
            } 
        } 

        // Konstruktor som ansvarar för att fälten får giltiga värden
        protected Shape(double length, double width) 
        {
            Length = length;
            Width = width;
        }

        // Presenterar detaljer i specifikt format
        public override string ToString()
        {
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.DarkCyan;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(" ╔═══════════════════════════════════╗ ");
            Console.WriteLine(" ║             Detaljer              ║ ");
            Console.WriteLine(" ╚═══════════════════════════════════╝ ");
            Console.ResetColor();
           
            return string.Format("\nLängd  : {0, 6:f1} \nBredd  : {1, 6:f1} \nOmkrets: {2, 6:f1} \nArea   : {3, 6:f1}", Length, Width, Perimeter, Area);     
        }
    }

    
}
