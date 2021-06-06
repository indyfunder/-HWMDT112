
using System;

namespace HW6
{
    class Program
    {
        enum Difficulty
        {
            Easy = 3,Normal = 5,Hard = 7
        }
        struct Problem
        {
            public string Message;
            public int Answer;
            public Problem(string message, int answer)
            {
                Message = message;
                Answer = answer;
            }
        }
        static Problem[] GenerateRandomProblems(int numProblem)
        {
            Problem[] randomProblems = new Problem[numProblem];
            Random rnd = new Random();
            int x, y;
            for (int i = 0; i < numProblem; i++)
            {
                x = rnd.Next(50);
                y = rnd.Next(50);
                if (rnd.NextDouble() >= 0.5)
                    randomProblems[i] =
                    new Problem(String.Format("{0} + {1} = ?", x, y), x + y);
                else
                    randomProblems[i] =
                    new Problem(String.Format("{0} - {1} = ?", x, y), x - y);
            }
            return randomProblems;
        }
        static void Main(string[] args)
        {
            int nlevel, nMenu, numProblem, Ans;
            long t1, t2, Time;
            double S = 0, S1, Qc = 0, Qa = 0, d_Lv = 0;
            Difficulty LV = Difficulty.Easy;

            Console.WriteLine("Score: {0}, Difficulty: {1}", S, LV);
            Console.WriteLine("select Menu 0 / 1 / 2");
            nMenu = int.Parse(Console.ReadLine());
            while (nMenu != 2)
            {
                switch (nMenu)
                {
                    case 0:
                        t1 = DateTimeOffset.Now.ToUnixTimeSeconds();
                        if (LV == Difficulty.Easy)
                        {
                            numProblem = 3;
                            for (int i = 0; i < 3; i++)
                            {
                                GenerateRandomProblems(numProblem);
                                Problem[] random = GenerateRandomProblems(numProblem);
                                Console.WriteLine(random[i].Message);
                                Console.Write("");
                                Ans = int.Parse(Console.ReadLine());
                                if (Ans == random[i].Answer)
                                {
                                    Qc = Qc + 1;
                                }
                                Qa = 3;d_Lv = 0;
                            }
                        }
                        if (LV == Difficulty.Normal)
                        {
                            numProblem = 5;
                            for (int i = 0; i < 5; i++)
                            {
                                GenerateRandomProblems(numProblem);
                                Problem[] random = GenerateRandomProblems(numProblem);
                                Console.WriteLine(random[i].Message);
                                Console.Write("");
                                Ans = int.Parse(Console.ReadLine());
                                if (Ans == random[i].Answer)
                                {
                                    Qc = Qc + 1;
                                }
                                Qa = 5;d_Lv = 1;
                            }
                        }
                        if (LV == Difficulty.Hard)
                        {
                            numProblem = 7;
                            for (int i = 0; i < 7; i++)
                            {
                                GenerateRandomProblems(numProblem);
                                Problem[] random = GenerateRandomProblems(numProblem);
                                Console.WriteLine(random[i].Message);
                                Console.Write("");
                                Ans = int.Parse(Console.ReadLine());
                                if (Ans == random[i].Answer)
                                {
                                    Qc = Qc + 1;
                                }
                                Qa = 7;d_Lv = 2;
                            }
                        }
                        t2 = DateTimeOffset.Now.ToUnixTimeSeconds();
                        Time = t2 - t1;
                        S1 = (Qc / Qa) * ((25 - Math.Pow(d_Lv, 2)) / Math.Max(Time, 25 - Math.Pow(d_Lv, 2))) * Math.Pow(((2 * (d_Lv)) + 1), 2);
                        S = S + S1;
                        Console.WriteLine("Score: {0}, Difficulty: {1}", S1, LV);
                        Console.WriteLine("select Menu 0 / 1 / 2");
                        nMenu = int.Parse(Console.ReadLine());

                        break;
                    case 1:
                        Console.Write("");
                        nlevel = int.Parse(Console.ReadLine());
                        while (nlevel != 0 && nlevel != 1 && nlevel != 2)
                        {
                            Console.WriteLine("Please input 0-2.");
                            Console.Write("");
                            nlevel = int.Parse(Console.ReadLine());
                        }
                        if (nlevel == 0)
                        {
                            LV = Difficulty.Easy;
                        }
                        if (nlevel == 1)
                        {
                            LV = Difficulty.Normal;
                        }
                        if (nlevel == 2)
                        {
                            LV = Difficulty.Hard;
                        }
                        Console.WriteLine("Score: {0}, Difficulty: {1}", S, LV);
                        Console.WriteLine("select Menu 0 / 1 / 2");
                        nMenu = int.Parse(Console.ReadLine());
                        break;

                }
            }
            if (nMenu == 2)
            {
                Console.WriteLine("press enter to quit");
            }
            while (nMenu != 0 && nMenu != 1 && nMenu != 2)
            {
                Console.WriteLine("Please input 0-2.");
                Console.Write("");
                nMenu = int.Parse(Console.ReadLine());
            }
            Console.ReadLine();
        }

    }
}
