using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Application.DTO;

namespace Data.Services.Interfaces
{
    public interface ICKOBankGateway
    {
        CKOResponse SubmitPayment(PaymentRequestDto paymentRequest);
    }
}
