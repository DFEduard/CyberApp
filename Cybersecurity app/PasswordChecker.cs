using System;
using System.Collections.Generic;

namespace Cybersecurity_app
{
    public class PasswordChecker
    {
        //Store the total score
        private double score;

        //
        // Additions 
        //
        //Store the score for number of characters
        private int noOfCharactersScore;
        //Store the score for Uppercase Letters
        private int upperLettersScore;
        //Store the score for Lowecase Letters
        private int lowerLettersScore;
        //Store the score for Numbers
        private int numbersScore;
        //Store the score for Symbols
        private int symbolsScore;
        //Store the score for Middle Numbers or Symbols
        private int middleNumbersOrSymbolsScore;
        //Store the score for Requirements 
        private int requirementsScore;

        //
        // Deductions
        //
        //Store the score for Letters only
        private int lettersOnlyScore;
        //Store the score for Numbers Only
        private int numbersOnlyScore;
        //Store the score for Repeat Characters (lowercase and uppercase)
        private int repeatCharactersScore;
        //Store the score for Consecutive Uppercase Letters
        private int consecutiveUpperCaseLettersScore;
        //Store the score for Consecutive Lowercase Letters
        private int consecutiveLowerCaseLettersScore;
        //Store the score for Consecutive Numbers
        private int consecutiveNumbersScore;
        //Store the score for Sequential Letters
        private int sequentialLettersScore;
        //Store the score for Sequential Numbers
        private int sequentialNumbersScore;
        //Store the score Sequential Symbols
        private int sequentialSymbolsScore;
    
        //Array of all special characters (symbols)
        private char[] specialCharacters = { '!', '@', '#', '$', '%', '^', '&', '*', '(', ')',
                                             '_', '-', '+', '=', '{', '}', '[', ']', ';', ':',
                                             '"', '/','|', '?', '~', '`', '£', '<', '>',' '};

       

        
 
        
        
