using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PaintballTournaments.Core.Locations;
using SharpArch.Core.DomainModel;

namespace PaintballTournaments.Core.Commercials
{
    public abstract class BasicCommercial : Entity
    {
        private string name;
        private string address;
        private string telephone;
        private string logoUri;
        private City city;
        private SponsorType sponsorType;

        public virtual string Name
        {
            get { return name; }
            set { name = value; }
        }

        public virtual string Address
        {
            get { return address; }
            set { address = value; }
        }

        public virtual string Telephone
        {
            get { return telephone; }
            set { telephone = value; }
        }

        public virtual string LogoUri
        {
            get { return logoUri; }
            set { logoUri = value; }
        }

        public virtual SponsorType SponsorType
        {
            get { return sponsorType; }
            set { sponsorType = value; }
        }

        public virtual City City
        {
            get { return city; }
            set { city = value; }
        }
    }
}
