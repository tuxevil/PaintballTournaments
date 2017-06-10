using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PaintballTournaments.Core.Accounts;
using SharpArch.Core.DomainModel;

namespace PaintballTournaments.Core.Tournaments
{
    public class LayoutTemplate : Entity
    {
        private string imageUri;
        private Organizer creator;
        private IList<BunkerPosition> bunkerPositions;
        
        public virtual string ImageUri
        {
            get { return imageUri; }
            set { imageUri = value; }
        }

        public virtual Organizer Creator
        {
            get { return creator; }
            set { creator = value; }
        }

        public virtual IList<BunkerPosition> BunkerPositions
        {
            get { return bunkerPositions; }
            set { bunkerPositions = value; }
        }

        public virtual void AddBunker(Bunker bunker, int x, int y, int r)
        {
            this.bunkerPositions.Add(new BunkerPosition(bunker, x, y, r));
        }

        public LayoutTemplate() { }
        public LayoutTemplate(Layout layout)
        {
            foreach (BunkerPosition bunkerPosition in layout.BunkerPositions)
                this.AddBunker(bunkerPosition.Bunker, bunkerPosition.X, bunkerPosition.Y, bunkerPosition.R);
        }

    }
}
