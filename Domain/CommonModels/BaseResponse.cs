using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.CommonModels
{
    public class BaseResponse
    {
        public bool IsSucceed { get; set; } = false;
        public string Message { get; set; } = string.Empty;
    }
}
