namespace LoveCalculatorApp.Services
{
    public class LoveCalculatorService : ILoveCalculatorService
    {
        public string CalculateLove(string username, string crushname)
        {
            char resultChar;

            int totalLength = (username + crushname).Length;
            int flamesLength = "FLAMES".Length;

            int remainder = totalLength % flamesLength;

            if (remainder == 0)
            {
                resultChar = 'F';
            }
            else
            {
                resultChar = "FLAMES"[remainder];
            }

            return WhatsBetweenUs(resultChar);
        }

        public string WhatsBetweenUs(char calculateResult)
        {
            string result = string.Empty;

            if (calculateResult == 'F')
            {
                result = LoveCalculatorConstants.F_CHAR_MEANING;
            }
            else if (calculateResult == 'L')
            {
                result = LoveCalculatorConstants.L_CHAR_MEANING;
            }
            else if (calculateResult == 'A')
            {
                result = LoveCalculatorConstants.A_CHAR_MEANING;
            }
            else if (calculateResult == 'M')
            {
                result = LoveCalculatorConstants.M_CHAR_MEANING;
            }
            else if (calculateResult == 'E')
            {
                result = LoveCalculatorConstants.E_CHAR_MEANING;
            }
            else if (calculateResult == 'S')
            {
                result = LoveCalculatorConstants.S_CHAR_MEANING;
            }

            return result;
        }
    }
}