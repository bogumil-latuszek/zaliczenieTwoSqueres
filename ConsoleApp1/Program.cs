using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    class Program
    {
        public static bool judgeSquareSum(long n)
        {
            if (n < 0)
            {
                return false;
            }
            for (int i = 2; i * i <= n; i++)
            {
                int count = 0;
                if (n % i == 0)
                {
                    while (n % i == 0)
                    {
                        count++;
                        n /= i;
                    }
                    if (i % 4 == 3 && count % 2 != 0)
                        return false;
                }
            }
            return n % 4 != 3;
        }

        static void Main(string[] args)
        {
            List<long> imputNum = new List<long>();
            //List<long> squeredNum = new List<long>();
            string wejscie = Console.ReadLine();
            int firstNum = Int32.Parse(wejscie);
            for (int i = 0; i < firstNum; i++)
            {
                imputNum.Add( Int64.Parse(Console.ReadLine()));
            }
            for (int i = 0; i < imputNum.Count ; i++)
            {

                bool isSumof2Sqr = judgeSquareSum(imputNum[i]);
                if (isSumof2Sqr == true)
                {
                    Console.WriteLine("Yes");
                }
                else
                {
                    Console.WriteLine("No");
                }
            }
            

        }
    }
}
