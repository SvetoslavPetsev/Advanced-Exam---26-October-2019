namespace P01.Dating_App
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main()
        {
            int[] input1 = Console
                .ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            int[] input2 = Console
               .ReadLine()
               .Split()
               .Select(int.Parse)
               .ToArray();

            int matches = 0;
            Stack<int> male = new Stack<int>(input1);
            Queue<int> female = new Queue<int>(input2);

            while (male.Any() && female.Any())
            {
                int getMale = male.Peek();
                int getFemale = female.Peek();

                if (getMale == getFemale)
                {
                    male.Pop();
                    female.Dequeue();
                    matches++;
                    continue;
                }

                else if (getMale <= 0 || getFemale <= 0)
                {
                    if (getMale <= 0)
                    {
                        male.Pop();
                    }
                    if (getFemale <= 0)
                    {
                        female.Dequeue();
                    }
                    continue;
                }

                else if (getMale % 25 == 0 || getFemale % 25 == 0)
                {
                    if (getMale % 25 == 0)
                    {
                        male.Pop();
                        male.Pop();
                    }
                    if (getFemale % 25 == 0)
                    {
                        female.Dequeue();
                        female.Dequeue();
                    }
                    continue;
                }

                else
                {
                    female.Dequeue();
                    male.Pop();
                    int newMale = getMale - 2;
                    male.Push(newMale);
                }
            }

            Console.WriteLine($"Matches: {matches}");

            if (!male.Any())
            {
                Console.WriteLine("Males left: none");
            }
            else
            {
                Console.WriteLine($"Males left: {string.Join(", ", male)}");
            }

            if (!female.Any())
            {
                Console.WriteLine("Females left: none");
            }
            else
            {
                Console.WriteLine($"Females left: {string.Join(", ", female)}");
            }
        }
    }
}
