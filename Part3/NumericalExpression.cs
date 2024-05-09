using System;
using System.Collections.Generic;
using System.Text;

namespace Part3
{
    class NumericalExpression
    {
        public enum Languages
        {
            English,
            Hebrew
        }

        public long Value { get; private set; }
        private Func<long, string> currentFunction = EnglishNumbers;

        private static readonly string[] english_prefix = { "Minus", "" };
        private static readonly string[] english_digits = { "", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine" };
        private static readonly string[] english_teens = { "Ten", "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen", "Seventeen", "Eighteen", "Nineteen" };
        private static readonly string[] english_tens = { "", "", "Twenty", "Thirty", "Forty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninety" };
        private static readonly string[] english_thousands = { "", "Thousand", "Million", "Billion", "Trillion", "Quadrillion", "Quintillion" };

        public NumericalExpression(long value)
        {
            this.Value = value;
        }

        public NumericalExpression(long value, Languages language)
        {
            this.Value = value;
            SwitchLanguage(language);
        }

        public long GetValue()
        {
            return this.Value;
        }

        private static string HandleSmall(long number)
        {
            string str = string.Empty;

            if (number >= 100)
            {
                str += english_digits[number / 100] + " Hundred ";
                number %= 100;
            }

            if (number >= 10 && number < 20)
                str += english_teens[number % 10] + " ";
            else
            {
                str += english_tens[(number / 10)] + " ";
                str += english_digits[number % 10] + " ";
            }

            return str;
        }

        private static string EnglishNumbers(long number)
        {
            string numberString = string.Empty;
            bool isNegative = false;

            if (number == 0)
                return "Zero";


            if (number < 0)
            {
                number = Math.Abs(number);
                isNegative = true;
            }
            if (number < 10)
                return english_digits[number];


            for (int i = 0; number > 0; i++)
            {
                
                if (number % 1000 != 0 && i < english_thousands.Length)
                    numberString = HandleSmall(number % 1000) + english_thousands[i] + " " + numberString;

                number /= 1000;
            }
            if (isNegative)
                numberString = "Minus " + numberString;

            return numberString;
        }

        private static string HebrewNumbers(long number)
        {
            // console doesn't support hebrew so i didn't implement it
            return "Example_Language_HebrewLogic";
        }

        public void SwitchLanguage(Languages language)
        {
            switch (language)
            {
                case Languages.English:
                    this.currentFunction = EnglishNumbers;
                    break;
                case Languages.Hebrew:
                    this.currentFunction = HebrewNumbers;
                    break;
            }
        }

        public static long SumLetters(long number)
        {
            long count = 0;

            for (long i = 0; i <= Math.Abs(number); i++)
            {
                string str = EnglishNumbers(i);
                str = str.Replace(" ", "");

                count += str.Length;
            }

            return count;
        }

        //method overloading - polymorphism
        public static long SumLetters(NumericalExpression expression)
        {
            return SumLetters(expression.GetValue());
        }

        public override string ToString()
        {
            return currentFunction(this.Value);
        }

    }
}





