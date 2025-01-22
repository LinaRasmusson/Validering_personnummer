namespace Validering_personnummer.ValidatorFactory
{
    internal class PersonnummerValidatorFactory : IValidatorFactory
    {
        //Skapar en personnummers validerare
        public IValidator CreateValidator(string cleanedInput)
        {
            return new PersonnummerValidator(cleanedInput);
        }
    }
}
