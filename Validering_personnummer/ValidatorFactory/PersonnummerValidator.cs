using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Validering_personnummer.ValidatorFactory
{
    internal class PersonnummerValidator : LuhnAlgoritm, IValidator
    {
        private string _cleanedInput;
        
        public bool IsValid { get; private set; }

        public PersonnummerValidator(string cleanedInput)
        {
            _cleanedInput = cleanedInput;
            IsValid = false;
        }

        //Sätter IsValid till antingen true/false beroende på de två checkarna som görs, IsValidCheckSum finns i LuhnAlgoritm-klassen
        public void Validate()
        {
            if (IsValidChecksum(_cleanedInput) && isValidFormat())
            {
                IsValid = true;
            }
            else IsValid = false;
        }

        //Kontrollerar att formatet åå-mm-dd stämmer och kontrollerar skottår
        private bool isValidFormat()
        {
            string datePart = _cleanedInput.Substring(0, 6);
            if (datePart.Length != 6) return false;

            return DateTime.TryParseExact(
                datePart,
                "yyMMdd",
                null,
                System.Globalization.DateTimeStyles.None,
                out _);
        }
    }
}

