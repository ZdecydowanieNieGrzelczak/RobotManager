using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace RobotManager.Validators
{

    public class NameValidationRule : ValidationRule
    {
        public Regex regexItem = new Regex("^[a-zA-Z0-9]*$");

        public NameValidationRule()
        {

        }

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (value == null)
            {

                return new ValidationResult(false, $"Cannot be left empty");
            }
            if (regexItem.IsMatch((string)value))
            {
                return ValidationResult.ValidResult;
            }

            return new ValidationResult(false, $"Please enter only letters and numbers!");



        }
    }
}
