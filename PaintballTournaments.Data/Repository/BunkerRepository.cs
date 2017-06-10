using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PaintballTournaments.Core.DataInterfaces;
using PaintballTournaments.Core.Tournaments;
using SharpArch.Data.NHibernate;

namespace PaintballTournaments.Data.Repository
{
    public class BunkerRepository : Repository<Bunker>, IBunkerRepository
    {
        public override Bunker SaveOrUpdate(Bunker o)
        {
            NHibernateSession.Current.BeginTransaction();
            NHibernateSession.Current.SaveOrUpdate(o);
            NHibernateSession.Current.Transaction.Commit();
            return o;
        }
    }
}
