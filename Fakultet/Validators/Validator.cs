using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Fakultet.Validators
{
    public class Validator
    {
        public static bool ValidateAlphaNumeric(string param)
        {
            Regex regex = new Regex("^[a-zA-Z0-9 ]*$");
            if (regex.IsMatch(param))
            {
                return true;
            }
            return false;
        }
    }
}
