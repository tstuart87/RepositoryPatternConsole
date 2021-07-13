using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPattern_Repository.People
{
    public class Actor : Person
    {
        public Actor() { }

        public Actor(int id, string firstName, string lastName, string nationality, string biography, int birthYear, Month birthMonth, int birthDay)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Nationality = nationality;
            Biography = biography;
            BirthYear = birthYear;
            BirthMonth = birthMonth;
            BirthDay = birthDay;
        }

        public string Nationality { get; set; }
        public string Biography { get; set; }
        public Month BirthMonth { get; set; }
        public int BirthDay { get; set; }
        public int BirthYear { get; set; }

        private DateTime BirthDate
        {
            get
            {
                return new DateTime(BirthYear, (int)BirthMonth, BirthDay);
            }
        }

        public int Age
        {
            get
            {
                return (int)((DateTime.Today - BirthDate).TotalDays / 365);
            }
        }
    }

    public enum Month
    {
        Jan = 1,
        Feb,
        Mar,
        Apr,
        May,
        Jun,
        Jul,
        Aug,
        Sept,
        Oct,
        Nov,
        Dec
    }
}
