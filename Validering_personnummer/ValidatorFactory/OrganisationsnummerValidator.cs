using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Validering_personnummer.ValidatorFactory
{
    // Validator for organizational numbers
    internal class OrganisationsnummerValidator : LuhnAlgoritm, IValidator
    {
        private string _cleanedInput;
        public bool IsValid { get; private set; }

        public OrganisationsnummerValidator(string cleanedInput)
        {
            _cleanedInput = cleanedInput;
            IsValid = false;
        }
        public void Validate()
        {
            if (IsValidChecksum(_cleanedInput) && isValidFormat())
            {
                IsValid = true;
            }
            else IsValid = false;
        }

        // Kontrollerar att sifferparet efter den första siffran är minst 20
        private bool isValidFormat()
        {
            // Extraherar siffrorna på plats 2 & 3
            string dayPart = _cleanedInput.Substring(2, 2);
            // Konvertera till heltal för jämförelse
            int day = int.Parse(dayPart);

            // Kontrollera om siffran är mellan 61 och 91
            if (day >=20)
            {
                return true;
            }
            else return false;
        }
    }
}
