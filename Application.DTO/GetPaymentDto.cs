using System;
using System.Collections.Generic;
using System.Text;
using Application.DTO.Responses;

namespace Application.DTO
{
    public class GetPaymentDto : ApiResponse
    {
        private List<string> errorList;
        private int responseCode;
        private bool hasError;

        public GetPaymentDto(List<string> errorList, int responseCode= 200, bool hasError= false) : base(responseCode, hasError, errorList)
        {
            this.errorList = errorList;
            this.responseCode = responseCode;
            this.hasError = hasError;
        }

        public Guid Id { get; set; }
        public CardInformation CardInformation { get; set; }
        public Status Status { get; set; }
    }
}
