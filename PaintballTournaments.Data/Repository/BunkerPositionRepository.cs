using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PaintballTournaments.Core.DataInterfaces;
using PaintballTournaments.Core.Tournaments;
using SharpArch.Data.NHibernate;

namespace PaintballTournaments.Data.Repository
{
    public class BunkerPositionRepository : Repository<BunkerPosition>, IBunkerPositionRepository
    {
        public override BunkerPosition SaveOrUpdate(BunkerPosition o)
        {
            NHibernateSession.Current.BeginTransaction();
            NHibernateSession.Current.SaveOrUpdate(o);
            NHibernateSession.Current.Transaction.Commit();
            return o;
        }
    }
}
