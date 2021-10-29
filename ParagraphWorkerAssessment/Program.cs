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
                Console.WriteLine("\n-------------------------\n");    

                #region Palindrome Words Count
                //Palindrome Words            
                var palindromeWords = paragraphWorker.CountPalindromeWords(input);

                //Output the results of palindrome words
                string wordResults = "";
                if(palindromeWords.Count > 0)
                {
                    wordResults = "Found " + palindromeWords.Count + " palindrome word(s), and they are: ";
                    foreach(var palindrome in palindromeWords)
                    {
                        wordResults += "\n" + palindrome; 
                    }
                }
                else
                {
                    wordResults = "No palindrome words found in the input."; 
                }

                Console.WriteLine(wordResults);

                Console.WriteLine("\n-------------------------\n");
                #endregion

                #region Palindrome Sentences Count
                //Palindrome Sentences
                var palindromeSentences = paragraphWorker.CountPalindromeSentences(input);

                //Output our results
                string sentenceResults = "";
                if(palindromeSentences.Count > 0)
                {
                    sentenceResults = "Found " + palindromeSentences.Count + " palindrome sentence(s), and they are: ";
                    foreach(var palindrome in palindromeSentences)
                    {
                        sentenceResults += "\n" + palindrome; 
                    }
                }
                else
                {
                    sentenceResults = "No palindrome sentences found in the input."; 
                }

                Console.WriteLine(sentenceResults);

                Console.WriteLine("\n-------------------------\n");

                #endregion

                #region List Unique Words of Paragraph and Count Instances
                //Create the dictionary of unique words
                var wordDictionary = paragraphWorker.ListUniqueWordsInParagraph(input);
                
                //Output the results
                Console.WriteLine("Here are the unique words and how many times they show up: ");
                foreach(var word in wordDictionary)
                {
                    Console.WriteLine("Word: " + word.Key + " | Instances: " + word.Value);   
                }

                Console.WriteLine("\n-------------------------\n");
                #endregion
                
                #region List All Words Containing a Given Letter

                //Get the letter from the user
                bool needLetter = true;
                string letterToSearch = "";

                while(needLetter)
                {
                    Console.WriteLine("What letter would you like to use to see which words it is in?");
                    letterToSearch = Console.ReadLine();
                    if(letterToSearch.Length > 1)
                    {
                        Console.WriteLine("Please input a single letter.");
                    }
                    else if(!Char.IsLetter(letterToSearch, 0))
                    {
                        Console.WriteLine("Please input a valid alphabetical letter.");
                    }
                    else
                    {
                        needLetter = false;
                    }
                }

                //Get the words with the letter
                var wordsWithLetter = paragraphWorker.FindWordsContainingLetter(input, letterToSearch);

                if(wordsWithLetter.Count > 0)
                {
                    Console.WriteLine("These are the words with the letter " + letterToSearch + ".");
                }
                else
                {
                    Console.WriteLine("There are no words with the letter " + letterToSearch + ".");
                }

                //Output the results
                foreach(var word in wordsWithLetter)
                {
                    Console.WriteLine(word);
                }

                Console.WriteLine("\n-------------------------\n");
                #endregion
                
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
