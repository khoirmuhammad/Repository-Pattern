﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.CommonModels
{
    public class Response<T> : BaseResponse
    {
        public T Data { get; set; }
    }
}
