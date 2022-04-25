using Sat.Recruitment.IBusiness.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sat.Recruitment.IBusiness.Business
{
    public interface IMoneyBusiness
    {
        decimal CalculateAmount(IUserDTO userDTO);
    }
}
