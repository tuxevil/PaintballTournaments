using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PaintballTournaments.Core.Commercials
{
    public class Field : BasicCommercial
    {
        private int width;
        private int height;

        public virtual int Width
        {
            get { return width; }
            set { width = value; }
        }

        public virtual int Height
        {
            get { return height; }
            set { height = value; }
        }
    }
}
