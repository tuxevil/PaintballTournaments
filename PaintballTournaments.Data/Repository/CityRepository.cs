using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PaintballTournaments.Core.DataInterfaces;
using PaintballTournaments.Core.Locations;
using SharpArch.Data.NHibernate;

namespace PaintballTournaments.Data.Repository
{
    public class CityRepository : Repository<City>, ICityRepository
    {
        public override City SaveOrUpdate(City o)
        {
            NHibernateSession.Current.BeginTransaction();
            NHibernateSession.Current.SaveOrUpdate(o);
            NHibernateSession.Current.Transaction.Commit();
            return o;
        }
    }
}
