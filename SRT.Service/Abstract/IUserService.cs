using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SRT.Core.Domains;
namespace SRT.Service.Abstract
{
    public interface IUserService : IBaseService<User, long>
    {
        User GetUSerinfoByUsername(User entity);
        bool IsPasswordChanged(User entity);
        bool IsUserCreated(User entity);
        bool IsPasswordValid(User entity);
    }
}
