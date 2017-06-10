using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpArch.Core.DomainModel;
using PaintballTournaments.Core.Accounts;
using System.Collections.ObjectModel;

namespace PaintballTournaments.Core.Tournaments
{
    public class League : Entity
    {
        private string name;
        private SubMode subMode;
        private Organizer organizer;
        private IList<Prize> _prizes = new List<Prize>();
        private IList<Event> _events = new List<Event>();
        private IList<Sponsor> _sponsors = new List<Sponsor>();

        public virtual string Name
        {
            get { return name; }
            set { name = value; }
        }

        public virtual SubMode SubMode
        {
            get { return subMode; }
            set { subMode = value; }
        }

        public virtual Mode Mode
        {
            get { return this.subMode.Mode; }
        }

        public virtual Organizer Organizer
        {
            get { return organizer; }
            set { organizer = value; }
        }

        private IList<Prize> prizes
        {
            get { return _prizes; }
            set { _prizes = value; }
        }

        private ReadOnlyCollection<Prize> prizesView;
        public virtual ReadOnlyCollection<Prize> Prizes
        {
            get
            {
                if (this.prizesView == null)
                    prizesView = new ReadOnlyCollection<Prize>(prizes);
                return this.prizesView;
            }
        }

        private IList<Event> events
        {
            get { return _events; }
            set { _events = value; }
        }

        private ReadOnlyCollection<Event> eventsView;
        public virtual ReadOnlyCollection<Event> Events
        {
            get
            {
                if (this.eventsView == null)
                    eventsView = new ReadOnlyCollection<Event>(events);
                return this.eventsView;
            }
        }

        private IList<Sponsor> sponsors
        {
            get { return _sponsors; }
            set { _sponsors = value; }
        }

        private ReadOnlyCollection<Sponsor> sponsorsView;
        public virtual ReadOnlyCollection<Sponsor> Sponsors
        {
            get
            {
                if (this.sponsorsView == null)
                    sponsorsView = new ReadOnlyCollection<Sponsor>(sponsors);
                return this.sponsorsView;
            }
        }

        public virtual void AddPrize(Prize prize)
        {
            this.prizes.Add(prize);
        }

        public virtual void RemovePrize(Prize prize)
        {
            this.prizes.Remove(prize);
        }

        public virtual void AddEvent(Event event_)
        {
            this.events.Add(event_);
        }

        public virtual void RemoveEvent(Event event_)
        {
            foreach (Category category in event_.Categories)
                if (category.Selections.Count > 0)
                    throw new Exception("The event have category with teams");
            this.events.Remove(event_);
        }

        public virtual void AddSponsor(Sponsor sponsor)
        {
            this.sponsors.Add(sponsor);
        }

        public virtual void RemoveSponsor(Sponsor sponsor)
        {
            foreach (Prize prize in this.prizes)
                if (prize.Sponsor == sponsor)
                    throw new Exception("That sponsor have prize");
            this.sponsors.Remove(sponsor);
        }
    }
}
