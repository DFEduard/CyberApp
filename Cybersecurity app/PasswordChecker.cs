using System;
using System.Collections.Generic;

namespace Cybersecurity_app
{

    /// <summary>
    /// Class: Encryption
    /// Write by: Florentin Eduard Decu
    /// Description: This class can be used to check the password. Password will be measured and a score will be given
    /// Score info:
    ///     Positive score 
    ///     1. Number of characters         | Logic: number of characters * 4
    ///     2. Uppercase Letters            | Logic: (number of characters - number of uppercase letters) * 2
    ///     3. Lowercase Letters            | Logic: (number of characters - number of lowercase letters) * 2
    ///     4. Numbers                      | Logic: number of digits * 4
    ///     5. Symbols                      | Logic: number of symbols * 6
    ///     6. Middle Numbers or Symbols    | Logic: number of middle symbols or digits * 2
    ///     7. Requirements                 | Logic: numbers of requirements * 2              
    ///        Requirements: 7.1. Password must be minimum 8 characters in lenght 
    ///                      7.2. At least one uppercase letter
    ///                      7.3. At least one lowercase letter
    ///                      7.4. At lest one digit
    ///                      7.5. At least one symbol 
    ///     Negative score
    ///     1. Letters only                     | Logic: the total number of the postive score minus total number of letter characters
    ///     2. Numbers only                     | Logic: the total number of the postive score minus total number of digits characters
    ///     3. Repeated characters              | Logic: the total number of the postive score minus the total number of repeated characters
    ///     4. Consecutive uppercase letters    | Logic: the total number of consecutive characters * 2 (e.g. ABCDEF = 4 characters, first and last are not take in consideration)
    ///     5. Consecutive lowercase letters    | Logic: the total number of consecutive characters * 2 (e.g. abcdef = 4 characters, first and last are not take in consideration)
    ///     6. Consecutive numbers              | Logic: the total number of consecutive numbers *2 (e.g. 123456 = 4 characters, first and last are not take in consideration)
    ///     7. Sequential letters               | Logic: the total number of sequential letters * 3 (e.g. 12abc23def = 2, ab and c result 1, de and f result 1, total = 2)
    ///     8. Sequential numerbs               | Logic: the total number of sequnetial numbers * 3 (e.g. ab123de456 = 2, 12 and 3 result 1, 45 and 6 result 1, total = 2)
    ///     9. Sequential symbols               | Logic: the total number of sequential symbols * 3 (e.g. 1a!@#2b$%^ = 2, !@ and # result 1, $% and ^ result 1, total = 2)
    ///     
    ///     Final score = total of the postive score - total of the negative score 
    ///                   
    /// </summary>
    public class PasswordChecker
    {
        //Store the total score
        private double score;

        //
        // Additions Points
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
        // Deductions Points 
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


        //
        // Variable used for logic
        //

