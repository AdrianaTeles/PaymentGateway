namespace Application.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Application.DTO;
    using Application.Services.Interfaces;
    using Data.Repository.Interfaces;
    using Data.Services.Interfaces;
    using Domain.Model;

    public class PaymentService : IPaymentService
    {
        private ICKOBankGateway CKOBankGateway;
        private IPaymentRepository paymentRepository;
        private ICardRepository cardRepository;

        public PaymentService(ICKOBankGateway CKOBankGateway, IPaymentRepository paymentRepository, ICardRepository cardRepository)
        {
            this.CKOBankGateway = CKOBankGateway;
            this.paymentRepository = paymentRepository;
            this.cardRepository = cardRepository;
        }

        public async Task<GetPaymentDto> GetPayment(Guid paymentId)
        {
            var payments = await this.paymentRepository.GetAllAsync(x=>x.PaymentId == paymentId).ConfigureAwait(false);
            if (payments == null || !payments.Any())
                return new GetPaymentDto(new List<string>() { "NotFound" }, 404, true);

            var cardPayment = await this.cardRepository.GetAllAsync(x=>x.CardId == payments.FirstOrDefault().CardId).ConfigureAwait(false);

            return new GetPaymentDto(new List<string>(), 200, false)
            {
                Id = payments.FirstOrDefault().PaymentId,
                CardInformation = new DTO.CardInformation
                {
                    CardNumber = cardPayment.FirstOrDefault().CardNumber,
                    CVV = cardPayment.FirstOrDefault().CVV,
                    ExpiryDate = cardPayment.FirstOrDefault().ExpiryDate
                },
                Status = Status.Success
            };
        }

        public async Task<PaymentResponseDto> ProcessPayment(PaymentRequestDto request)
        {
            var payment = new Payment()
            {
                PaymentId = Guid.NewGuid(),
                Amount = request.Amount,
                Currency = request.Currency,
                MerchantId = request.MerchantId,
                CardInformation = new Domain.Model.CardInformation()
                {
                    CardId = Guid.NewGuid(),
                    CardNumber = request.CardInformation.CardNumber,
                    CVV = request.CardInformation.CVV,
                    ExpiryDate = request.CardInformation.ExpiryDate
                }
            };

            payment.CardId = payment.CardInformation.CardId;
            var CKOResponse = this.CKOBankGateway.SubmitPayment(request);

            if (CKOResponse.Success)
            {
                try
                {
                    await this.paymentRepository.AddAsync(payment);
                    
                    await this.paymentRepository.SaveChangesAsync();

                    return new PaymentResponseDto
                    {
                        Success = true,
                        PaymentId = payment.PaymentId
                    };
                }
                catch (Exception ex)
                {
                    throw ex;
                }

            }
            else
            {
                return new PaymentResponseDto
                {
                    Success = false,
                    PaymentId = payment.PaymentId
                };
            }            
        }
    }
}
