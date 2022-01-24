using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TattooParlor.Models.Attributes;

namespace TattooParlor.Repository
{
    public static class Validator
    {
        public static bool CheckEmail(object obj)
        {
            if (obj.GetType().GetProperty("Email") != null)
            {
                PropertyInfo prop = obj.GetType().GetProperty("Email");

                EmailValidatorAttribute eva = (EmailValidatorAttribute)prop.GetCustomAttribute(typeof(EmailValidatorAttribute));

                string email = obj.GetType().GetProperty("Email").GetValue(obj).ToString();

                if (email.Contains(eva.Character))
                {
                    if (email.Length > eva.Length)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
