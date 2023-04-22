using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTO
{
    public class GetPaymentDto
    {
        public Guid Id { get; set; }
        public CardInformation CardInformation { get; set; }
        public Status Status { get; set; }
    }
}
