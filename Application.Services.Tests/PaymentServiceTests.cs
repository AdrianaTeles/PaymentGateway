using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Application.DTO;
using Application.Services;
using Data.Repository.Interfaces;
using Data.Services;
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
            //Arrange
            var payment = new Domain.Model.Payment()
            {
                PaymentId = Guid.NewGuid()

            };
            var paymentGetResult = new List<Domain.Model.Payment> {  };
           
            this.paymentRepository.Setup(x => x.GetAllAsync(It.IsAny<Expression<Func<Domain.Model.Payment, bool>>>())).ReturnsAsync(paymentGetResult);
           
            var expectedResult = new GetPaymentDto(new List<string>() { "NotFound" }, 404, true);
            //Act
            var result = await payService.GetPayment(payment.PaymentId).ConfigureAwait(false);

            //Assert
            Assert.NotNull(result);
            Assert.True(result.HasError);
        }

        [Fact]
        public async Task GetPayment_PaymentIdExists_ReturnsPaymentObject()
        {
            //Arrange
            var payment = new Domain.Model.Payment()
            {
                PaymentId = Guid.NewGuid(),
                CardId = Guid.NewGuid()

            };
            var cardInfo = new Domain.Model.CardInformation()
            {
                CardId = payment.CardId,
                CardNumber = "5105105105105100",
                ExpiryDate = DateTime.Now
            };
            var paymentGetResult = new List<Domain.Model.Payment> { payment };
            var cardGetResult = new List<Domain.Model.CardInformation> { cardInfo };
            this.paymentRepository.Setup(x => x.GetAllAsync(It.IsAny<Expression<Func<Domain.Model.Payment, bool>>>())).ReturnsAsync(paymentGetResult);
            this.cardRepository.Setup(x => x.GetAllAsync(It.IsAny<Expression<Func<Domain.Model.CardInformation, bool>>>())).ReturnsAsync(cardGetResult);

            var expectedResult = new GetPaymentDto(new List<string>(), 200, false)
            {
                Id = payment.PaymentId,
                CardInformation = new CardInformation
                {
                    CardNumber = cardInfo.CardNumber,
                    ExpiryDate = cardInfo.ExpiryDate
                },
                Status = Status.Success
            };
            //Act
            var result = await payService.GetPayment(payment.PaymentId).ConfigureAwait(false);

            //Assert
            Assert.NotNull(result);
            Assert.Equal(expectedResult.Id, result.Id);
            Assert.Equal(expectedResult.CardInformation.CardNumber, result.CardInformation.CardNumber);
            Assert.Equal(expectedResult.CardInformation.ExpiryDate, result.CardInformation.ExpiryDate);
        }

        [Fact]
        public async Task ProcessPayment_GatewaySucess_ReturnsSucess()
        {
            //Arrange
            var payment =new PaymentRequestDto
            {
                MerchantId = 10,
                Amount = 10,
                CardInformation = new CardInformation
                {
                    CardNumber = "5105105105105100",
                    CVV = 123,
                    ExpiryDate = DateTime.UtcNow
                },
                Currency= "EUR"
            };

            this.CKOBankGateway.Setup(x => x.SubmitPayment(It.IsAny<PaymentRequestDto>())).Returns(new CKOResponse());
            this.paymentRepository.Setup(x => x.AddAsync(It.IsAny<Domain.Model.Payment>())).Returns(Task.CompletedTask);
            this.paymentRepository.Setup(x => x.SaveChangesAsync()).ReturnsAsync(1);

            //Act
            var result = await payService.ProcessPayment(payment).ConfigureAwait(false);

            //Assert
            Assert.NotNull(result);
            Assert.True(result.Success);
        }
    }
}
