namespace Validering_personnummer
{
    internal class InputChecker
    {
        public string Input;

        public InputChecker(string input)
        {
            Input = input;
        }
        public bool IsInputValid()
        {
            if (CheckIfInputIsNull() && CheckifInputLengthIsOk())
            {
                return true;
            }
            else return false;
        }
        //Kontollerar om inputen är null
        private bool CheckIfInputIsNull()
        {
            if (Input is not null)
            {
                return true;
            }
            return false;
        }
        //Kontrollerar så att längden på inputen är mellan 10-13 tecken
        private bool CheckifInputLengthIsOk ()
        {
            Input.Trim(); //Tar bort ev mellanslag i början och slutet av inputen

            if (Input.Length >= 10 && Input.Length <= 13) {
                return true;
            }
            else { 
                return false; }
        }
    }
}
