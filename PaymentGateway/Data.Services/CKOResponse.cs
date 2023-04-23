using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Services
{
    public class CKOResponse
    {
        public CKOResponse()
        {
            Errors = new List<string>();
        }

        public bool Success { get { return Errors.Count == 0; } }

        public List<string> Errors;

        public Guid RequestId { get; set; }
    }
}