        //Used to check the special symbols
        private string symbols = "!@#$%^&*()-=[];',./{}:|`~<>?";
        private char[] specialCharacters;
        //Used to check the consecutiver letters
        private string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private char[] alphabetCharacters;
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
        //Store the total number of letters
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
        //Flag to check consecutive uppercase letter
        bool consecutiveUppercase = false;
        //Store the total number of consecutive uppercase letters
        int totalNoOfConsUppercase = 0;
        //Flag to check consecutive lowercase letter
        bool consecutiveLowercase = false;
        //Store the total number of consecutive lowercase letters
        int totalNoOfConseLowercase = 0;
        //Flag to check consecutive numbers 
        bool consecutiveNumbers = false;
        //Store the total number of consecutive numbers
        int totalNoOfConseNumbers = 0;
        //Flag to check if there is more than three sequential letters e.g: ABC and not ABX
        bool sequentialLetters = false;
        //Store the total number of sequential letters e.g: ABC +1, ABX +0
        int totalNoOfSqLetters = 0;
        //Store sequential letters
        string storeSqLetters = "";
        //Flag to check if there is more than three sequential numbers e.g: 123 and not 124
        bool sequqentialNumbers = false;
        //Store the total number of sequential letters. e.g: 123 +1, 124 +0
        int totalNoOfSqNumbers = 0;
        //Store sequential numbers
        string storeSqNumbers = "";
        //Flag to check if there is more tha three sequential symbols 
        bool sequentialSymbols = false;
        //Store the total number of sequential symbols. Sequential symbols are: !@#$%^&*()
        int totalNoOfSqSymbols = 0;
        //Store sequential symbols
        string storeSqSymbols = "";
        //Store the total number of repeteat uppercase characters
        int totalNoOfUpperRepeatCharacters = 0;
        //Store the total number of repeteat lowercase characters
        int totalNoOfLowerRepeatCharacters = 0;
        //Store the total number of repeteat numbers characters
        int totalNoOfNumbersRepeatCharacters = 0;
        //Store the total number of repeteat symbols characters
        int totalNoOfSymbolsRepeatCharacters = 0;
        //Store repeated characters
        string storeRepeatCharacters = "";

        public int TotalNoOfRequirements { get => totalNoOfRequirements; private set => totalNoOfRequirements = value; }
        public int TotalNoOfUpperCases { get => totalNoOfUpperCases; private set => totalNoOfUpperCases = value; }
        public int TotalNoOfLowerCases { get => totalNoOfLowerCases; private set => totalNoOfLowerCases = value; }
        public int TotalNoOfDigits { get => totalNoOfDigits; private set => totalNoOfDigits = value; }
        public int TotalNoOfSymbols { get => totalNoOfSymbols; private set => totalNoOfSymbols = value; }
        public int TotalNoOfNnS { get => totalNoOfNnS; private set => totalNoOfNnS = value; }


