using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpArch.Core.DomainModel;

namespace PaintballTournaments.Core.Tournaments
{
    public class BunkerPosition : Entity
    {
        private Bunker bunker;
        private int x;
        private int y;
        private int r;

        public virtual Bunker Bunker
        {
            get { return bunker; }
            set { bunker = value; }
        }

        public virtual int X
        {
            get { return x; }
            set { x = value; }
        }

        public virtual int Y
        {
            get { return y; }
            set { y = value; }
        }

        public virtual int R
        {
            get { return r; }
            set { r = value; }
        }

        public BunkerPosition() { }
        public BunkerPosition(Bunker bunker, int x, int y, int r)
        {
            this.bunker = bunker;
            this.x = x;
            this.y = y;
            this.r = r;
        }

    }
}
