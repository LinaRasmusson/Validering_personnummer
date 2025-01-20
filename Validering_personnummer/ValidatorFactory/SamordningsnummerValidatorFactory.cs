using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Validering_personnummer.ValidatorFactory
{ 
    internal class SamordningsnummerValidatorFactory : IValidatorFactory
    {
        public IValidator CreateValidator(string cleanedInput)
        {
            return new SamordningsnummerValidator(cleanedInput);
        }

    }
}
