using Validering_personnummer.ValidatorFactory;
using Validering_personnummer;

internal class ValidationService
{
    private readonly ILogger Logger;
    private readonly List<string> NumberInputList;

    internal ValidationService(ILogger logger, List<string>numberInputList)
    {
        Logger = logger;
        NumberInputList = numberInputList;
    }

    public void Run()
    {
        foreach (var inputNumber in NumberInputList)
        {
            try
            {
                InputChecker inputChecker = new InputChecker(inputNumber);
                if (inputChecker.IsInputValid())
                {
                    //fixar till inputen så att beräkningar och kontroller kan göras på den fixade inputen
                    InputCleaner inputCleaner = new InputCleaner(inputNumber);
                    string cleanedInputNumber = inputCleaner.Clean();
                    //skapar validators
                    IValidator validatorPersonnummer = new PersonnummerValidatorFactory().CreateValidator(cleanedInputNumber);
                    IValidator validatorSamordningsnummer = new SamordningsnummerValidatorFactory().CreateValidator(cleanedInputNumber);
                    IValidator validatorOrganisationsnummer = new OrganinsationsnummerValidatorFactory().CreateValidator(cleanedInputNumber);
                    //Kontrollerar vilken validator som är korrekt
                    if (validatorPersonnummer.Validate())
                    {
                        Console.WriteLine($"Giltigt personnummer: {inputNumber}");
                    }
                    else if (validatorSamordningsnummer.Validate())
                    {
                        Console.WriteLine($"Giltigt samordningsnummer: {inputNumber}");
                    }

                    else if (validatorOrganisationsnummer.Validate())
                    {
                        Console.WriteLine($"Giltigt organisationsnummer: {inputNumber}");
                    }
                    else
                    //loggar numret om det inte passerar någon av validerarnas tester
                    {
                        Logger.Log($"Ogiltigt nummer: {inputNumber}");
                        Console.WriteLine($"Ogiltigt nummer: {inputNumber}");
                    }
                }
                else
                //loggar numret om inputen är fel, t.ex. input är null eller ogiltig längd
                {
                    Logger.Log($"Ogiltigt nummer: {inputNumber}");
                    Console.WriteLine($"Ogiltigt nummer: {inputNumber}");
                }

            }
            catch (Exception exeption)
            {
                Console.WriteLine($"Fel uppstod: {exeption.Message}");

            }
        }
    }
}
