using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using SRT.Core.Domains;
namespace SRT.Console.Mappers
{
    public class CompanyMap : ClassMap<Company>
    {
        public CompanyMap()
        {
            //Id(x => x.Id, "").GeneratedBy.Identity().UnsavedValue(0);
            Id(x => x.Id);
            Map(x => x.CompanyName);
            Map(x => x.ContactPerson);
            Map(x => x.Email);
            Map(x => x.FaxNo);

            HasMany(x => x.ticket).Inverse()
                                  .Cascade.All();
        }
    }
}
