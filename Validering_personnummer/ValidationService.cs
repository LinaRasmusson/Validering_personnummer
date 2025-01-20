using Validering_personnummer.ValidatorFactory;
using Validering_personnummer;
using System.ComponentModel.Design;

internal class ValidationService
{
    private ILogger _logger;
    private List<string> _numberInputList;

    internal ValidationService(ILogger logger, List<string>numberInputList)
    {
        _logger = logger;
        _numberInputList = numberInputList;
    }

    public void Run()
    {
        foreach (var inputNumber in _numberInputList) {
            try
            {
                InputChecker inputChecker = new InputChecker(inputNumber);
                if (inputChecker.IsInputValid())
                {
                    //fixar till inputen så att beräkningar och kontroller kan göras på den
                    InputCleaner inputCleaner = new InputCleaner(inputNumber);
                    string cleanedInputNumber = inputCleaner.Clean();
                    //skapar validators
                    IValidator validatorPersonnummer = new PersonnummerValidatorFactory().CreateValidator(cleanedInputNumber);
                    IValidator validatorSamordningsnummer = new SamordningsnummerValidatorFactory().CreateValidator(cleanedInputNumber);
                    IValidator validatorOrganisationsnummer = new OrganinsationsnummerValidatorFactory().CreateValidator(cleanedInputNumber);
                    //kör varje validators validate metod
                    validatorPersonnummer.Validate();
                    validatorSamordningsnummer.Validate();
                    validatorOrganisationsnummer.Validate();
                    //Kontrollerar vilken validator som är korrekt
                    if (validatorPersonnummer.IsValid)
                    {
                        Console.WriteLine($"Giltigt personnummer: {inputNumber}");
                    }
                    else if (validatorSamordningsnummer.IsValid)
                    {
                        Console.WriteLine($"Giltigt samordningsnummer: {inputNumber}");
                    }

                    else if (validatorOrganisationsnummer.IsValid)
                    {
                        Console.WriteLine($"Giltigt organisationsnummer: {inputNumber}");
                    }
                    else
                    {
                        _logger.Log($"Ogiltigt nummer: {inputNumber}");
                        Console.WriteLine($"Ogiltigt nummer: {inputNumber}");
                    }
                }
                else
                {
                    _logger.Log($"Ogiltigt nummer: {inputNumber}");
                    Console.WriteLine($"Ogiltigt nummer: {inputNumber}");
                }
                
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Fel uppstod: {ex.Message}");

            }
        }
    }
}
