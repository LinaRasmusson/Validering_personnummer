using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Validering_personnummer.ValidatorFactory
{
    internal class SamordningsnummerValidator : LuhnAlgoritm, IValidator
    {
        private string _cleanedInput { get; set; }
        public bool IsValid { get; private set; }

        public SamordningsnummerValidator(string cleanedInput)
        {
            _cleanedInput = cleanedInput;
        }
        public void Validate()
        {
            if (IsValidChecksum(_cleanedInput) && isValidFormat())
            {
                IsValid = true;
            }
            else IsValid = false;
        }

        // Kontrollerar korrekt angivet datumformat mellan 61-91
        private bool isValidFormat()
        {
            // Extrahera dagen
            string dayPart = _cleanedInput.Substring(4, 2);
            // Konvertera till heltal för jämförelse
            int day = int.Parse(dayPart);

            // Kontrollera om dagen är mellan 61 och 91
            if (day >= 61 && day <= 91)
            {
                return true;
            }
            else return false;
        }
    }
}

