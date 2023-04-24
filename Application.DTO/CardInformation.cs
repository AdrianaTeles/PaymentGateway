namespace Application.DTO
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Text.RegularExpressions;

    public class CardInformation
    {
        [Required]
        [StringLength(16)]
        public string CardNumber { get; set; }

        public DateTime ExpiryDate { get; set; }

        [Required]
        [Range(0, 999)]
        public int CVV { get; set; }

        public string MaskCardNumber()
        {
            var firstDigits = this.CardNumber.Substring(0, 2);
            var lastDigits = this.CardNumber.Substring(this.CardNumber.Length - 4, 4);

            var requiredMask = new String('X', this.CardNumber.Length - firstDigits.Length - lastDigits.Length);

            var maskedString = string.Concat(firstDigits, requiredMask, lastDigits);
            var maskedCardNumberWithSpaces = Regex.Replace(maskedString, ".{4}", "$0 ");

            return maskedCardNumberWithSpaces;
        }
    }
}
