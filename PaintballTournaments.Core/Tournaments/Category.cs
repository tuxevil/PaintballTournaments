using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpArch.Core.DomainModel;
using PaintballTournaments.Core.Groups;
using System.Collections.ObjectModel;

namespace PaintballTournaments.Core.Tournaments
{
    public class Category : Entity
    {
        private CategoryType categoryType;
        private Fixture fixture;
        private string name;
        private int maxPlayers;
        private int subPlayers;
        private int topPlayers;
        private int maxTeams;
        private int bestOf;
        private decimal cost;

        public virtual CategoryType CategoryType
        {
            get { return categoryType; }
            set { categoryType = value; }
        }

        public virtual Fixture Fixture
        {
            get { return fixture; }
            protected set { fixture = value; }
        }

        public virtual ReadOnlyCollection<FixtureSelection> Selections
        {
            get { return this.fixture.FixtureSelections; }
        }

        public virtual string Name
        {
            get { return name; }
            set { name = value; }
        }

        public virtual int MaxPlayers
        {
            get { return maxPlayers; }
            set { maxPlayers = value; }
        }

        public virtual int SubPlayers
        {
            get { return subPlayers; }
            set { subPlayers = value; }
        }

        public virtual int MaxTeams
        {
            get { return maxTeams; }
            set { maxTeams = value; }
        }

        public virtual int TopPlayers
        {
            get { return topPlayers; }
            set { topPlayers = value; }
        }

        public virtual int BestOf
        {
            get { return bestOf; }
            set { bestOf = value; }
        }

        public virtual decimal Cost
        {
            get { return cost; }
            set { cost = value; }
        }

        public virtual void AddSelection(Selection selection)
        {
            if (this.fixture == null)
                this.fixture = new Fixture();
            if (this.fixture.FixtureSelections.Count >= this.maxTeams)
                throw new Exception("The category is full");
            this.fixture.AddSelection(selection);
        }

        public virtual void RemoveSelection(Selection selection)
        {
            this.fixture.RemoveSelection(selection);
        }
    }
}
