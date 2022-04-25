using Sat.Recruitment.Domain;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Sat.Recruitment.IDAO.Interface
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task<T> CreateAsync(T entity);
        bool Exist(Expression<Func<T, bool>> predicate);

    }
}
