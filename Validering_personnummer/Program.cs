﻿namespace Validering_personnummer
    //Lina Rasmusson
{
    class Program
    {
        static void Main(string[] args)
        {
            //Test data med nummer som ska valideras
            List<string> numberInputList =
            [
                "201701102384",
                "141206-2380",
                "20080903-2386",
                "7101169295",
                "198107249289",
                "19021214-9819",
                "190910199827",
                "191006089807",
                "192109099180",
                "4607137454",
                "194510168885",
                "900118+9811",
                "189102279800",
                "189912299816",
                "201701272394",
                "190302299813",
                "190910799824",
                "556614-3185",
                "16556601-6399",
                "262000-1111",
                "857202-7566"
            ];

            ILogger logger = new FileLogger();
            var validationService = new ValidationService(logger, numberInputList);
            validationService.Run();
        }
    }
}