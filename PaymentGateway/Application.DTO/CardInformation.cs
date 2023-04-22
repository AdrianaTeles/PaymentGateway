using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Application.DTO
{
    public  class CardInformation
    {
        public string CardNumber { get; set; }
        public DateTime ExpiryDate { get; set; }
        public int CVV { get; set; }

        public string MaskCardNumber()
        {           
            var firstDigits = this.CardNumber.Substring(0, 6);
            var lastDigits = this.CardNumber.Substring(this.CardNumber.Length - 4, 4);

            var requiredMask = new String('X', this.CardNumber.Length - firstDigits.Length - lastDigits.Length);

            var maskedString = string.Concat(firstDigits, requiredMask, lastDigits);
            var maskedCardNumberWithSpaces = Regex.Replace(maskedString, ".{4}", "$0 ");

            return maskedCardNumberWithSpaces;
        }
    }
}
