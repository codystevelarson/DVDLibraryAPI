using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DvdModels.Attributes
{
    class ReleaseYearAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value is int)
            {
                int checkYear = (int)value;
                if (checkYear <= 9999 && checkYear > 1800)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
