namespace Validering_personnummer.ValidatorFactory
{
    // Validator for organizational numbers
    internal class OrganisationsnummerValidator : LuhnAlgoritm, IValidator
    {
        private readonly string CleanedInput;

        public OrganisationsnummerValidator(string cleanedInput)
        {
            CleanedInput = cleanedInput;
        }
        //Kontrollerar om numret är ett giltigt organisationsnummer
        public bool Validate()
        {
            if (IsValidChecksum(CleanedInput) && IsValidFormat())
            {
                return true;
            }
            else return false;
        }

        // Kontrollerar att sifferparet efter den första siffran är minst 20
        private bool IsValidFormat()
        {
            // Extraherar siffrorna på plats 2 & 3
            string dayPart = CleanedInput.Substring(2, 2);
            // Konvertera till heltal för jämförelse
            int day = int.Parse(dayPart);

            // Kontrollera om siffran är minst 20
            if (day >=20)
            {
                return true;
            }
            else return false;
        }
    }
}
