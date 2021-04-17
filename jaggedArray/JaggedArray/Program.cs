using System;

namespace JaggedArray
{
    class Program
    {
        static char[][] ReadJaggedArrayFromStdInput()
        {
            int rows = Int32.Parse(Console.ReadLine());
            char[][] jaggedArray = new char[rows][];
            for (int i = 0; i < rows; i++)
            {
                string input = Console.ReadLine();
                char[] rowArray = Array.ConvertAll<string, char>(input.Split(" "), Char.Parse);
                jaggedArray[i]= rowArray;

            }
            return jaggedArray;
        }

        static void PrintJaggedArrayToStdOutput(char[][] tab)
        {
            for (int i = 0; i < tab.GetLength(0); i++)
            {
                string output = "";
                for (int a = 0; a < tab[i].Length; a++)
                {
                    if (tab[i][a] == 0)
                    {
                        output = output+"  ";
                    }
                    else
                    {
                        output = output + tab[i][a] + " ";
                    }
                }
                string outp = output.TrimEnd();
                Console.WriteLine(outp);
            }
        }

        static char[][] TransposeJaggedArray(char[][] tab)
        {
            int longestRow = 0;
            for (int i = 0; i < tab.GetLength(0); i++)
            {
                if (tab[i].Length > longestRow)
                {
                    longestRow = tab[i].Length;
                }
            }
            char[][] transposedArray = new char[longestRow][];
            for (int i = 0; i < longestRow; i++)
            {
                /*int newRow = 0;
                for (int a = 0; a < tab.GetLength(0); a++)
                {
                    if (tab[a][i] != 0)
                    {
                        newRow = a+1;
                    }
                }*/
                transposedArray[i] = new char[tab.GetLength(0)];
            }
            for (int a = 0; a < tab.GetLength(0); a++)
            {
                for (int b = 0; b < tab[a].Length; b++)
                {
                    transposedArray[b][a] = tab[a][b];
                }
            }
            return transposedArray;
        }
        static void Main(string[] args)
        {
            char[][] jagged = ReadJaggedArrayFromStdInput();
            PrintJaggedArrayToStdOutput(jagged);
            jagged = TransposeJaggedArray(jagged);
            Console.WriteLine();
            PrintJaggedArrayToStdOutput(jagged);
        }
    }
}
