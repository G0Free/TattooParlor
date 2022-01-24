using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TattooParlor.Models.Exceptions
{
    public class InvalidEmailException : Exception
    {        
        public InvalidEmailException() : base("Invalid Email format")
        {

        }
    }
}
