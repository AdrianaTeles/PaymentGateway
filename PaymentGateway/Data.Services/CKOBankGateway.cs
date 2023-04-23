using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Application.DTO;
using Data.Services.Interfaces;

namespace Data.Services
{
    public class CKOBankGateway : ICKOBankGateway
    {
        public CKOResponse SubmitPayment(PaymentRequestDto paymentRequest)
        {
            return new CKOResponse();
        }
    }
}
