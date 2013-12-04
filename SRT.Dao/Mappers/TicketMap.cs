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
    public class TicketMap : ClassMap<Ticket>
    {
        public TicketMap()
        {
            Id(x => x.Id).GeneratedBy.Identity();

            Map(x => x.Subject);
            Map(x => x.RaisedBy);
            Map(x => x.RaisedTo);
            Map(x => x.IsCancelled);
            Map(x => x.RaisedDate);
            Map(x => x.SolvedDate);
            Map(x => x.Description);
            Map(x => x.Email);
            Map(x => x.status);
            Map(x => x.Urgency);

            References(x => x.user).LazyLoad();
        }
    }
    public class TicketMappingAlteration : IAutoMappingAlteration
    {
        public void Alter(AutoPersistenceModel model)
        {
            model.Override<Ticket>(mapping => mapping.IgnoreProperty(x => x.Message));
            model.Override<Ticket>(mapping => mapping.IgnoreProperty(x => x.Status));
        }
    }
}
