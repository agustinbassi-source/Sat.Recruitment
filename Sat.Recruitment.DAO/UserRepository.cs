using Sat.Recruitment.Domain.Models;
using Sat.Recruitment.IDAO.Interface;
using Sat.Recruitment.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Sat.Recruitment.DAO
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        private readonly Context _context;

        public UserRepository(Context context) : base(context)
        {
          _context = context;
        }
 
    }
}
