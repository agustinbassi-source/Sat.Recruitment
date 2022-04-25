﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Sat.Recruitment.IBusiness.Dto
{
    public interface IResponseDTO<T> where T : class
    {
        public T Data { get; set; }
        public List<string> Messages { get; set; }
    }
}
