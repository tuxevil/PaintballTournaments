using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PaintballTournaments.Core.Groups;

namespace PaintballTournaments.Core.Accounts
{
    public class Player : BasicUser
    {
        private Team team;
        private DateTime playSince;
        private string pictureUri;
        private PlayerPosition playerPosition;

        public virtual Team Team
        {
            get { return team; }
            set { team = value; }
        }

        public virtual DateTime PlaySince
        {
            get { return playSince; }
            set { playSince = value; }
        }

        public virtual string PictureUri
        {
            get { return pictureUri; }
            set { pictureUri = value; }
        }

        public virtual PlayerPosition PlayerPosition
        {
            get { return playerPosition; }
            set { playerPosition = value; }
        }
    }
}
