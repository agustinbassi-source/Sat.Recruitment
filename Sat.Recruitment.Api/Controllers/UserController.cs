using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Sat.Recruitment.Business;
using Sat.Recruitment.Common.Helpers;
using Sat.Recruitment.Common.Resources;
using Sat.Recruitment.Domain.DTO;
using Sat.Recruitment.IBusiness.Dto;
using Sat.Recruitment.IBusiness.Interface;
using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Sat.Recruitment.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
   
    public class UserController : CustomeBaseController
    {
        private readonly IUserBusiness _userBusiness;
        public UserController(IUserBusiness userBusiness)
        {
            _userBusiness = userBusiness;
        }

        [HttpPost]
        public async Task<IActionResult> Create(UserDTO userDTO)
        {
             
            try
            {
                var response = await _userBusiness.CreateAsync(userDTO);

                return ApiResponse(HttpStatusCode.OK, response);
            }
            catch (BadRequestException e)
            {
                return ApiResponse(HttpStatusCode.BadRequest, e.Errors);
            }
            catch (Exception e)
            {
                return ApiResponse(HttpStatusCode.InternalServerError);
            }
        }
    }

    
}
