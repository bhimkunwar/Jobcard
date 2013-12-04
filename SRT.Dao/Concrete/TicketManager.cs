using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SRT.Core.Domains;
using SRT.Dao.Abstract;
using NHibernate;
using NHibernate.Criterion;
using System.Collections;

namespace SRT.Dao.Concrete
{
    public class TicketManager : BaseDao<Ticket, long>, ITicketManager
    {
        Ticket ITicketManager.IssueTicket(Ticket entity)
        {
            Ticket _ticket = new Ticket();
            ITransaction transaction = null;   
            try
            {
                ISession session = null;
                session = NhibernateHelper.OpenSession();
                transaction = session.BeginTransaction();

                 session.Save(entity);
                transaction.Commit();
                return entity;

            }
            catch
            {
                transaction.Rollback();
                return entity;
            }
        }

        bool ITicketManager.UpdateSolvedTicket(Ticket entity)
        {
            bool isSolved = false;
            ITransaction transaction = null;
            try
            {
                ISession session = null;
                session = NhibernateHelper.OpenSession();

                var ticket = session.CreateCriteria(typeof(Ticket))
                    .Add(Restrictions.Eq("Id", entity.Id))
                    .List<Ticket>().FirstOrDefault();
                if (ticket != null)
                {
                    if (ticket.RaisedBy == entity.RaisedBy)
                    {
                        transaction = session.BeginTransaction();

                        ticket.SolvedDate = DateTime.Now;
                        ticket.status = entity.status;

                        session.SaveOrUpdate(ticket);
                        transaction.Commit();
                        isSolved = true;
                        session.Flush();
                    }                    
                }
                return isSolved;
            }
            catch
            {
                transaction.Rollback();
                return false;
            }
        }

        bool ITicketManager.CancelIssuedTicket(Ticket entity)   
        {
            bool isCanceled = false;
            ITransaction transaction = null;
            try
            {
                ISession session = null;
                session = NhibernateHelper.OpenSession();

                var ticket = session.CreateCriteria(typeof(Ticket))
                    .Add(Restrictions.Eq("Id", entity.Id))
                    .List<Ticket>().FirstOrDefault();
                if (ticket != null)
                {
                    if (ticket.RaisedBy == entity.RaisedBy)
                    {
                        transaction = session.BeginTransaction();

                        ticket.SolvedDate = DateTime.Now;
                        ticket.status = entity.status;
                        ticket.IsCancelled = true;


                        session.SaveOrUpdate(ticket);
                        transaction.Commit();
                        isCanceled = true;
                        session.Flush();
                    }
                }
                return isCanceled;
            }
            catch
            {
                transaction.Rollback();
                return false;
            }
        }

        Ticket IBaseDao<Ticket, long>.FindById(long id)
        {
            ISession session = null;

            session = NhibernateHelper.OpenSession();

            return session.CreateCriteria(typeof(Ticket))
                .Add(Restrictions.Eq("Id", id)).List<Ticket>().FirstOrDefault();

        }

        /// <summary>
        /// Todo: To convert all the Basedao's Methods to use able as in cms
        /// </summary>
        /// <returns></returns>
        //System.Collections.IList IBaseDao<Ticket, long>.FindAll()
        //{
        //    ISession session = null;
        //    session = NhibernateHelper.OpenSession();
        //    return (IList)session.CreateCriteria(typeof(Ticket));
        //    //return session.CreateCriteria<Ticket>().List<Ticket>();
        //}

        #region UnImplemented Methods
        Ticket IBaseDao<Ticket, long>.Save(Ticket entity)
        {
            throw new NotImplementedException();
        }

        Ticket IBaseDao<Ticket, long>.SaveOrUpdate(Ticket entity)
        {
            throw new NotImplementedException();
        }        
        
        System.Collections.IList IBaseDao<Ticket, long>.Find(string query, object[] values)
        {
            throw new NotImplementedException();
        }

        bool IBaseDao<Ticket, long>.Delete(Ticket entity)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
