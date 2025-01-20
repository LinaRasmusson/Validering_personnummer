using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Validering_personnummer.ValidatorFactory;

namespace Validering_personnummer
{
    internal class InputChecker
    {
        public string _input;

        public InputChecker(string input)
        {
            _input = input;
        }
        public bool IsInputValid()
        {
            if (CheckIfInputIsNull() && CheckifInputLengthIsOk())
            {
                return true;
            }
            else return false;
        }
        private bool CheckIfInputIsNull()
        {
            if (_input is not null)
            {
                return true;
            }
            return false;
        }
        private bool CheckifInputLengthIsOk ()
        {
            if (_input.Length >= 10 && _input.Length <= 13) {
                return true;
            }
            else { 
                return false; }
        }
    }
}
