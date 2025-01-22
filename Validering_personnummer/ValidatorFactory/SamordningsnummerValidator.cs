namespace Validering_personnummer.ValidatorFactory
{
    internal class SamordningsnummerValidator : LuhnAlgoritm, IValidator
    {
        private readonly string CleanedInput;
        public SamordningsnummerValidator(string cleanedInput)
        {
            CleanedInput = cleanedInput;
        }
        //kontrollerar om numret är ett korrekt samordningsnummer
        public bool Validate()
        {
            if (IsValidChecksum(CleanedInput) && IsValidFormat())
            {
                return true;
            }
            else return false;
        }

        // Kontrollerar korrekt angivet datumformat mellan 61-91
        private bool IsValidFormat()
        {
            // Extrahera dagen
            string dayPart = CleanedInput.Substring(4, 2);
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

