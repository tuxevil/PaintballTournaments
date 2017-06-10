using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpArch.Core.DomainModel;
using PaintballTournaments.Core.Accounts;
using PaintballTournaments.Core.Tournaments;

namespace PaintballTournaments.Core.Groups
{
    public class Team : Entity
    {
        private string name;
        private string logoUri;
        private Player captain;
        private Mode defaultMode;
        private IList<Player> players;

        public virtual string Name
        {
            get { return name; }
            set { name = value; }
        }

        public virtual string LogoUri
        {
            get { return logoUri; }
            set { logoUri = value; }
        }

        public virtual Player Captain
        {
            get { return captain; }
            set { captain = value; }
        }

        public virtual Mode DefaultMode
        {
            get { return defaultMode; }
            set { defaultMode = value; }
        }

        public virtual IList<Player> Players
        {
            get { return players; }
            set { players = value; }
        }
    }
}
