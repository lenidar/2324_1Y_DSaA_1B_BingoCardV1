using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2324_1Y_DSaA_1B_BingoCardV1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[,] bingoCard = new int[5, 5];
            string[,] displayCard = new string[5, 5];
            Random rnd = new Random();
            bool duplicate = false;
            int temp = 0;

            // fill up the array with initial values
            for (int x = 0; x < bingoCard.GetLength(0); x++)
                for (int y = 0; y < bingoCard.GetLength(1); y++)
                    bingoCard[x, y] = -1;

            //// initial unformated display
            //for (int x = 0; x < bingoCard.GetLength(0); x++)
            //{
            //    for (int y = 0; y < bingoCard.GetLength(1); y++)
            //        Console.Write($"{bingoCard[x, y]}  ");
            //    Console.WriteLine();
            //}

            // generate numbers
            for (int x = 0; x < bingoCard.GetLength(0); x++) // row
            {
                for (int y = 0; y < bingoCard.GetLength(1); y++) // column
                {
                    temp = rnd.Next(0, 15) + 1 + (y * 15);
                    duplicate = false;

                    for (int z = 0; z < bingoCard.GetLength(1); z++)
                    {
                        if (bingoCard[z, y] == -1)
                            break;
                        else if (bingoCard[z,y] == temp)
                        {
                            duplicate = true;
                            break;
                        }
                    }

                    if (duplicate)
                        y--;
                    else
                        bingoCard[x, y] = temp;
                }
            }

            //// initial unformated display
            //for (int x = 0; x < bingoCard.GetLength(0); x++)
            //{
            //    for (int y = 0; y < bingoCard.GetLength(1); y++)
            //        Console.Write($"{bingoCard[x, y]}  ");
            //    Console.WriteLine();
            //}

            // format card
            for(int x = 0; x < bingoCard.GetLength(0); x++)
            {
                for(int y = 0; y < bingoCard.GetLength(1); y++)
                {
                    displayCard[x, y] = bingoCard[x, y] + "";
                    while (displayCard[x, y].Length < 3)
                        displayCard[x, y] = " " + displayCard[x, y]; 
                }
            }

            displayCard[2, 2] = "FRE";

            //// formatted display
            Console.WriteLine("+-----+-----+-----+-----+-----+");
            Console.WriteLine("|  B  |  I  |  N  |  G  |  O  |");
            Console.WriteLine("+-----+-----+-----+-----+-----+");
            for (int x = 0; x < displayCard.GetLength(0); x++)
            {
                Console.Write("| ");
                for (int y = 0; y < displayCard.GetLength(1); y++)
                    Console.Write($"{displayCard[x, y]} | ");
                Console.WriteLine();
                Console.WriteLine("+-----+-----+-----+-----+-----+");
            }


            Console.ReadKey();
        }
    }
}
