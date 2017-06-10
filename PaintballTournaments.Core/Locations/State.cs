using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace PaintballTournaments.Core.Locations
{
    public class State : BasicLocation
    {
        private IList<City> _cities;

        private IList<City> cities
        {
            get { return _cities; }
            set { _cities = value; }
        }

        private ReadOnlyCollection<City> citiesView;
        public virtual ReadOnlyCollection<City> Cities
        {
            get
            {
                if (this.citiesView == null)
                    citiesView = new ReadOnlyCollection<City>(cities);
                return this.citiesView;
            }
        }

        public virtual void AddCity(City city)
        {
            this.cities.Add(city);
        }
    }
}
