namespace P02.BookWorm
{
    using System;

    class Program
    {
        static void Main()
        {
            string text = Console.ReadLine();
            int size = int.Parse(Console.ReadLine());

            int playerRow = 0;
            int playerCol = 0;

            char[,] playground = new char[size, size];

            for (int i = 0; i < size; i++)
            {
                char[] arr = Console.ReadLine().ToCharArray();
                for (int j = 0; j < arr.Length; j++)
                {
                    playground[i, j] = arr[j];
                    if (arr[j] == 'P')
                    {
                        playerRow = i;
                        playerCol = j;
                    }
                }
            }

            string command;
            while ((command = Console.ReadLine())!= "end")
            {
                playground[playerRow, playerCol] = '-';

                int lastRowIndex = playerRow;
                int lastColIndex = playerCol;

                if (command == "up")
                {
                    playerRow--;
                }
                else if (command == "down")
                {
                    playerRow++;
                }
                else if (command == "left")
                {
                    playerCol--;
                }
                else if (command == "right")
                {
                    playerCol++;
                }

                if (!IsInPlayground(playerRow, playerCol, size))
                {
                    if (text != null)
                    {
                        text = text.Remove(text.Length - 1);
                    }

                    playerRow = lastRowIndex;
                    playerCol = lastColIndex;
                }

                else if (playground[playerRow,playerCol] != '-')
                {
                    text = text + playground[playerRow, playerCol];
                }

                playground[playerRow, playerCol] = 'P';
            }
            Console.WriteLine(text);
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    Console.Write(playground[i,j]);
                }
                Console.WriteLine();
            }
        }
        public static bool IsInPlayground(int row, int col, int size)
        {
            return row < size && row >= 0 && col < size && col >= 0;
        }
    }
}
