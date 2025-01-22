namespace Validering_personnummer
{
    internal class InputCleaner
    {
        public string CleanedInput{ get; private set; }
        public string Input;

        public InputCleaner(string input) 
        {
          Input = input;   
        }

        public string Clean() {
            string digitsOnlyInput = KeepDigitsOnly(Input);
            CleanedInput = CorrectLength(digitsOnlyInput);
            return CleanedInput; }

        //Ser till att inputen bara har siffror
        private string KeepDigitsOnly(string inputNumber)
        {
            var sanitized = new List<char>();
            foreach (char c in inputNumber)
            {
                if (char.IsDigit(c))
                {
                    sanitized.Add(c);
                }
            }
            CleanedInput = new string(sanitized.ToArray());
            return CleanedInput;
        }
        //gör om inputen till 10 siffror om den har 12
        private string CorrectLength(string digitsOnlyInput)
        {
            if (digitsOnlyInput.Length == 12)
            {
                digitsOnlyInput = digitsOnlyInput.Substring(2);
                return digitsOnlyInput;
            }
            else return digitsOnlyInput;
        }
    }
}
