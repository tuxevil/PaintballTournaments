using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpArch.Core.DomainModel;
using PaintballTournaments.Core.Groups;
using System.Collections.ObjectModel;

namespace PaintballTournaments.Core.Tournaments
{
    public class Fixture : Entity
    {
        private bool auto;
        private int groupQuantity;
        private int groupClassification;
        private Category category;
        private IList<FixtureSelection> _fixtureSelections = new List<FixtureSelection>();
        
        public virtual bool Auto
        {
            get { return auto; }
            set { auto = value; }
        }

        public virtual int GroupQuantity
        {
            get { return groupQuantity; }
            set { groupQuantity = value; }
        }

        public virtual int GroupClassification
        {
            get { return groupClassification; }
            set { groupClassification = value; }
        }

        public virtual Category Category
        {
            get { return category; }
            set { category = value; }
        }

        private IList<FixtureSelection> fixtureSelections
        {
            get { return _fixtureSelections; }
            set { _fixtureSelections = value; }
        }

        private ReadOnlyCollection<FixtureSelection> fixtureSelectionsView;
        public virtual ReadOnlyCollection<FixtureSelection> FixtureSelections
        {
            get
            {
                if (this.fixtureSelectionsView == null)
                    fixtureSelectionsView = new ReadOnlyCollection<FixtureSelection>(fixtureSelections);
                return this.fixtureSelectionsView;
            }
        }

        public virtual void AddSelection(Selection selection)
        {
            if (auto)
            {
                List<int> positionsUsed = new List<int>();
                foreach (FixtureSelection fixtureSelection in this.FixtureSelections)
                    positionsUsed.Add(fixtureSelection.FixturePosition);
                this.fixtureSelections.Add(new FixtureSelection(selection, GetPosition(positionsUsed)));
            }
            this.fixtureSelections.Add(new FixtureSelection(selection));
        }

        public virtual void RemoveSelection(Selection selection)
        {
            foreach(FixtureSelection fixtureSelection in this.fixtureSelections)
                if(fixtureSelection.Selection == selection)
                    this.fixtureSelections.Remove(fixtureSelection);
        }

        private int GetPosition(List<int> positionsUsed)
        {
            Random random = new Random();
            int position = random.Next(this.category.MaxTeams - 1);
            if (positionsUsed.Exists(delegate(int record) { if (record == position) { return true; } return false; }))
                return GetPosition(positionsUsed);
            return position;
        }

        public virtual void ResetPositions()
        {
            List<int> positionsUsed = new List<int>();
            foreach (FixtureSelection fixtureSelection in this.FixtureSelections)
            {
                fixtureSelection.FixturePosition = GetPosition(positionsUsed);
                positionsUsed.Add(fixtureSelection.FixturePosition);
            }
        }

        public virtual void GenerateFixture()
        {
            //TODO: Analizar bien esto, es complejo! No encontre codigos ya hechos
        }
    }
}
