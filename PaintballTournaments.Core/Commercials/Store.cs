using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PaintballTournaments.Core.Commercials
{
    public class Store : BasicCommercial
    {
        private string bannerUri;

        public virtual string BannerUri
        {
            get { return bannerUri; }
            set { bannerUri = value; }
        }
    }
}
