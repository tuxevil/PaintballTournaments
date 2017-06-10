using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpArch.Core.DomainModel;

namespace PaintballTournaments.Core.Locations
{
    public class BasicLocation : Entity
    {
        private string name;

        public virtual string Name
        {
            get { return name; }
            set { name = value; }
        }
    }
}
