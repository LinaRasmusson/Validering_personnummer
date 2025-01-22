namespace Validering_personnummer
{
    public class FileLogger : ILogger
    {
        private readonly string FilePath;

        public FileLogger()
        {
            FilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "validation_log.txt");
            EnsureLogFileExists();
        }
        //Kollar om det finns en fil, om inte skapas en ny fil
        private void EnsureLogFileExists()
        {
            if (!File.Exists(FilePath))
            {
                File.Create(FilePath).Close();
            }
        }

        //Loggar ogiltiga nummer
        public void Log(string incorrectNumber)
        {
            try
            {
                File.AppendAllText(FilePath, $"{DateTime.Now}: {incorrectNumber}\n");
            }
            catch (Exception exeption)
            {
                Console.WriteLine($"Fel vid loggning: {exeption.Message}");
            }
        }

    }
}
