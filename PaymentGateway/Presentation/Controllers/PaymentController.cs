namespace Presentation.Controllers
{
    using System;
    using System.Net;
    using System.Threading.Tasks;
    using Application.DTO;
    using Application.Services.Interfaces;
    using Microsoft.AspNetCore.Mvc;


    [Route("[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentService paymentService;

        /// <summary>
        /// Initializes a new instance of <see cref="PaymentController"/>
        /// </summary>
        public PaymentController(IPaymentService paymentService)
        {
            this.paymentService = paymentService;
        }

        /// <summary>
        /// Process Payment
        /// </summary>
        /// <returns></returns>
        /// <response code="200">Ok</response>
        /// <response code="400">Bad request</response>
        [HttpPost()]
        public async Task<IActionResult> ProcessPayment(PaymentRequestDto request)
        {
            var result = await this.paymentService.ProcessPayment(request).ConfigureAwait(false);

            if (result.Success)
            {
                return this.Ok(result);
            }
            else
            {
                return this.BadRequest(result);
            }
        }

        /// <summary>
        /// Get Payment Info
        /// </summary>
        /// <returns></returns>
        /// <response code="200">Ok</response>
        /// <response code="404">Not Found</response>
        [HttpGet()]
        public async Task<IActionResult> ProcessPayment(Guid paymentId)
        {
            var result = await this.paymentService.GetPayment(paymentId).ConfigureAwait(false);
            if (result.HasError)
            {
                switch (result.ResponseCode)
                {
                    case (int)HttpStatusCode.NotFound:
                        return NotFound();
                    default:
                        return this.Ok(result);
                }
            }
            return this.Ok(result);
        }
    }
}

