using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DTO;
using Application.Services.Interfaces;

namespace Application.Services
{
    public class PaymentService : IPaymentService
    {
        public PaymentService()
        {
            
        }

        public Task<GetPaymentDto> GetPayment(Guid paymentId)
        {
            throw new NotImplementedException();
        }

        public Task<PaymentResponseDto> ProcessPayment(PaymentRequestDto request)
        {
            throw new NotImplementedException();
        }
    }
}
