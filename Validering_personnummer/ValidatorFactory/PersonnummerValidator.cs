namespace Validering_personnummer.ValidatorFactory
{
    internal class PersonnummerValidator : LuhnAlgoritm, IValidator
    {
        private readonly string CleanedInput;
        public PersonnummerValidator(string cleanedInput)
        {
            CleanedInput = cleanedInput;
        }
        //Kontrollerar om numret är ett giltigt personnummer
        public bool Validate()
        {
            if (IsValidChecksum(CleanedInput) && IsValidFormat())
            {
                return true;
            }
            else return false;
        }

        //Kontrollerar att formatet åå-mm-dd stämmer och kontrollerar skottår etc.
        private bool IsValidFormat()
        {
            //tar bara ut date-delen av numret, ååmmdd (från index 0-6)
            string datePart = CleanedInput.Substring(0, 6);
            if (datePart.Length != 6) return false;

            //Här försöker metoden tolka strängen datePart som ett datum i formatet ååmmdd
            return DateTime.TryParseExact(
                datePart,
                "yyMMdd",
                null,
                System.Globalization.DateTimeStyles.None,
                out _);
        }
    }
}

