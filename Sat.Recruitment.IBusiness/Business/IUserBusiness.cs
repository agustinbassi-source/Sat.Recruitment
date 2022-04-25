using Sat.Recruitment.IBusiness.Dto;
using System.Threading.Tasks;

namespace Sat.Recruitment.IBusiness.Interface
{
    public interface IUserBusiness
    {
        Task<IUserDTO> CreateAsync(IUserDTO user);
    }
}
