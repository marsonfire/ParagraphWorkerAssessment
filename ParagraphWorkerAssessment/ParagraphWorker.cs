using System.Collections.Generic;

namespace ParagraphWorkerAssessment
{
    public class ParagraphWorker
    {

        #region Solution Methods 
        //Count the number of palindrome words
        public string CountPalindromeWords(string input)
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

            //return the results
            if(palindromesList.Count > 0)
            {
                string results = "Found " + palindromesList.Count + " palindrome word(s), and they are: ";
                foreach(var palindrome in palindromesList)
                {
                    results += "\n" + palindrome; 
                }
                return results;
            }
            else
            {
                return "No palindrome words found in the input."; 
            }
        }

        //Count the number of palindrome sentences
        public string CountPalindromeSentences(string input)
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

             //return our results
            if(palindromesList.Count > 0)
            {
                string results = "Found " + palindromesList.Count + " palindrome sentence(s), and they are: ";
                foreach(var palindrome in palindromesList)
                {
                    results += "\n" + palindrome; 
                }
                return results;
            }
            else
            {
                return "No palindrome sentences found in the input."; 
            }
        }

        //Lists the unique words in a paragraph and count how many times they're given
        public string ListUniqueWordsInParagraph(string input)
        {
            return "";
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

        //clean up the input and remove extra chars we don't want to interfere 
        string CleanUpString(string input)
        {
            var cleanedUp = input.ToLower();
            var charsToRemove = new string[] {",", "'", "\"", ".", "!", "?", " "};
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
