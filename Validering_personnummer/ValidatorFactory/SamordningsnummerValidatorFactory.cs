namespace Validering_personnummer.ValidatorFactory
{
    internal class SamordningsnummerValidatorFactory : IValidatorFactory
    {
        //Skapar en samordningsnummers validerare
        public IValidator CreateValidator(string cleanedInput)
        {
            return new SamordningsnummerValidator(cleanedInput);
        }

    }
}