        /// <summary>
        /// Function used to calculate the strenght of a password
        /// </summary>
        /// <param name="password">Password</param>
        public void StrenghtCalculator(string password)
        {

            //Used to store the current character as old
            char oldUpperChar = ' ';
            //Store the total number of uppercase letters
            int totalNoOfUpperCases = 0;
            //Used to store the current character as old
            char oldLowerChar = ' ';
            //Store the total number of lowercase letters
            int totalNoOfLowerCases = 0;
            //Store the total number of digits 
            int totalNoOfDigits = 0;
            ////Store the total number of consecutive uppercase letters
            //int totalNoConsecutiveUpperCases = 0;
            ////Store the total number of consecutive lowercase letters
            //int totalNoConsecutiveLowerCases = 0;

            int totalNoOfLetters = 0;

            //Store the total number of symbols
            int totalNoOfSymbols = 0;
            //Store the total number of requirements (maximum is 5)
            int totalNoOfRequirements = 0;
            //Flag to check uppercase letter requirement
            bool requirementUppercaseLetter = false;
            //Flag to check lowercase letter requirement
            bool requirementLowercaseLetter = false;
            //Flag to check numbers requirement
            bool requirementNumbers = false;
            //Flag to check symbols requirement
            bool requirementSymbols = false;
            //Store the total number of symbols and numbers excluding the first and the last ones 
            int totalNoOfNnS = 0;

            bool consecutiveUppercase = false;
            int totalNoOfConsUppercase = 0;
            bool consecutiveLowercase = false;
            int totalNoOfConseLowercase = 0;


            //Calculate number of characters score
            noOfCharactersScore = password.Length * 4;

            //Requiement 1. Password must be min 8 characters in length
            if (password.Length >= 8)
            {
                //Increase by one the total number of requirements
                totalNoOfRequirements++;
            }


        
            //Store all characters of the password
            char[] characters = password.ToCharArray();

            //Loop through each character from the password 
            for (int i = 0; i < characters.Length; i++)
            {

               //Check if current character is uppercase
                if (char.IsUpper(characters[i]))
                {

                    //Increase by one the total number of upper cases
                    totalNoOfUpperCases++;

                    //Calculate the score for uppercase letters (positive score)
                    upperLettersScore = (password.Length - totalNoOfUpperCases) * 2;

                    //Check if uppercase requirements has been met 
                    if (!requirementUppercaseLetter)
                    {
                        //Set flag to true (only one time must be checked)
                        requirementUppercaseLetter = true;
                        //Increase by one the total number of requirements
                        totalNoOfRequirements++;
                    }


                    //Check flag to see if pervious character was lowercase
                    if (!consecutiveUppercase)
                    {
                        //Set flag to true
                        consecutiveUppercase = true;
                    }
                    else // Occure when previous character was uppercase
                    {
                        //Increase by one the total number of consecutive uppercases
                        totalNoOfConsUppercase++;
                    }

                    //Check if lowercase flag is true (means prvious character was lowercase)
                    if (consecutiveLowercase)
                    {
                        //Set flag to false
                        consecutiveLowercase = false;
                    }

                    //Increase value by one of the total number of letters
                    totalNoOfLetters++;

                    //Store current uppercase character
                    oldUpperChar = characters[i];

                }
                else if (char.IsLower(characters[i])) //Check to see if current character is lowercase
                {

                    //Increase by one the total number of lower characters 
                    totalNoOfLowerCases++;

                    //Calculate the score for lowercase letters
                    lowerLettersScore = (password.Length - totalNoOfLowerCases) * 2;
                    

                    //Check flag to see if previous character was uppercase
                    if (!consecutiveLowercase)
                    {
                        //Set flag to true
                        consecutiveLowercase = true;
                    }
                    else //Occure when previous character was lowercase 
                    {
                        //Increase by one the total number of consecutive lowercases
                        totalNoOfConseLowercase++;
                    }

                    //Check if uppercase flag is true (means previous character was uppercase)
                    if (consecutiveUppercase)
                    {
                        consecutiveUppercase = false;
                    }

                    //Check if lowercase letter requirement has been met
                    if (!requirementLowercaseLetter)
                    {
                        //Set flag to true (only one time must be checked)
                        requirementLowercaseLetter = true;
                        //Increatse by one the total number of requirements
                        totalNoOfRequirements++;
                    }

                    //Increase value by one of the total number of letters
                    totalNoOfLetters++;

                    //Store current lowercase character
                    oldLowerChar = characters[i];

                }
                else if (char.IsDigit(characters[i]))
                {
                    //Check if numbers requirements has been met
                    if (!requirementNumbers)
                    {
                        //Set flag to true (only one time must be checked)
                        requirementNumbers = true;
                        //Increase by one the total number of requirements;
                        totalNoOfRequirements++;
                    }

                    //Don't count first and last characters
                    if (i != 0 && i != password.Length -1)
                    {
                        //Increase by one the total number of numbers and symbols used to calculate the middle numbers or symbols score
                        totalNoOfNnS++;
                    }

                    //Increase the total number of digits by one
                    totalNoOfDigits++;

                    //Calculate the score for numbers (positive score)
                    numbersScore = totalNoOfDigits * 4;

                   
                }
                else
                {
                    //Check if password contain current symbols (uppercases, lowercases and digits have been checked)
                    if (password.Contains(characters[i].ToString()))
                    {
                        //Check if symbol requirement has been met
                        if (!requirementSymbols)
                        {
                            //Set flag to true (only one time must be checked)
                            requirementSymbols = true;
                            //Increase by one the total number of requirements
                            totalNoOfRequirements++;
                        }

                        //Don't count first and last characters
                        if (i != 0 && i != password.Length - 1)
                        {
                            //Increase by one the total number of numbers and symbols used to calculate the middle numbers or symbols score
                            totalNoOfNnS++;
                        }

                        //Increase the total number of symbols by one
                        totalNoOfSymbols++;
                        //Calculate the score for symbols (positive score)
                        symbolsScore = totalNoOfSymbols * 6;
                    }
 
                }

                
            }


            //Check the total number of letters with the password length
            if (totalNoOfLetters == password.Length) // Password contains only letters if equal 
            {
                
                //Store the total number of letters (negative score)
                lettersOnlyScore = totalNoOfLetters;
            }

            //Check if the total number digits is equal with the password length (means that password contains only numbers)
            if (totalNoOfDigits == password.Length)
            {
                //Store the total number of digits to only numbers score (negative score)
                numbersOnlyScore = totalNoOfDigits;
                numbersScore = 0;

            }

            //Check if the total number of requirements is bigger than 1
            if (totalNoOfRequirements >= 4)
            {
                //Calculate the requirements score 
                requirementsScore = totalNoOfRequirements * 2;
            }
            else
            {
                //Requirements score is equal with 0 
                requirementsScore = 0;
            }
            

            //Calculate the middle numbers and symbols score
            middleNumbersOrSymbolsScore = totalNoOfNnS * 2;

            //Calculate the score for consecutive uppercase letters (negative score)
            consecutiveUpperCaseLettersScore = totalNoOfConsUppercase * 2;

            //Calculate the score for consecutive lowercase letters (negative score)
            consecutiveLowerCaseLettersScore = totalNoOfConseLowercase * 2;



        }


        private void CalculateFinalScore()
        {
            score = noOfCharactersScore + upperLettersScore + lowerLettersScore + numbersScore + symbolsScore + middleNumbersOrSymbolsScore + requirementsScore
                    - lettersOnlyScore - numbersOnlyScore - consecutiveUpperCaseLettersScore - consecutiveLowerCaseLettersScore;
            
        }

        private void ClearScoreData()
        {
            //noOfCharactersScore = 0;
            //upperLettersScore = 0;
            //totalNoOfUpperCases = 0;
            //totalNoConsecutiveUpperCases = 0;
            //lowerLettersScore = 0;
            //totalNoOfLowerCases = 0;
            //totalNoConsecutiveLowerCases = 0;
            //numbersScore = 0;
            //numbersOnlyScore = 0;
            //totalNoOfDigits = 0;
            //totalNoOfSymbols = 0;
            //symbolsScore = 0;

        }

        /// <summary>
        /// Score: 0-49 Very Week | 50-59 Weak | 60-79 OK | 80-89 Strong | 100-above Very Strong
        /// </summary>
        /// <returns></returns>
        public double GetScorePercent()
        {
            CalculateFinalScore();
            return score;
        }

        public string GetScoreString()
        {
            string result = "";
            return result;
        }

    }
}
