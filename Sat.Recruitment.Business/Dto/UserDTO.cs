using Sat.Recruitment.Business;
using Sat.Recruitment.Common.Helpers;
using Sat.Recruitment.Common.Resources;
using Sat.Recruitment.IBusiness.Dto;
using Sat.Recruitment.IBusiness.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Sat.Recruitment.Domain.DTO
{
    public class UserDTO : BaseEntityDTO, IUserDTO, IValidatableObject
    {
        [Required(ErrorMessageResourceName = "NameRequired", ErrorMessageResourceType = typeof(AppResource))]
        [MaxLength(50)]
        public string Name { get; set; }
 
        [Required(ErrorMessageResourceName = "EmailRequired", ErrorMessageResourceType = typeof(AppResource))]
        [MaxLength(50)]
        [EmailAddress]
        public string Email { get; set; }
         
        [Required(ErrorMessageResourceName = "AddressRequired", ErrorMessageResourceType = typeof(AppResource))]
        [MaxLength(50)]
        public string Address { get; set; }

        [Required(ErrorMessageResourceName = "PhoneRequired", ErrorMessageResourceType = typeof(AppResource))]
        [MaxLength(50)]
        public string Phone { get; set; }

        public UserType UserType { get; set; } = UserType.Normal;

        public decimal Money { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var results = new List<ValidationResult>();
 
            return results;
        }
    }
}
