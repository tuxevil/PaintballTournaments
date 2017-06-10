using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpArch.Core.DomainModel;
using PaintballTournaments.Core.Locations;

namespace PaintballTournaments.Core.Accounts
{
    public abstract class BasicUser : Entity
    {
        private string username;
        private string email;
        private UserType userType;
        private string nickname;
        private string firstname;
        private string lastname;
        private City city;
        private State state;
        private Country country;

        public virtual string Username
        {
            get { return username; }
            set { username = value; }
        }

        public virtual string Email
        {
            get { return email; }
            set { email = value; }
        }

        public virtual UserType UserType
        {
            get { return userType; }
            set { userType = value; }
        }

        public virtual string Nickname
        {
            get { return nickname; }
            set { nickname = value; }
        }

        public virtual string Firstname
        {
            get { return firstname; }
            set { firstname = value; }
        }

        public virtual string Lastname
        {
            get { return lastname; }
            set { lastname = value; }
        }

        public virtual City City
        {
            get { return city; }
            set { city = value; }
        }

        public virtual State State
        {
            get { return state; }
            set { state = value; }
        }

        public virtual Country Country
        {
            get { return country; }
            set { country = value; }
        }
    }
}
