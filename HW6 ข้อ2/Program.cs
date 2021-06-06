using System;

namespace HW6_ข้อ2
{
    class Program
    {
        static void Main(string[] args)
        {
            double income,expenses,sumIn = 0,sumEx=0,SUM;
            string day;
            char input;
            int i = 1,j=1;
            while (i > 0)
            {
                Console.Write("input day :");
                day = Console.ReadLine();
                Console.Write("input income :");
                income = double.Parse(Console.ReadLine());
                Console.Write("input expenses :");
                expenses = double.Parse(Console.ReadLine());

                sumIn = sumIn + income;
                sumEx = sumEx + expenses;

                Console.WriteLine("A for add more || S for summary");
                input = char.Parse(Console.ReadLine());
                if (input == 'A')
                {
                    i++;
                }
                else if (input == 'S')
                {
                    i = 0;
                }
                else
                {
                    while (j > 0)
                    {
                        Console.WriteLine("Input only A or S");
                        input = char.Parse(Console.ReadLine());
                        if (input == 'A')
                        {
                            j++;
                        }
                        if (input == 'S')
                        {
                            SUM = sumIn - sumEx;
                            Console.WriteLine("Your Finance");
                            Console.WriteLine("{0}", SUM);
                            if (SUM > 0)
                            {
                                Console.Write("savings money = :{0}", SUM);
                            }
                            else
                            {
                                Console.Write("Try to save some money for your yourself");
                            }
                        }
                        else
                        {
                            j++;
                        }
                    }
                    
                    i++;
                }

            }
            SUM = sumIn - sumEx;
            Console.WriteLine("Your Finance");
            Console.WriteLine("{0}", SUM);
            if (SUM > 0)
            {
                Console.Write("savings money = :{0}", SUM);
            }
            else
            {
                Console.Write("Try to save some money for your yourself");
            }
            Console.ReadLine();
        }

    }
    
}
