using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpArch.Core.DomainModel;
using PaintballTournaments.Core.Groups;

namespace PaintballTournaments.Core.Tournaments
{
    public class FixtureSelection : Entity
    {
        private Selection selection;
        private int fixturePosition;

        public virtual Selection Selection
        {
            get { return selection; }
            set { selection = value; }
        }

        public virtual int FixturePosition
        {
            get { return fixturePosition; }
            set { fixturePosition = value; }
        }

        public FixtureSelection() { }
        public FixtureSelection(Selection selection)
        {
            this.selection = selection;
            this.fixturePosition = 0;
        }
        public FixtureSelection(Selection selection, int fixturePosition)
        {
            this.selection = selection;
            this.fixturePosition = fixturePosition;
        }

    }
}
