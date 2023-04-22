using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTO
{
    public class PaymentRequestDto
    {
        public int MerchantId { get; set; }

        public CardInformation cardInformation { get; set; }
        
        public decimal Amount { get; set; }

        public string Currency { get; set; }
    }
}
