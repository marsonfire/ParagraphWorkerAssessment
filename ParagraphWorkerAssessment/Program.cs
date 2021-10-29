using System;

namespace ParagraphWorkerAssessment
{
    class Program
    {
        static void Main(string[] args)
        {
            ParagraphWorker paragraphWorker = new ParagraphWorker();

            bool programRunning = true;
            while(programRunning)
            {
                //Get the paragraph from the user
                Console.WriteLine("Input a paragraph for analysis:");
                string input = Console.ReadLine();

                //Output the number of palindrome words
                Console.WriteLine("\n-------------------------\n");                
                Console.WriteLine(paragraphWorker.CountPalindromeWords(input));
                Console.WriteLine("\n-------------------------\n");
                
                //Output the number of palindrome sentences
                Console.WriteLine(paragraphWorker.CountPalindromeSentences(input));
                Console.WriteLine("\n-------------------------\n");

                Console.WriteLine("Continue? Y or N?");
                string answer = Console.ReadLine();
                if(!answer.ToLower().Equals("y"))
                {
                    programRunning = false;
                }
            }
        }
    }
}
