using System.Collections.Generic;
using System.Linq;

namespace ParagraphWorkerAssessment
{
    public class ParagraphWorker
    {

        #region Solution Methods 
        
        //Count the number of palindrome words
        public List<string> CountPalindromeWords(string input)
        {
            List<string> palindromesList = new List<string>();

            //Split up at spaces to separate each word
            string[] inputArray = input.Split(" ");

            //Split our input and clean it up. Check if it's a palindrome
            foreach(var word in inputArray)
            {
                if(IsStringPalindrome(word))
                {
                    palindromesList.Add(CleanUpString(word));
                }
            }

            return palindromesList;
        }

        //Count the number of palindrome sentences
        public List<string> CountPalindromeSentences(string input)
        {
            List<string> palindromesList = new List<string>();

            //Get each sentence separated
            string[] arrayOfSentences = SplitUpSentences(input);

            foreach(var sentence in arrayOfSentences)
            {
                if(IsStringPalindrome(sentence))
                {
                    palindromesList.Add(sentence);
                }
            }
            return palindromesList;
        }

        //Lists the unique words in a paragraph and count how many times they're given
        public Dictionary<string, int> ListUniqueWordsInParagraph(string input)
        {
            //We want to keep the spaces so we can keep the words separate
            var cleanedUpInput = CleanUpString(input, false);

            //Split up the string, get the unique words in a list
            string[] splitInput = cleanedUpInput.Split(" ");
            List<string> uniqueWords = splitInput.Distinct().ToList();

            //Dictionary that will keep track of the word and how many times it shows up
            Dictionary<string, int> uniqueWordCounts = new Dictionary<string, int>();

            //Loop through each of the unique words, then loop through the whole array of the paragraph, 
            //counting how many times the word shows up as we go through each unique word.
            foreach(var word in uniqueWords)
            {
                int instances = 0;
                for(int splitIndex = 0; splitIndex < splitInput.Length; splitIndex++)
                {
                    if(word.Equals(splitInput[splitIndex]))
                    {
                        instances++;
                    }
                }
                uniqueWordCounts.Add(word, instances);
            }

            return uniqueWordCounts;
        }
        
        //Given a letter, find all words in the input paragraph that contain that letter
        public List<string> FindWordsContainingLetter(string input, string letter)
        {
            //get our input cleaned up and split it into words so we can search for the letter
            var cleanedUpInput = CleanUpString(input, false);
            string[] splitInput = cleanedUpInput.Split(" ");
            List<string> uniqueWords = splitInput.Distinct().ToList();

            List<string> wordsContainingLetter = new List<string>();

            //loop through the unique words and see which ones contain the letter we're looking for
            foreach(var word in uniqueWords)
            {
                if(word.Contains(letter))
                {
                    wordsContainingLetter.Add(word);
                }
            }

            return wordsContainingLetter;
        }

        #endregion

        #region Helper Methods

        #region Palindrome Helper Methods
        //Helper methods for Palindromes

        //Check if a single word is a palindrome
        bool IsStringPalindrome(string inputString)
        {
            bool isPalindrome = false;
            //Don't bother checking single letter words like 'a' or 'I'
            if(inputString.Length > 1)
            {
                string cleanedUpString = CleanUpString(inputString);
                string reversedString = ReverseString(cleanedUpString);
                if(cleanedUpString.Equals(reversedString))
                {
                    isPalindrome = true;
                }
            }

            return isPalindrome;
        }

        //Reverse an input string so we can later use it to check if it's a palindrome
        string ReverseString(string input)
        {
            int inputLength = input.Length - 1;
            string reverseWord = "";
            //Loop backwards through the input and reverse the string
            while(inputLength >= 0)
            {   
                reverseWord += input[inputLength];
                inputLength--;
            }
            return reverseWord; 
        }

        //Clean up the input and remove extra chars we don't want to interfere 
        //Has a flag to remove spaces from the string - does this by default
        string CleanUpString(string input, bool removeSpaces=true)
        {
            var cleanedUp = input.ToLower();
            string[] charsToRemove; 
            if(removeSpaces)
            {
                charsToRemove = new string[] {",", "'", "\"", ".", "!", "?", " "};
            }
            else
            {
                charsToRemove = new string[] {",", "'", "\"", ".", "!", "?"};
            }
            foreach(var character in charsToRemove)
            {
                cleanedUp = cleanedUp.Replace(character, "");
            }

            return cleanedUp;

        }

        //Split up input into an array of sentences
        string[] SplitUpSentences(string input)
        {
            return input.Split('.', '!', '?');
        } 

        #endregion

        #endregion
    }
}
