using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Sat.Recruitment.Api.Controllers;
using Sat.Recruitment.Api.Services;
using Sat.Recruitment.Business;
using Sat.Recruitment.Business.Dto;
using Sat.Recruitment.Common.Helpers;
using Sat.Recruitment.Common.Resources;
using Sat.Recruitment.DAO;
using Sat.Recruitment.Domain.DTO;
using Sat.Recruitment.IBusiness.Business;
using Sat.Recruitment.IBusiness.Dto;
using Sat.Recruitment.IBusiness.Enum;
using Sat.Recruitment.IBusiness.Interface;
using Sat.Recruitment.IDAO.Interface;
using Sat.Recruitment.Repository;
using Xunit;

namespace Sat.Recruitment.Test
{
    [CollectionDefinition("Tests", DisableParallelization = true)]
    public class UserUnitTest
    {
        private readonly UserController _userController;
        private bool runTestCreateUserOk = false;

        public UserUnitTest()
        {
            var services = new ServiceCollection();

            services.Inject();

            var serviceProvider = services.BuildServiceProvider();

            _userController = serviceProvider.GetService<UserController>();
 
        }

        [Fact]
        public async Task CreateUserOk()
        {
            var response = await _userController.Create(new UserDTO
            {
                Name = "Mike",
                Email = "mike@gmail.com",
                Address = "Av. Juan G.",
                Phone = "+349 1122354214",
                UserType = UserType.Normal,
                Money = 124
            });

            var okResult = response as ObjectResult;

            Assert.NotNull(okResult);
            Assert.True(okResult is ObjectResult);
            Assert.IsType<UserDTO>(okResult.Value);
            Assert.Equal(StatusCodes.Status200OK, okResult.StatusCode);
        }

        [Fact]
        public async Task CreateUserBadRequest()
        {
            await _userController.Create(new UserDTO
            {
                Name = "Jorge",
                Email = "mike2@gmail.com",
                Address = "Av. Juan G",
                Phone = "+349 1122354215",
                UserType = UserType.Normal,
                Money = 124
            });

            var response = await _userController.Create(new UserDTO
            {
                Name = "Agustina",
                Email = "Agustina@gmail.com",
                Address = "Av. Juan G",
                Phone = "+349 1122354215",
                UserType = UserType.Normal,
                Money = 124
            });

            var result = response as ObjectResult;

            Assert.NotNull(result);
            Assert.True(result is ObjectResult);
            Assert.IsType<List<string>>(result.Value);

            var data = (List<string>)result.Value;

            Assert.Equal(data[0], AppResource.DuplicatedUser);
            Assert.Equal(StatusCodes.Status400BadRequest, result.StatusCode);
        }
    }
}
