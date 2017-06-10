using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpArch.Core.DomainModel;

namespace PaintballTournaments.Core.Tournaments
{
    public class Mode : Entity
    {
        private string name;
        private IList<SubMode> subModes = new List<SubMode>();

        public virtual string Name
        {
            get { return name; }
            set { name = value; }
        }

        public virtual IList<SubMode> SubModes
        {
            get { return subModes; }
            set { subModes = value; }
        }

        public virtual void AddSubMode(SubMode subMode)
        {
            this.subModes.Add(subMode);
        }

        public virtual void RemoveSubMode(SubMode subMode)
        {
            this.subModes.Remove(subMode);
        }
    }
}
