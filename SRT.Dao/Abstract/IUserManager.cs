namespace SRT.Dao.Abstract
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using SRT.Core.Domains;

    public interface IUserManager : IBaseDao<User, long>
    {
        User GetUSerinfoByUsername(User entity);
        bool IsPasswordChanged(User entity);
        bool IsUserCreated(User entity);
    }
}
