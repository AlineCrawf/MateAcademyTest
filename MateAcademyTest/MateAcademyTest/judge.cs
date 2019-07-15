using System;
using System.Collections.Generic;
using System.Text;

namespace MateAcademyTest
{
    class judge
    {
        private string name, surname;
        private Nationality nationality;
        public judge()
        {

        }
        public judge( string name, string surname, Nationality nationality)
        {
            this.Name = name;
            this.Surname = surname;
            this.nationality = nationality;
        }

        public Nationality Nationality { get => nationality; set => nationality = value; }
        public string Name { get => name; set => name = value; }
        public string Surname { get => surname; set => surname = value; }

        public double mark()
        {
            Random rd = new Random();
            return rd.NextDouble()*6;           // random mark
        }
    }
}
