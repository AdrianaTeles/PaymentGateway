using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DTO;

namespace Application.Services.Interfaces
{
    public interface IPaymentService
    {
        Task<GetPaymentDto> GetPayment(Guid paymentId);
        Task<PaymentResponseDto> ProcessPayment(PaymentRequestDto request);
    }
}
