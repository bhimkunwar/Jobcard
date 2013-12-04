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
    public class CompanyMap : ClassMap<Company>
    {
        public CompanyMap()
        {
            Id(x => x.Id).GeneratedBy.Identity();

            Map(x => x.CompanyName);
            Map(x => x.Address);
            Map(x => x.ContactPerson);
            Map(x => x.Email);
            Map(x => x.FaxNo);
            Map(x => x.IsActive);
            Map(x => x.JoinedDate);
            Map(x => x.Mobile);
            Map(x => x.ValidTillDate);
            HasMany(x => x.user);
            

        }
    }
    public class CompanyMappingAlteration : IAutoMappingAlteration
    {
        public void Alter(AutoPersistenceModel model)
        {
            model.Override<User>(mapping => mapping.IgnoreProperty(x => x.Message));
            model.Override<User>(mapping => mapping.IgnoreProperty(x => x.Status));
        }
    }
}
