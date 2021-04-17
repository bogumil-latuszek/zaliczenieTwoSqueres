using System;

namespace Wzorki1
{
    class Program
    {
        public static void narysujB(sbyte n)
        {
            for (int i = 1; i <= n; i++)
            {
                if (i == 1 || i == n)
                {
                    Console.WriteLine("");
                    for (int a = 0; a < n; a++)
                    {
                        
                        Console.Write("*");
                        
                    }
                }
                else
                {
                    Console.WriteLine("");
                    for (int a = 1; a <= n; a++)
                    {

                        if (a == i)
                        {
                            Console.Write("*");
                        }
                        else
                        {
                            Console.Write(".");
                        }
                    }
                }

            }
        }
        public static void narysujA(sbyte n, sbyte m)
        {
            for (int i = 1; i <= m; i++)
            {
                if (i == 1 || i == m || i == m / 2 + 1)
                {
                    Console.WriteLine("");
                    for (int a = 0; a < n; a++)
                    {
                        Console.Write("*");
                    }
                }
                else
                {
                    Console.WriteLine("");
                    for (int a = 1; a <= n; a++)
                    {
                        if (a == 1 || a == n || a == n / 2 + 1)
                        {
                            Console.Write("*");
                        }
                        else
                        {
                            Console.Write(".");
                        }
                    }
                }
            }
        }
        static void Main(string[] args)
        {
            string imput = Console.ReadLine();
            string[] imputZbiór = imput.Split(" ");
            if (imputZbiór[0] == "A")
            {
                sbyte n = sbyte.Parse(imputZbiór[1]);
                sbyte m = sbyte.Parse(imputZbiór[2]);
                if (n % 2 == 0)
                {
                    n++;
                }
                if (m % 2 == 0)
                {
                    m++;
                }
                Program.narysujA(n, m);
            }
            else
            {
                sbyte n = sbyte.Parse(imputZbiór[1]);
                if (n % 2 == 0)
                {
                    n++;
                }
                Program.narysujB(n);
            }            
        }
    }
}
