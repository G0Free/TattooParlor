using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TattooParlor.Models.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class EmailValidatorAttribute : Attribute
    {
        public char Character { get; set; }
        public int Length { get; set; }

        public EmailValidatorAttribute(char character, int length)
        {
            this.Character = character;
            this.Length = length;
        }
    }
}