        /// <summary>
        /// Function used to calculate the strenght of a password
        /// </summary>
        /// <param name="password">Password</param>
        public void StrengthCalculator(string password)
        {
            ClearData();

            //Store all symbols into an array of characters
            specialCharacters = symbols.ToCharArray();
            //Store all letters of the alphabet into an array of characters
            alphabetCharacters = alphabet.ToCharArray();

            

            //Calculate number of characters score
            noOfCharactersScore = password.Length * 4;

            //Requiement 1. Password must be min 8 characters in length
            if (password.Length >= 8)
            {
                //Increase by one the total number of requirements
                //Variable used to calculate the score for requirements
                TotalNoOfRequirements++;
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
                    TotalNoOfUpperCases++;

                    //Calculate the score for uppercase letters (positive score)
                    upperLettersScore = (password.Length - TotalNoOfUpperCases) * 2;

                    //Check if uppercase requirements has been met 
                    if (!requirementUppercaseLetter)
                    {
                        //Set flag to true (only one time must be checked)
                        requirementUppercaseLetter = true;

                        //Increase by one the total number of requirements
                        //Variable used to calculate the requirements score 
                        TotalNoOfRequirements++;
                    }


                    //Check flag to see if pervious character was lowercase
                    if (!consecutiveUppercase)
                    {
                        //Set flag to true
                        consecutiveUppercase = true;
                    }
                    else // Occure if previous character was uppercase letter
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

                    //Check if number flag is true (means previous character was a number)
                    if (consecutiveNumbers)
                    {
                        consecutiveNumbers = false;
                    }
                    //Increase value by one of the total number of letters
                    //Variable used to calculate the letters only score
                    totalNoOfLetters++;

                    //Store current uppercase character
                    oldUpperChar = characters[i];


                    //Check to see if is any character store
                    if (storeRepeatCharacters.Length != 0)
                    {
                        //Check for duplicates
                        if (storeRepeatCharacters.Contains(characters[i].ToString()))
                        {
                            //Get the index of the character stored based on the current character
                            int index = storeRepeatCharacters.IndexOf(characters[i]);

                            //Check if the character stored is uppercase
                            if (char.IsUpper(storeRepeatCharacters[index]))
                            {
                                //Increase by one the total number of uppercase characters
                                //Variable used to calculate the repeat characters score 
                                totalNoOfUpperRepeatCharacters++;
                            }
                        }
                    }

                }
                else if (char.IsLower(characters[i])) //Check to see if current character is lowercase
                {

                    //Increase by one the total number of lower characters 
                    TotalNoOfLowerCases++;

                    //Calculate the score for lowercase letters
                    lowerLettersScore = (password.Length - TotalNoOfLowerCases) * 2;
                    

                    //Check flag to see if previous character was uppercase
                    if (!consecutiveLowercase)
                    {
                        //Set flag to true
                        consecutiveLowercase = true;
                    }
                    else //Occure if previous character was lowercase letter
                    {
                        //Increase by one the total number of consecutive lowercases
                        totalNoOfConseLowercase++;
                    }

                    //Check if uppercase flag is true (means previous character was uppercase)
                    if (consecutiveUppercase)
                    {
                        //Set flag to false
                        consecutiveUppercase = false;
                    }

                    //Check if number flag is true (means previous character was a number)
                    if (consecutiveNumbers)
                    {
                        consecutiveNumbers = false;
                    }

                    //Check if lowercase letter requirement has been met
                    if (!requirementLowercaseLetter)
                    {
                        //Set flag to true (only one time must be checked)
                        requirementLowercaseLetter = true;

                        //Increatse by one the total number of requirements
                        //Variable used to calculate the score for requirements
                        TotalNoOfRequirements++;
                    }

                    //Increase value by one of the total number of letters
                    //Variable used to calculate the letters only score
                    totalNoOfLetters++;

                    //Store current lowercase character
                    oldLowerChar = characters[i];

                    //Check to see if is any character store
                    if (storeRepeatCharacters.Length != 0)
                    {
                        //Check for duplicates
                        if (storeRepeatCharacters.Contains(characters[i].ToString()))
                        {
                            //Get the index of the character stored based on the current character
                            int index = storeRepeatCharacters.IndexOf(characters[i]);

                            //Check if the character stored is lowercase
                            if (char.IsLower(storeRepeatCharacters[index]))
                            {
                                //Increase by one the total number of lowerscase characters
                                //Variable used to calculate the repeat characters score 
                                totalNoOfLowerRepeatCharacters++;
                            }
                        }
                    }

                }
                else if (char.IsDigit(characters[i]))
                {

                    //Increase the total number of digits by one
                    TotalNoOfDigits++;

                    //Calculate the score for numbers (positive score)
                    numbersScore = TotalNoOfDigits * 4;

                    //Don't count first and last characters
                    if (i != 0 && i != password.Length - 1)
                    {
                        //Increase by one the total number of numbers and symbols used to calculate the middle numbers or symbols score
                        //Variable used to calculate the middle numbers or symbols score
                        TotalNoOfNnS++;
                    }

                    //Check if numbers requirements has been met
                    if (!requirementNumbers)
                    {
                        //Set flag to true (only one time must be checked)
                        requirementNumbers = true;
                        //Increase by one the total number of requirements
                        //Variable used to calculate the score for requirements
                        TotalNoOfRequirements++;
                    }

                    //Check flag to see if previous character was a number 
                    if (!consecutiveNumbers)
                    {
                        //Set flag to true 
                        consecutiveNumbers = true;
                    }
                    else //Occure if previous character was a number
                    {
                        //Increase value by one of the total number of consecutive numbers.
                        // Variable used to calculate the score for consecutive numbers
                        totalNoOfConseNumbers++;
                    }

                    //Check if uppercase flag is true (means previous character was uppercase)
                    if (consecutiveUppercase)
                    {
                        consecutiveUppercase = false;
                    }

                    //Check if lowercase flag is true (means prvious character was lowercase)
                    if (consecutiveLowercase)
                    {
                        //Set flag to false
                        consecutiveLowercase = false;
                    }

                    //Check if sequential number is false (means that was never use or previous character was a letter)
                    if (!sequqentialNumbers)
                    {
                        //Set flag to true
                        sequqentialNumbers = true;
                    }

                    //Check if sequential number is true
                    if (sequqentialNumbers)
                    {
                        //Store current number 
                        storeSqNumbers += characters[i].ToString();
                    }

                    //Check is sequential flag is true (means that previous character was a letter)
                    if (sequentialLetters)
                    {
                        //Set flag to false
                        sequentialLetters = false;
                    }

                    //Check is sequential flag is true (means that previous character was a symbol)
                    if (sequentialSymbols)
                    {
                        //Set flag to false
                        sequentialSymbols = false;
                    }

                    //Check to see if is any character store
                    if (storeRepeatCharacters.Length != 0)
                    {
                        //Check for duplicates
                        if (storeRepeatCharacters.Contains(characters[i].ToString()))
                        {
                            //Increase by one the total number of digits characters
                            //Variable used to calculate the repeat characters score 
                            totalNoOfNumbersRepeatCharacters++;
                        }
                    }
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
                            //Variable used to calculate the letters only score
                            TotalNoOfRequirements++;
                        }

                        //Don't count first and last characters
                        if (i != 0 && i != password.Length - 1)
                        {
                            //Increase by one the total number of numbers and symbols used to calculate the middle numbers or symbols score
                            //Variable used to calculate the middle numbers or symbols score
                            TotalNoOfNnS++;
                        }

                        //Increase the total number of symbols by one
                        TotalNoOfSymbols++;
                        //Calculate the score for symbols (positive score)
                        symbolsScore = TotalNoOfSymbols * 6;


                        if (!sequentialSymbols)
                        {
                            sequentialSymbols = true;
                        }

                        if (sequentialSymbols)
                        {
                            storeSqSymbols += characters[i].ToString();
                        }

                        //Reset other sequentials flags to false
                        if (sequentialLetters)
                        {
                            sequentialLetters = false;
                        }

                        if (sequqentialNumbers)
                        {
                            sequqentialNumbers = false;
                        }
                    }

