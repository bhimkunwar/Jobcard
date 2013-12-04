using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using SRT.Core.Domains;
namespace SRT.Console.Mappers
{
    public class TicketMap : ClassMap<Ticket>
    {
        public TicketMap()
        {
            Id(x => x.Id);

            Map(x => x.Subject);
            Map(x => x.RaisedBy);
            Map(x => x.RaisedTo);
            Map(x => x.RaisedDate);
            Map(x => x.SolvedDate);


            References(x => x.company);
        }
    }
}
