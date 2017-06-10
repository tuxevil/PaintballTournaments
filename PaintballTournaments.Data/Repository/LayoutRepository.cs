using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PaintballTournaments.Core.DataInterfaces;
using PaintballTournaments.Core.Tournaments;
using SharpArch.Data.NHibernate;

namespace PaintballTournaments.Data.Repository
{
    public class LayoutRepository : Repository<Layout>, ILayoutRepository
    {
        public override Layout SaveOrUpdate(Layout o)
        {
            NHibernateSession.Current.BeginTransaction();
            NHibernateSession.Current.SaveOrUpdate(o);
            NHibernateSession.Current.Transaction.Commit();
            return o;
        }
    }
}
