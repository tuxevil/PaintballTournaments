using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PaintballTournaments.Core.Commercials;
using PaintballTournaments.Core.DataInterfaces;
using SharpArch.Data.NHibernate;

namespace PaintballTournaments.Data.Repository
{
    public class FieldRepository : Repository<Field>, IFieldRepository
    {
        public override Field SaveOrUpdate(Field o)
        {
            NHibernateSession.Current.BeginTransaction();
            NHibernateSession.Current.SaveOrUpdate(o);
            NHibernateSession.Current.Transaction.Commit();
            return o;
        }
    }
}
