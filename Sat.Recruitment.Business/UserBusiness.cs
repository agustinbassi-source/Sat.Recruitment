using Sat.Recruitment.Business.Dto;
using Sat.Recruitment.Common.Helpers;
using Sat.Recruitment.Common.Resources;
using Sat.Recruitment.Domain.DTO;
using Sat.Recruitment.IBusiness.Business;
using Sat.Recruitment.IBusiness.Dto;
using Sat.Recruitment.IBusiness.Interface;
using Sat.Recruitment.IDAO.Interface;
using Sat.Recruitment.Mapper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Sat.Recruitment.Business
{
    public class UserBusiness : IUserBusiness
    {
        private readonly IUserRepository _userRepository;
        private readonly IMoneyBusiness  _moneyBusiness;
        private readonly UserMapper _userMapper;
        public UserBusiness(IUserRepository userRepository, IMoneyBusiness moneyBusiness)
        {
            _userRepository = userRepository;
            _userMapper = new UserMapper();
            _moneyBusiness = moneyBusiness;
        }

        public async Task<IUserDTO> CreateAsync(IUserDTO userDTO)
        {
            userDTO.Email = userDTO.Email.NormalizeEmail();
            userDTO.Money = _moneyBusiness.CalculateAmount(userDTO);

            var exist = _userRepository.Exist(x => (x.Email == userDTO.Email || x.Phone == userDTO.Phone)
                                       || (x.Name == userDTO.Name && x.Address == userDTO.Address));

            if (exist)
                throw new BadRequestException(new List<string> { AppResource.DuplicatedUser });

            var user = _userMapper.User(userDTO);

            user = await _userRepository.CreateAsync(user);

            return _userMapper.UserDTO(user);
        }


    }
}
