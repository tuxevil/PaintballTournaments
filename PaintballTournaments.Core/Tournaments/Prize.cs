using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpArch.Core.DomainModel;
using PaintballTournaments.Core.Accounts;

namespace PaintballTournaments.Core.Tournaments
{
    public class Prize : Entity
    {
        private Rank rank;
        private Sponsor sponsor;
        private string description;

        public virtual Rank Rank
        {
            get { return rank; }
            set { rank = value; }
        }

        public virtual Sponsor Sponsor
        {
            get { return sponsor; }
            set { sponsor = value; }
        }

        public virtual string Description
        {
            get { return description; }
            set { description = value; }
        }
    }
}
