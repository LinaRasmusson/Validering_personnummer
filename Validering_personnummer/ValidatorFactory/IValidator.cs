using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Validering_personnummer.ValidatorFactory
{
    internal interface IValidator
    {
        bool IsValid { get;}
        void Validate();
    }
}
