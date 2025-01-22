namespace Validering_personnummer.ValidatorFactory
{
    internal class OrganinsationsnummerValidatorFactory : IValidatorFactory
    { 
        //Skapar en organisationsnummer validerare
        public IValidator CreateValidator(string cleanedInput)
        {
            return new OrganisationsnummerValidator(cleanedInput);
        }

    }
        
}
