using Sat.Recruitment.IBusiness.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sat.Recruitment.Domain.DTO
{
    public class BaseEntityDTO: IBaseEntityDTO
    {
        public long Id { get; set; }
    }
}
