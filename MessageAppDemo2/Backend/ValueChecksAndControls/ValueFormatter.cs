using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageAppDemo2.Backend.ValueChecksAndControls
{
    public static class ValueFormatter
    {
        public static string FormatPhoneNumber(string phoneNumber)
        {
           string phoneNumberV = phoneNumber.Trim()
                    .Replace(" ", "")
                    .Replace("-", "")
                    .Replace("+", "")
                    .Replace("(", "")
                    .Replace(")", "");
            StringBuilder phoneNumberString = new StringBuilder();

            if (phoneNumberV.Length > 10)
            {
                for (int i = phoneNumberV.Length - 1; i >= 0; i--)
                {
                    phoneNumberString.Insert(0, phoneNumberV[i]);
                    if (phoneNumberString.Length == 10)
                    {
                        return phoneNumberString.ToString();
                    }
                }
            }
            else if (phoneNumberV.Length < 10)
            {
                throw new ArgumentException("Invalid value.");
            }
            return phoneNumberV;
        }
        
    }
}
