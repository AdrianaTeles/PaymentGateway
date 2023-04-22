using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTO
{
    public class PaymentResponseDto
    {
        public Guid? PaymentId { get; set; }
        public bool Success { get; set; }

    }
}
