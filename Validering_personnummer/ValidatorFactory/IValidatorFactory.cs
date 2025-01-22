namespace Validering_personnummer.ValidatorFactory
{
    internal interface IValidatorFactory
    {
        IValidator CreateValidator(string cleanedInput);
    }
}
