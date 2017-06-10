using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpArch.Core.DomainModel;
using PaintballTournaments.Core.Commercials;
using System.Collections.ObjectModel;

namespace PaintballTournaments.Core.Tournaments
{
    public class Layout : Entity
    {
        private Field field;
        private LayoutTemplate layoutTemplate;
        private IList<BunkerPosition> _bunkerPositions;

        public virtual Field Field
        {
            get { return field; }
            set { field = value; }
        }

        public virtual LayoutTemplate LayoutTemplate
        {
            get { return layoutTemplate; }
            set { layoutTemplate = value; }
        }

        private IList<BunkerPosition> bunkerPositions
        {
            get { return _bunkerPositions; }
            set { _bunkerPositions = value; }
        }

        private ReadOnlyCollection<BunkerPosition> bunkerPositionsView;
        public virtual ReadOnlyCollection<BunkerPosition> BunkerPositions
        {
            get
            {
                if (this.bunkerPositionsView == null)
                    bunkerPositionsView = new ReadOnlyCollection<BunkerPosition>(bunkerPositions);
                return this.bunkerPositionsView;
            }
        }

        public Layout() { }
        public Layout(Field field, LayoutTemplate layoutTemplate)
        {
            this.field = field;
            foreach (BunkerPosition bunkerPosition in layoutTemplate.BunkerPositions)
                this.AddBunker(bunkerPosition.Bunker, bunkerPosition.X, bunkerPosition.Y, bunkerPosition.R);
        }

        public virtual void AddBunker(Bunker bunker, int x, int y, int r)
        {
            if (this.field == null)
                throw new Exception("First select a field");
            if (x > this.field.Width || y > this.field.Height)
                //TODO: Hacer que reconozca la escala a la que habria que bajar las posiciones
                throw new Exception("The bunker is out of the field");
            this.bunkerPositions.Add(new BunkerPosition(bunker, x, y, r));
        }
    }
}
