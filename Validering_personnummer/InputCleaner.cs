using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Validering_personnummer
{
    internal class InputCleaner
    {
        public string _cleanedInput{ get; private set; }
        public string _input;

        public InputCleaner(string input) 
        {
          _input = input;   
        }

        public string Clean() {
            string sanitizedInput = Sanitize(_input);
            _cleanedInput = CorrectLength(sanitizedInput);
            return _cleanedInput; }

        //SER TILL ATT INPUTEN BARA HAR SIFFROR
        public string Sanitize(string inputNumber)
        {
            var sanitized = new List<char>();
            foreach (char c in inputNumber)
            {
                if (char.IsDigit(c))
                {
                    sanitized.Add(c);
                }
            }
            _cleanedInput  = new string(sanitized.ToArray());
            return _cleanedInput;
        }
        //GÖR OM TILL 10 OM INPUT ÄR 12
        public string CorrectLength(string sanitizedInput)
        {
            if (sanitizedInput.Length == 12)
            {
                sanitizedInput = sanitizedInput.Substring(2);
                return sanitizedInput;
            }
            else return sanitizedInput;
        }
    }
}
