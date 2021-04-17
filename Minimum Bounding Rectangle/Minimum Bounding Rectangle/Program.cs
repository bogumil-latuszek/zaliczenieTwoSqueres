using System;
using System.Collections.Generic;

namespace Minimum_Bounding_Rectangle
{
    interface IFigura
    {
        Rectangle BoundingRectangle(Rectangle r);
    }
    class Figura
    {
        virtual public Rectangle BoundingRectangle(Rectangle r, int minX, int maxX, int minY, int maxY)
        {
            if (r.isEmpty == true)
            {
                r.isEmpty = false;
                r.maxX = maxX;
                r.minX = minX;
                r.maxY = maxY;
                r.minY = minY;
            }
            else
            {
                if (maxX > r.maxX)
                {
                    r.maxX = maxX;
                }
                if (minX < r.minX)
                {
                    r.minX = minX;
                }
                if (maxY > r.maxY)
                {
                    r.maxY = maxY;
                }
                if (minY < r.minY)
                {
                    r.minY = minY;
                }
                
            }
            return r;
        }
    }
    class Punkt : Figura, IFigura
    {
        int minX;
        int maxX;
        int minY;
        int maxY;
        public Punkt( int x, int y)
        {
            minX = x;
            maxX = x;
            minY = y;
            maxY = y;
        }
        public  Rectangle BoundingRectangle(Rectangle r)
        {
            return base.BoundingRectangle(r, minX, maxX, minY, maxY);
        }
    }
    class Kolo : Figura, IFigura
    {
        int minX;
        int maxX;
        int minY;
        int maxY;
        public Kolo(int centerX, int centerY, int radious)
        {
            minX = centerX - radious;
            maxX = centerX + radious;
            minY = centerY - radious;
            maxY = centerY + radious;
        }
        public Rectangle BoundingRectangle(Rectangle r)
        {
            return base.BoundingRectangle(r, minX, maxX, minY, maxY);
        }
    }
    class Odcinek : Figura, IFigura
    {
        int maxX;
        int minX;
        int maxY;
        int minY;
        public Odcinek(int x1, int y1, int x2, int y2)
        {
            
            if (x1 >= x2)
            {
                maxX = x1;
                minX = x2;
            }
            else
            {
                maxX = x2;
                minX = x1;
            }
            if (y1 >= y2)
            {
                maxY = y1;
                minY = y2;
            }
            else
            {
                maxY = y2;
                minY = y1;
            }
        }
        public Rectangle BoundingRectangle(Rectangle r)
        {
            return base.BoundingRectangle(r, minX, maxX, minY, maxY);
        }
    }
    class Rectangle : Figura, IFigura
    {
        public int minX = 0;
        public int maxX = 0;
        public int minY = 0;
        public int maxY = 0;
        public bool isEmpty;
        public Rectangle()
        {
            isEmpty = true;
        }
        public Rectangle BoundingRectangle(Rectangle r)
        {
            return base.BoundingRectangle(r, minX, maxX, minY, maxY);
        }
    }
    class Program
    {
        public static Rectangle MinimumBoundingRectangle( List<IFigura> listaFigur)
        {
            Rectangle r = new Rectangle();
            foreach(IFigura figura in listaFigur)
            {
                r = figura.BoundingRectangle(r);
            }
            return r;
        }


        static void Main(string[] args)
        {
            int cases = Int32.Parse(Console.ReadLine());
            string[] output = new string[cases];
            for (int cas3 = 0; cas3 < cases; cas3++)
            {
                List<IFigura> listaFigur = new List<IFigura>();
                Rectangle r = new Rectangle();
                int objCount = Int32.Parse(Console.ReadLine());
                for (int i = 0; i < objCount; i++)
                {
                    string input = Console.ReadLine();
                    string[] objects = input.Split(" ");
                    if (objects[0] == "p")
                    {
                        Punkt P = new Punkt(Int32.Parse(objects[1]), Int32.Parse(objects[2]));
                        listaFigur.Add(P);
                    }
                    else if(objects[0] == "c")
                    {
                        Kolo K = new Kolo(Int32.Parse(objects[1]), Int32.Parse(objects[2]), Int32.Parse(objects[3]));
                        listaFigur.Add(K);
                    }
                    else if(objects[0] == "l")
                    {
                        Odcinek O = new Odcinek(Int32.Parse(objects[1]), Int32.Parse(objects[2]),
                             Int32.Parse(objects[3]), Int32.Parse(objects[4]));
                        listaFigur.Add(O);
                    }
                    else
                    {
                        throw new ArgumentException("unknown object");
                    }
                }
                r = MinimumBoundingRectangle( listaFigur);
                output[cas3] = (r.minX + " " + r.minY + " " + r.maxX + " " + r.maxY);
                Console.ReadLine();
            }
            for (int i = 0; i < output.Length; i++)
            {
                Console.WriteLine(output[i]);
            }
        }
    }
}
