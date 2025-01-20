using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Validering_personnummer
{
    public class FileLogger : ILogger
    {
        private readonly string _filePath;

        public FileLogger()
        {
            _filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "validation_log.txt");
            EnsureLogFileExists();
        }
        //Kollar om det finns en fil, om inte skapas en ny fil
        private void EnsureLogFileExists()
        {
            if (!File.Exists(_filePath))
            {
                File.Create(_filePath).Close();
            }
        }

        //Loggar ogiltiga nummer
        public void Log(string incorrectNumber)
        {
            try
            {
                File.AppendAllText(_filePath, $"{DateTime.Now}: {incorrectNumber}\n");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Fel vid loggning: {ex.Message}");
            }
        }

    }
}
