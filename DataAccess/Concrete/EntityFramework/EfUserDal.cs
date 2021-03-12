using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Core.Entities.Concrete;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : EfEntityRepositoryBase<User, RentDatabaseContext>, IUserDal
    {
        public List<OperationClaim> GetClaims(User user)
        {
            using (var context = new RentDatabaseContext())
            {
                var result = from operationclaim in context.OperationClaims
                             join userOperationClaim in context.UserOperationClaims
                             on operationclaim.Id equals userOperationClaim.Id
                             where userOperationClaim.UserId == user.Id
                             select new OperationClaim { Id = operationclaim.Id, Name = operationclaim.Name };
                return result.ToList();

            }
        }
    }
}
