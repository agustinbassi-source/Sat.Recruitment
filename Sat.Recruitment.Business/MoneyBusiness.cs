using Sat.Recruitment.IBusiness.Business;
using Sat.Recruitment.IBusiness.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sat.Recruitment.Business
{
    public class MoneyBusiness: IMoneyBusiness
    {
        public decimal CalculateAmount(IUserDTO userDTO)
        {
            switch (userDTO.UserType)
            {
                case IBusiness.Enum.UserType.Normal:

                    if (userDTO.Money > 100)
                        return CalculateGift(userDTO.Money, 0.20m);
                    else if (userDTO.Money < 100 && userDTO.Money > 10)
                        return CalculateGift(userDTO.Money, 0.8m);

                    break;
                case IBusiness.Enum.UserType.SuperUser:

                    if (userDTO.Money > 100)
                        return CalculateGift(userDTO.Money, 0.20m);

                    break;
                case IBusiness.Enum.UserType.Premium:

                    if (userDTO.Money > 100)
                        return CalculateGift(userDTO.Money, 2m);

                    break;
                default:
                    return userDTO.Money;
            }

            return userDTO.Money;
        }

        private decimal CalculateGift(decimal money, decimal percentage)
        {
            var gif =  (money  * percentage) + money;
            return gif;
        }
    }
}
