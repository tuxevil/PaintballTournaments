using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PaintballTournaments.Core.Commercials;


namespace PaintballTournaments.Core.Accounts
{
    public class Organizer : BasicUser
    {
        private Field field;

        public virtual Field Field
        {
            get { return field; }
            set { field = value; }
        }

    }
}
