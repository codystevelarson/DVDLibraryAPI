using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DvdModels.Attributes
{
    class DirectorAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value is string)
            {
                string checkString = (string)value;
                if (checkString.Length <= 50 && checkString.Length > 0)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
