using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PaintballTournaments.Core.Commercials;

namespace PaintballTournaments.Core.Accounts
{
    public class Sponsor : BasicUser
    {
        private SponsorType sponsorType;
        private Store store;

        public virtual SponsorType SponsorType
        {
            get { return sponsorType; }
            set { sponsorType = value; }
        }

        public virtual Store Store
        {
            get { return store; }
            set { store = value; }
        }
    }
}
