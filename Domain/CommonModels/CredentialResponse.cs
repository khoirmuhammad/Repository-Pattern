using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.CommonModels
{
    public class CredentialResponse
    {
        public string Token { get; set; }
        public string RefreshToken { get; set; }
        public string UniqueIdentity { get; set; }
        public string Message { get; set; }
    }
}
