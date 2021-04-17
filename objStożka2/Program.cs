using System;

namespace objStożka2
{
    class Program
    {
        public static int toUpperIntBoundary(double n)
        {
            if(n % 1 == 0)
            {
                return (int)n;
            }
            else
            {
                return ((int)n + 1);
            }
        }
        static void Main(string[] args)
        {
            string imput = Console.ReadLine();
            int[] imputInt = Array.ConvertAll<string, int>(imput.Split(" "), int.Parse);
            int R = imputInt[0];
            int L = imputInt[1];
            if (R < 0 || L < 0)
            {
                Console.WriteLine("ujemny argument");
            }
            else if(L < R)
            {
                Console.WriteLine("obiekt nie istnieje");
            }
            else
            {
                double V = (Math.PI * (R * R) * Math.Sqrt((L * L) - (R * R))) / 3.0;
                Console.WriteLine( (int)V+" "+ toUpperIntBoundary(V));
            }
        }
    }
}
