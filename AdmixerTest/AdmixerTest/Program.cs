using System;

namespace AdmixerTest
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var matrix = new int[9, 9];
            var random = new Random();

            //Fill the matrix with random digits in range from 0 to 3(included)
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = random.Next(0, 4);
                }
            }

            bool repeats = true;

            while (repeats)
            {
                Print(matrix);
                Console.WriteLine();
                repeats = Search(matrix);
                Console.WriteLine();
            }
            Console.WriteLine("No more repeats in the matrix.");
        }


        private static void Print(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
        private static bool Search(int[,] matrix)
        {
            int count = 1;
            int repeatElement = int.MaxValue;

            //Search in rows
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                repeatElement = matrix[i, 0];
                count = 1;
                for (int j = 1; j < matrix.GetLength(1); j++)
                {
                    if (repeatElement == matrix[i, j])
                    {
                        count++;
                        if (count >= 3)
                        {
                            (int, int) pos1 = (i, j - 2);
                            (int, int) pos2 = (i, j - 1);
                            (int, int) pos3 = (i, j);
                            Console.WriteLine($"Repeated elements are in positions: {pos1.Item1},{pos1.Item2}; " +
                                $"{pos2.Item1},{pos2.Item2}; {pos3.Item1},{pos3.Item2}");
                            ModifyMatrix(matrix, pos1, pos3);
                            return true;
                        }
                    }
                    else
                    {
                         repeatElement = matrix[i, j];
                         count = 1;
                    }
                }
            }
            //Search in cols
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                repeatElement = matrix[0, j];
                count = 1;
                for (int i = 1; i < matrix.GetLength(0); i++)
                {
                    if (repeatElement == matrix[i, j])
                    {
                        count++;
                        if (count >= 3)
                        {
                            (int, int) pos1 = (i - 2, j);
                            (int, int) pos2 = (i - 1, j);
                            (int, int) pos3 = (i, j);
                            Console.WriteLine($"Repeated elements are in positions: {pos1.Item1},{pos1.Item2}; " +
                                $"{pos2.Item1},{pos2.Item2}; {pos3.Item1},{pos3.Item2}");
                            ModifyMatrix(matrix, pos1, pos3);
                            return true;
                        }
                    }
                    else
                    {
                        repeatElement = matrix[i, j];
                        count = 1;
                    }
                }
            }
            return false;
        }
        private static void ModifyMatrix(int[,] matrix, (int, int) start, (int, int) end)
        {
            int rowsToCopy = end.Item1 - (end.Item1 - start.Item1); //Indicates how many elements have to "go down" from the top
            Random random = new Random();

            for (int i = end.Item1; i >= 0; i--)
            {
                for (int j = start.Item2; j <= end.Item2; j++)
                {
                    if (rowsToCopy > 0)
                    {
                        matrix[i, j] = matrix[rowsToCopy - 1, j];
                    }
                    else
                    {
                        matrix[i, j] = random.Next(0, 4);
                    }
                }
                rowsToCopy--;
            }
        }
    }
}