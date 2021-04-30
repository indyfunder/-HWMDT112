using System;

namespace ข้อ1
{
    class Program
    {
        static void Main(string[] args)
        {
            {
                int n, stack = 1, i, j;
                Console.Write("Input row: ");
                n = int.Parse(Console.ReadLine());
                if (n < 0)
                {
                    Console.Write("Invalid Pascal's triangle row number.");
                }
                else
                {
                    for (i = 0; i <= n; i++)
                    {
                        for (j = 0; j <= i; j++)
                        {
                            if (j == 0 || i == 0)
                                stack = 1;
                            else
                                stack = stack * (i - j + 1) / j;
                            Console.Write("{0}", stack);
                        }
                        Console.Write("\n");
                    }
                }
                Console.ReadLine();
            }
        }
    }
}
