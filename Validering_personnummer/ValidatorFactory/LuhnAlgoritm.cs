namespace Validering_personnummer.ValidatorFactory
{
    internal abstract class LuhnAlgoritm
    {
        //Validerar personnummer, samordningsnummer och organisationsnummer med Luhnalgoritmen
        protected bool IsValidChecksum(string cleanedInput)
        {
            if (cleanedInput.Length == 12)
            {
                cleanedInput = cleanedInput.Substring(2);
            }

            int sum = 0;
            for (int i = 0; i < cleanedInput.Length - 1; i++)
            {
                int digit = cleanedInput[i] - '0';
                if (i % 2 == 0)
                {
                    digit *= 2;
                    if (digit > 9) digit -= 9;
                }
                sum += digit;
            }

            int controlDigit = (10 - (sum % 10)) % 10;
            return controlDigit == (cleanedInput[^1] - '0');
        }
    }
}
