using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpArch.Core.DomainModel;
using PaintballTournaments.Core.Tournaments;
using PaintballTournaments.Core.Accounts;
using System.Collections.ObjectModel;

namespace PaintballTournaments.Core.Groups
{
    public class Selection : Entity
    {
        private Team team;
        private Category category;
        private Player captain;
        private IList<Player> _players = new List<Player>();
        private IList<Player> _topPlayers = new List<Player>();

        public virtual Team Team
        {
            get { return team; }
            set { team = value; }
        }

        public virtual Category Category
        {
            get { return category; }
            set { category = value; }
        }

        public virtual Player Captain
        {
            get { return captain; }
            set { captain = value; }
        }

        private IList<Player> players
        {
            get { return _players; }
            set { _players = value; }
        }

        private ReadOnlyCollection<Player> playersView;
        public virtual ReadOnlyCollection<Player> Players
        {
            get
            {
                if (this.playersView == null)
                    playersView = new ReadOnlyCollection<Player>(players);
                return this.playersView;
            }
        }

        private IList<Player> topPlayers
        {
            get { return _topPlayers; }
            set { _topPlayers = value; }
        }

        private ReadOnlyCollection<Player> topPlayersView;
        public virtual ReadOnlyCollection<Player> TopPlayers
        {
            get
            {
                if (this.topPlayersView == null)
                    topPlayersView = new ReadOnlyCollection<Player>(topPlayers);
                return this.topPlayersView;
            }
        }

        public virtual void AddPlayer(Player player)
        {
            if (this.players.Count >= this.category.MaxPlayers + this.category.SubPlayers)
                throw new Exception("The selection is full");
            if (player.Team != this.team)
                this.AddTopPlayer(player);
            this.players.Add(player);
        }

        public virtual void AddTopPlayer(Player player)
        {
            if (this.topPlayers.Count >= this.category.TopPlayers)
                throw new Exception("The have all the top players allowed");
            this.topPlayers.Add(player);
        }
    }
}
