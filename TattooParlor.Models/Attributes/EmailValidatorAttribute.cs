using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TattooParlor.Models.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class EmailValidatorAttribute : ValidationAttribute
    {        
        private string allowedEmailFormat { get; set; }
        public EmailValidatorAttribute(string allowedDomain)
        {
            this.allowedEmailFormat = allowedDomain;
        }
        public override bool IsValid(object value)
        {
            if (value.ToString().Contains("@"))
            {
                string[] array = value.ToString().Split("@");
                if (array[1].Contains("."))
                {
                    return true;
                }
                return false;
            }
            return false;
        }
    }
}
