using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace PaintballTournaments.Core.Locations
{
    public class Country : BasicLocation
    {
        private IList<State> _states;

        private IList<State> states
        {
            get { return _states; }
            set { _states = value; }
        }

        private ReadOnlyCollection<State> statesView;
        public virtual ReadOnlyCollection<State> States
        {
            get
            {
                if (this.statesView == null)
                    statesView = new ReadOnlyCollection<State>(states);
                return this.statesView;
            }
        }

        public virtual void AddState(State state)
        {
            this.states.Add(state);
        }
    }
}
