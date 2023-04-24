using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Application.Services;
using Data.Repository.Interfaces;
using Data.Services.Interfaces;
using Moq;
using Xunit;

namespace Farfetch.RefundService.Application.Services.Tests
{
    public class PaymentServiceTests
    {
        private Mock<ICKOBankGateway> CKOBankGateway;
        private Mock<IPaymentRepository> paymentRepository;
        private Mock<ICardRepository> cardRepository;
        private PaymentService payService;

        public PaymentServiceTests()
        {
            this.CKOBankGateway = new Mock<ICKOBankGateway>();
            this.paymentRepository = new Mock<IPaymentRepository>();
            this.cardRepository = new Mock<ICardRepository>();

            this.payService = new PaymentService(CKOBankGateway.Object,paymentRepository.Object,cardRepository.Object);
        }

        [Fact]
        public async Task GetPayment_PaymentIdDoesNotExists_ReturnsNotFound()
        {

        }

        [Fact]
        public async Task GetPayment_PaymentIdExists_ReturnPaymentObject()
        {

        }

        [Fact]
        public async Task ProcessPayment_PaymentIdExists_ReturnPaymentObject()
        {

        }
    }
}
