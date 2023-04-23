using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain.Model
{
    public class Payment
    {
        [Key]
        public Guid PaymentId { get; set; }
        public int MerchantId { get; set; }

        public Guid CardId { get; set; }

        public CardInformation CardInformation { get; set; }

        public decimal Amount { get; set; }

        public string Currency { get; set; }

    }
}
