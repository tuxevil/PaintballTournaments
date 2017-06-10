using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpArch.Core.DomainModel;

namespace PaintballTournaments.Core.Tournaments
{
    public class Bunker : Entity
    {
        private string name;
        private string imageUri;

        public virtual string Name
        {
            get { return name; }
            set { name = value; }
        }

        public virtual string ImageUri
        {
            get { return imageUri; }
            set { imageUri = value; }
        }
    }
}
