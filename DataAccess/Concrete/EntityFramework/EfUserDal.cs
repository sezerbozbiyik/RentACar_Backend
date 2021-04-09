using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Core.Entities.Concrete;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Entities.DTOs;

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
                             on operationclaim.Id equals userOperationClaim.OperationClaimId
                             where userOperationClaim.UserId == user.Id
                             select new OperationClaim { Id = operationclaim.Id, Name = operationclaim.Name };
                return result.ToList();

            }
        }

        public UserDetailDto GetUserDetailById(int id)
        {
            using (RentDatabaseContext context = new RentDatabaseContext())
            {
                var result = from users in context.Users
                             join customers in context.Customers
                             on users.Id equals customers.UserId
                             where users.Id == id
                             select new UserDetailDto
                             {
                                 UserID = users.Id,
                                 CustomerID = customers.Id,
                                 FirstName = users.FirstName,
                                 LastName = users.LastName,
                                 Email = users.Email,
                                 CustomerName = customers.CompanyName
                             };
                return result.SingleOrDefault();
            }
        }

        public List<UserDetailDto> GetUserDetails()
        {
            using (RentDatabaseContext context = new RentDatabaseContext())
            {
                var result = from users in context.Users
                             join customers in context.Customers
                             on users.Id equals customers.UserId
                             select new UserDetailDto
                             {
                                 UserID = users.Id,
                                 CustomerID = customers.Id,
                                 FirstName = users.FirstName,
                                 LastName = users.LastName,
                                 Email = users.Email,
                                 CustomerName = customers.CompanyName
                             };
                return result.ToList();
            }
        }
    }
}
