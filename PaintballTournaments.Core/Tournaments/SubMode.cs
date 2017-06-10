using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpArch.Core.DomainModel;

namespace PaintballTournaments.Core.Tournaments
{
    public class SubMode : Entity
    {
        private string name;
        private Mode mode;

        public virtual string Name
        {
            get { return name; }
            set { name = value; }
        }

        public virtual Mode Mode
        {
            get { return mode; }
            set { mode = value; }
        }
    }
}
