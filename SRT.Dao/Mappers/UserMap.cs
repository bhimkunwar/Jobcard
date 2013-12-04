using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Automapping;
using FluentNHibernate.Automapping.Alterations;
using FluentNHibernate.Mapping;
using SRT.Core.Domains;
namespace SRT.Dao.Mappers
{    
    public class UserMap : ClassMap<User>
    {
        public UserMap()
        {
            Id(x => x.Id);
            Map(x => x.UserName);
            Map(x => x.OldPassword);
            Map(x => x.IsActive);
            Map(x => x.Name);
            Map(x => x.Designation);
            Map(x => x.UserType);                       

            References(x => x.company).LazyLoad();
            //HasMany(x => x.ticket).LazyLoad();            
        }
    }
    public class UserMappingAlteration : IAutoMappingAlteration
    {
        public void Alter(AutoPersistenceModel model)
        {
            model.Override<User>(mapping => mapping.IgnoreProperty(x => x.Message));
            model.Override<User>(mapping => mapping.IgnoreProperty(x => x.Status));
        }
    }
}
