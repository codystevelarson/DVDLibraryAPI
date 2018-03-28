using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DvdModels.Attributes
{
    class TitleAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value is string)
            {
                string checkString = (string)value;
                if (string.IsNullOrEmpty(checkString))
                {
                    return false;
                }
                else if(checkString.Length <= 100 && checkString.Length > 0)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
