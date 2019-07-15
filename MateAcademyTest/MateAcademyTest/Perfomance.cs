using System;
using System.Collections.Generic;
using System.Text;

namespace MateAcademyTest
{
    class Perfomance
    {
        private Gymnast gymnast;
        private double judgemark;
        private double GymSkill;
        private double totalMark;
        public Perfomance(Gymnast g, double judgemark,double GymSkill)
        {
            this.gymnast = g;
            this.judgemark = judgemark;
            this.GymSkill = GymSkill;
            // total Mark is average of judges marks amd gymnast skill
            this.totalMark = (judgemark + GymSkill)/2 ;    
        }

        public double TotalMark { get => totalMark; set => totalMark = value; }
        internal Gymnast Gymnast { get => gymnast; set => gymnast = value; }

        public string Info()
        {
            return $"Name: {gymnast.Name} Surname: {gymnast.Surname} judge mark: {judgemark} Gymnast skill: {GymSkill}\n TOTAL MARK: {totalMark}";
        }
    }
}
