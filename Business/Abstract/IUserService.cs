using Core.Utilities.Results;
using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface IUserService
    {
        IDataResult<List<OperationClaim>> GetClaims(User user);
        IResult Add(User user);
        IDataResult<User> GetByMail(string mail);
        IDataResult<List<UserDetailDto>> GetUserDetails();
        IDataResult<UserDetailDto> GetUserDetailByMail(string email);
    }
}
