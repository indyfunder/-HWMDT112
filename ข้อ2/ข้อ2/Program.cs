using System;

namespace ข้อ2
{
    class Program
    {
        static bool IsValidSequence(string halfDNASequence)
        {
            foreach (char nucleotide in halfDNASequence)
            {
                if (!"ATCG".Contains(nucleotide))
                {
                    return false;
                }
            }
            return true;
        }
        static string ReplicateSeqeunce(string halfDNASequence)
        {
            string result = "";
            foreach (char nucleotide in halfDNASequence)
            {
                result += "TAGC"["ATCG".IndexOf(nucleotide)];
            }
            return result;
        }

        static void Main(string[] args)
        {
            string DNA ;
            bool isValid;
            int run = 1;
            while (run == 1)
            {
                Console.WriteLine("input DNA");
                DNA = Console.ReadLine();
                isValid = IsValidSequence(DNA);
                if (isValid == true)
                {
                    Console.Write("Current half DNA sequence :{0}", DNA);
                    Console.Write("\n");
                    Console.Write("Do you want to replicate it ? (Y/N) : ");
                    char Ans1;
                    Ans1 = Char.Parse(Console.ReadLine());
                    int run1 = 1;
                    while (run1 == 1)
                    {                        
                        if (Ans1 == 'Y')
                        {
                            string Ans2;
                            Ans2 = ReplicateSeqeunce(DNA);
                            Console.WriteLine("Replicated half DNA sequence : {0}", Ans2);                          
                        }
                        run1 = 2;
                        if (Ans1 == 'N')
                        {
                            run1 = 2;
                        }
                        else
                        {
                            Console.WriteLine("Please input Y or N : ");
                            Ans1 = Char.Parse(Console.ReadLine());
                        }
                    }                    
                }
                if(isValid==false)

                {
                    Console.WriteLine("That half DNA sequence is invalid.");
                }
                    
                    Console.WriteLine("Do you want to process another sequence ? (Y/N) ");
                    char Ans3;
                    Ans3 = char.Parse(Console.ReadLine());
                    
                    int run2 = 1;
                    while (run2 == 1)
                    {
                        if (Ans3 == 'Y')
                        {
                            run2 = 2;
                        }
                        else if (Ans3 == 'N')
                        {
                            run2 = 2;
                            run = 2;
                        }
                        else
                        {
                            Console.Write("Please input Y or N.");
                            Ans3 = char.Parse(Console.ReadLine());
                        }
                    }             
            }
            Console.ReadLine();
        }        
    }
}
