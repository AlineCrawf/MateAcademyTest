using System;
using System.Collections.Generic;
using System.Text;

namespace MateAcademyTest
{
    class Gymnast
    {
        private string name, surname;
        private double skillLevel;
        private Nationality nationality;

        public Gymnast()
        {

        }

        public Gymnast(string name,string surname,double skillLevel, Nationality nationality)
        {
            this.name = name;
            this.surname = surname;
            this.skillLevel = skillLevel;
            this.nationality = nationality;
        }

        public Nationality Nationality { get => nationality; set => nationality = value; }
        public double SkillLevel { get => skillLevel; set => skillLevel = value; }
        public string Name { get => name; set => name = value; }
        public string Surname { get => surname; set => surname = value; }

        public double perfomance()
        {
            Random rd = new Random();
            return rd.NextDouble() * skillLevel;        //Random level of perfomance
        }

        public string Info()
        {
            return $"Name: {name} Surname:{surname} Skill level: {skillLevel} Nationality: {nationality}";
        }
    }
}
