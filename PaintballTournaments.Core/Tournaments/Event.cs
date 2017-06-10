using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpArch.Core.DomainModel;
using PaintballTournaments.Core.Accounts;
using System.Collections.ObjectModel;
using PaintballTournaments.Core.Commercials;

namespace PaintballTournaments.Core.Tournaments
{
    public class Event : Entity
    {
        private DateTime initialDate;
        private DateTime finalDate;
        private Layout layout;
        private string info;
        private IList<Category> _categories = new List<Category>();
        private IList<Prize> _prizes = new List<Prize>();
        private IList<Sponsor> _sponsors = new List<Sponsor>();
                
        public virtual DateTime InitialDate
        {
            get { return initialDate; }
            set { initialDate = value; }
        }

        public virtual DateTime FinalDate
        {
            get { return finalDate; }
            set { finalDate = value; }
        }

        public virtual Field Field
        {
            get { return this.layout.Field; }
        }

        public virtual Layout Layout
        {
            get { return layout; }
            set { layout = value; }
        }

        public virtual string Info
        {
            get { return info; }
            set { info = value; }
        }

        private IList<Category> categories
        {
            get { return _categories; }
            set { _categories = value; }
        }

        private ReadOnlyCollection<Category> categoriesView;
        public virtual ReadOnlyCollection<Category> Categories
        {
            get
            {
                if (this.categoriesView == null)
                    categoriesView = new ReadOnlyCollection<Category>(categories);
                return this.categoriesView;
            }
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

        public virtual void AddCategory(Category category)
        {
            this.categories.Add(category);
        }

        public virtual void RemoveCategory(Category category)
        {
            if(category.Selections.Count > 0)
                throw new Exception("The category have teams");
            this.categories.Remove(category);
        }

        public virtual void AddPrize(Prize prize)
        {
            this.prizes.Add(prize);
        }

        public virtual void RemovePrize(Prize prize)
        {
            this.prizes.Remove(prize);
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

        public virtual void SetField(Field field)
        {
            Layout layout = new Layout();
            layout.Field = field;
            this.Layout = layout;
        }
    }
}

