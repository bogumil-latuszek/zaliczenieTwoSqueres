using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> imputNum = new List<int>();
            List<int> squeredIntegers = new List<int>();
            string wejscie = Console.ReadLine();
            int firstNum = Int32.Parse(wejscie);
            for (int i = 0; i < firstNum; i++)
            {
                imputNum.Add( Int32.Parse(Console.ReadLine()));
            }
            //int[] dane = Array.ConvertAll<string, int>(wejscie.Split(" "), int.Parse);
            //Console.WriteLine(string.Join(" ", squeredIntegers));
            for (int i = 0; i < imputNum.Count ; i++)
            {
                for (int a = 0; a <= imputNum[i]; a++)
                {
                    if((a*a) > imputNum[i])
                    {
                        break;
                    }
                    else
                    {
                        squeredIntegers.Add(a*a);
                    }
                }
                bool isMadeOftwoSqueres = false;
                for (int b = 0; b < squeredIntegers.Count; b++)
                {
                    for (int c = b; c < squeredIntegers.Count; c++)
                    {
                        int sumOfSqueres = squeredIntegers[b] + squeredIntegers[c];
                        if (sumOfSqueres == imputNum[i]) 
                        {
                            isMadeOftwoSqueres = true;
                            break;
                        }
                    }
                }
                if (isMadeOftwoSqueres == true)
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
