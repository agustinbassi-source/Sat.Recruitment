using Sat.Recruitment.IBusiness.Enum;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Sat.Recruitment.IBusiness.Dto
{
    public interface IUserDTO: IBaseEntityDTO, IValidatableObject
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public UserType UserType { get; set; }
        public decimal Money { get; set; }
    }
}