                    //Check to see if is any character store
                    if (storeRepeatCharacters.Length != 0)
                    {
                        if (storeRepeatCharacters.Contains(characters[i].ToString()))
                        {
                            //Increase by one the total number of symbol characters
                            //Variable used to calculate the repeat characters score 
                            totalNoOfSymbolsRepeatCharacters++;
                        }
                    }

                }

                if (char.IsLetter(characters[i]))
                {
                    //Check if sequential flag for letters is false
                    if (!sequentialLetters)
                    {
                        //Set flag to true
                        sequentialLetters = true;
                    }

                    //Check if sequential flag is true
                    if (sequentialLetters)
                    {
                        //Store current letter
                        storeSqLetters += characters[i].ToString();
                    }

                    //Set if Sequential flag is true (means that previous character was a number)
                    if (sequqentialNumbers)
                    {
                        //Set flag to false
                        sequqentialNumbers = false;
                    }

                    //Check is sequential flag is true (means that previous character was a symbol)
                    if (sequentialSymbols)
                    {
                        //Set flag to false
                        sequentialSymbols = false;
                    }
                }


                storeRepeatCharacters = characters[i].ToString();

            }


            //Check the total number of letters with the password length
            if (totalNoOfLetters == password.Length) // Password contains only letters if equal 
            {
                //Store the total number of letters (negative score)
                lettersOnlyScore = totalNoOfLetters;
            }

            //Check if the total number digits is equal with the password length (means that password contains only numbers)
            if (TotalNoOfDigits == password.Length)
            {
                //Store the total number of digits to only numbers score (negative score)
                numbersOnlyScore = TotalNoOfDigits;
                numbersScore = 0;
            }

            //Check if the total number of requirements is bigger than 1
            if (TotalNoOfRequirements >= 4)
            {
                //Calculate the requirements score 
                requirementsScore = TotalNoOfRequirements * 2;
            }
            else
            {
                //Requirements score is equal with 0 
                requirementsScore = 0;
            }
            

            //Calculate the middle numbers and symbols score
            middleNumbersOrSymbolsScore = TotalNoOfNnS * 2;

            //Calculate the score for consecutive uppercase letters (negative score)
            consecutiveUpperCaseLettersScore = totalNoOfConsUppercase * 2;

            //Calculate the score for consecutive lowercase letters (negative score)
            consecutiveLowerCaseLettersScore = totalNoOfConseLowercase * 2;

            //Calculate the score for consecutive numbers (negative score)
            consecutiveNumbersScore = totalNoOfConseNumbers * 2;


            //Counter for sequential numbers
            int sequentialCounter = 0;

            //Make all the letters uppercase 
            storeSqLetters = storeSqLetters.ToUpper();

            //Loop through all letters 
            for (int i = 0; i < storeSqLetters.Length; i++)
            {
                //Check if index will go out of range 
                if ((i+1) < storeSqLetters.Length)
                {
                    //Calculate if the difference between the next index of the letter - current index of the letter is equal wiht 1
                    //Example: storeLetters = ABCF. In first loop i + 1 is B from storeLetters and returns the index of B from alphabet which is 1
                    //         Then i is A from storeLetters and returns the index of A from alphabet whihc is 0
                    //         The difference between two indexes is 1. If there will be 2 or more similar calculations then will be consider sequential letters in password 

                    if ((alphabet.IndexOf(storeSqLetters[i + 1]) - alphabet.IndexOf(storeSqLetters[i])) == 1)
                    {
                        //Increase value by one of the counter 
                        sequentialCounter++;

                        //Check counter
                        if (sequentialCounter >= 2)
                        {
                            //Increase value by one of the total number of sequential letters 
                            //Variable used to calculate sequential letters score
                            totalNoOfSqLetters++;
                        }
                    }
                    else
                    {
                        //Reset counter as the sequential will no longer be taken in consideration
                        sequentialCounter = 0;
                    }
                }
               
            }

            //Calculate Sequential Letters (negative score)
            sequentialLettersScore = totalNoOfSqLetters * 3;

            //Used to store current number as old number
            int oldNumber = -1;
            //Reset to 0
            sequentialCounter = 0;

            //Loop through all stored numbers
            for (int i = 0; i < storeSqNumbers.Length; i++)
            {
               //Check variable for default value 
                if (oldNumber != -1)
                {
                    //Check if old number +1 is equal to current number (means is sequential)
                    if ((oldNumber + 1).ToString() == storeSqNumbers[i].ToString())
                    {
                        //Increase value by one of the counter 
                        sequentialCounter++;
                        //Check counter
                        if (sequentialCounter >= 2)
                        {
                            //Increase value by one of the total number of sequential letters 
                            //Variable used to calculate sequantial numbers score
                            totalNoOfSqNumbers++;
                        }

                    }
                    else
                    {
                        //Reset sequential variable
                        sequentialCounter = 0;
                    }
                }
                
                //Store current number as old number
                oldNumber = Convert.ToInt32(storeSqNumbers[i].ToString());

            }

            //Calculate sequential numbers symbols (negative score)
            sequentialNumbersScore = totalNoOfSqNumbers * 3;

            //Reset sequential counter
            sequentialCounter = 0;

            //Loop through all the symbols 
            for (int i = 0; i < storeSqSymbols.Length; i++)
            {
                if ((i+1) < storeSqSymbols.Length)
                {
                    if (symbols.IndexOf(storeSqSymbols[i+1])-symbols.IndexOf(storeSqSymbols[i]) == 1)
                    {
                        sequentialCounter++;

                        if (sequentialCounter >= 2)
                        {
                            totalNoOfSqSymbols++;
                        }
                    }
                    else
                    {
                        sequentialCounter = 0;
                    }
                }
   
            }

            //Calculate sequential symbols score (negative score)
            sequentialSymbolsScore = totalNoOfSqSymbols * 3;


            //Calculate repeat characters score
            repeatCharactersScore = (totalNoOfUpperRepeatCharacters * 2) + (totalNoOfLowerRepeatCharacters * 2) + (totalNoOfNumbersRepeatCharacters * 2) + (totalNoOfNumbersRepeatCharacters * 2);

            CalculateFinalScore();
        }

        /// <summary>
        /// Calculate the final score of the password 
        /// </summary>
        private void CalculateFinalScore()
        {
            //Calculate the total score from postitive score - negative score
            score = noOfCharactersScore + upperLettersScore + lowerLettersScore + numbersScore + symbolsScore + middleNumbersOrSymbolsScore + requirementsScore
                    - lettersOnlyScore - numbersOnlyScore - repeatCharactersScore- consecutiveUpperCaseLettersScore - consecutiveLowerCaseLettersScore - consecutiveNumbersScore 
                    - sequentialLettersScore - sequentialNumbersScore - sequentialSymbolsScore;           
        }

        private void ClearData()
        {
            noOfCharactersScore = 0;
            upperLettersScore = 0;
            lowerLettersScore = 0;
            numbersScore = 0;
            symbolsScore = 0;
            middleNumbersOrSymbolsScore = 0;
            requirementsScore = 0;
            lettersOnlyScore = 0;
            numbersOnlyScore = 0;
            repeatCharactersScore = 0;
            consecutiveLowerCaseLettersScore = 0;
            consecutiveLowerCaseLettersScore = 0;
            consecutiveNumbersScore = 0;
            sequentialLettersScore = 0;
            sequentialNumbersScore = 0;
            sequentialSymbolsScore = 0;
            oldUpperChar = ' ';
            TotalNoOfUpperCases = 0;
            oldLowerChar = ' ';
            TotalNoOfLowerCases = 0;
            TotalNoOfDigits = 0;
            totalNoOfLetters = 0;
            TotalNoOfSymbols = 0;
            TotalNoOfRequirements = 0;
            requirementUppercaseLetter = false;
            requirementLowercaseLetter = false;
            requirementNumbers = false;
            requirementSymbols = false;
            TotalNoOfNnS = 0;
            consecutiveUppercase = false;
            totalNoOfConsUppercase = 0;
            consecutiveLowercase = false;
            totalNoOfConseLowercase = 0;
            consecutiveNumbers = false;
            totalNoOfConseNumbers = 0;
            sequentialLetters = false;
            totalNoOfSqLetters = 0;
            storeSqLetters = "";
            sequqentialNumbers = false;
            totalNoOfSqNumbers = 0;
            storeSqNumbers = "";
            sequentialSymbols = false;
            totalNoOfSqSymbols = 0;
            storeSqSymbols = "";
            totalNoOfUpperRepeatCharacters = 0;
            totalNoOfLowerRepeatCharacters = 0;
            totalNoOfNumbersRepeatCharacters = 0;
            totalNoOfSymbolsRepeatCharacters = 0;
            storeRepeatCharacters = "";
        }

        /// <summary>
        /// Returns the score of the password in percentage
        /// </summary>
        /// <returns></returns>
        public double GetScorePercent()
        {
            if (score > 100)
            {
                score = 100;
            }
            else if (score <= 0)
            {
                score = 0;
            }

            return score;
        }

        // <summary>
        /// Score: 0-39 Very Weak | 40-69 Medium | 70-100 Strong 
        /// </summary>
        /// <returns></returns>
        public string GetScoreString()
        {
            string result = "";

            if (score < 40)
            {
                result = "Weak";
            }
            else if (score >= 40 && score < 70)
            {
                result = "Medium";
            }
            else if (score >= 70)
            {
                result = "Strong";
            }
            return result;
        }

    }
}
