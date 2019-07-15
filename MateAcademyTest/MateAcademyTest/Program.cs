using System;
using System.Collections.Generic;
using System.Linq;


namespace MateAcademyTest
{
    class Program
    {

        static judge newJudge()
        {
                judge newJudge = new judge();
                Console.WriteLine("Enter judge's name");
                newJudge.Name = Console.ReadLine();
                Console.WriteLine("Enter judge's surname");
                newJudge.Surname = Console.ReadLine();
                Console.WriteLine("Enter judge's nationality");
                string tmp = Console.ReadLine();
                switch (tmp)
                {
                    case "French": newJudge.Nationality = Nationality.French; break;
                    case "German": newJudge.Nationality = Nationality.German; break;
                    case "Italian": newJudge.Nationality = Nationality.Italian; break;
                    case "Polish": newJudge.Nationality = Nationality.Polish; break;
                    case "Korean": newJudge.Nationality = Nationality.Korean; break;
                    case "Ukrainian": newJudge.Nationality = Nationality.Ukrainian; break;
                    default: new Exception("Error nationality"); break;
                }

            return newJudge;
        }

        static Gymnast newGymnast()
        {
            Gymnast newGymnast = new Gymnast();
            Console.WriteLine("Enter gymnast's name");
            newGymnast.Name = Console.ReadLine();
            Console.WriteLine("Enter gymnast's surname");
            newGymnast.Surname = Console.ReadLine();
            Console.WriteLine("Enter gymnast's skill level");
            newGymnast.SkillLevel = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Enter gymnast's nationality");
            string tmp = Console.ReadLine();
            switch (tmp)
            {
                case "French": newGymnast.Nationality = Nationality.French; break;
                case "German": newGymnast.Nationality = Nationality.German; break;
                case "Italian": newGymnast.Nationality = Nationality.Italian; break;
                case "Polish": newGymnast.Nationality = Nationality.Polish; break;
                case "Korean": newGymnast.Nationality = Nationality.Korean; break;
                case "Ukrainian": newGymnast.Nationality = Nationality.Ukrainian; break;
                default: new Exception("Error nationality"); break;
            }

            return newGymnast;
        }

        static void Main(string[] args)
        {
            List<Gymnast> gymList = new List<Gymnast>();
            List<judge> judgeList = new List<judge>();
            List<Perfomance> perfList = new List<Perfomance>();

            int Judgecount;
            int GymCount;
            #region AddObjects
            //gymList.Add(new Gymnast("Aline", "Crawford", 5.6, Nationality.Ukrainian));
            //gymList.Add(new Gymnast("Aline", "Crawford", 5.9, Nationality.Ukrainian));
            //gymList.Add(new Gymnast("Alex", "Dest", 4.8, Nationality.German));
            //gymList.Add(new Gymnast("Alex2", "Dest", 2.8, Nationality.German));
            //gymList.Add(new Gymnast("Ann", "Veber", 3.7, Nationality.Korean));
            //gymList.Add(new Gymnast("Ann2", "Veber", 4.7, Nationality.Korean));
            //gymList.Add(new Gymnast("Peter", "Ivanov", 2.6, Nationality.Polish));
            //gymList.Add(new Gymnast("Peter2", "Ivanov", 4.6, Nationality.Polish));

            //judgeList.Add(new judge("Liz", "Blood", Nationality.Italian));
            //judgeList.Add(new judge("Liz2", "Blood", Nationality.Korean));
            //judgeList.Add(new judge("Victor", "Everglot", Nationality.German));
            //judgeList.Add(new judge("Victor2", "Everglot", Nationality.Polish));
            #endregion

            Judgecount = judgeList.Count;
            GymCount = gymList.Count;

            try
            {
               
                Console.WriteLine("Enter judges count");
                Judgecount = Convert.ToInt32(Console.ReadLine());

                for (int i = 0; i < Judgecount; i++)
                {
                    judgeList.Add(newJudge());
                }
                Console.WriteLine("Enter gymnasts count");
                GymCount = Convert.ToInt32(Console.ReadLine());
                //TODO: remove function from class to separate function

                for(int i = 0;i< GymCount;i++)
                {
                    gymList.Add(newGymnast());
                }

                for (int i = 0; i < GymCount; i++)
                {
                    
                    Console.WriteLine($"{gymList[i].Name} {gymList[i].Surname}");


                    List<double> marks = new List<double>();
                    double perfSkill = gymList[i].perfomance();
                    double avr = 0;

                    for (int j = 0; j < Judgecount; j++)
                    {

                        if (judgeList[j].Nationality != gymList[i].Nationality)
                            marks.Add(judgeList[j].mark());
                    }

                    marks.Sort();
                    if (marks.Count > 2)
                    {
                        marks.RemoveAt(0);
                        marks.RemoveAt(marks.Count - 1);                     // remove max adn min mark
                    }
                    for (int j = 0; j < marks.Count; j++)
                    {
                        avr += marks[j];
                    }

                    avr /= marks.Count;

                    perfList.Add(new Perfomance(gymList[i], avr, gymList[i].SkillLevel));
                    Console.WriteLine($"Total mark: { perfList.Last().TotalMark}");
                }

                while (true)
                {
                    Console.WriteLine("Do you want sth else?:\n select gymnasts order by name: 1\nselect gymnasts order by score:2\nInfo about perfomance:3");
                    string want = Console.ReadLine();

                    switch (want)
                    {
                        case "1":
                            var select = gymList.OrderBy(t => t.Name);
                            foreach (var tmp in select)
                                Console.WriteLine(tmp.Info());
                            break;

                        case "2":
                            var select1 = perfList.OrderByDescending(t => t.TotalMark);
                            foreach (var tmp in select1)
                                Console.WriteLine(tmp.Gymnast.Info());
                            break;
                        case "3":
                            for (int i = 0; i < perfList.Count; i++)
                                Console.WriteLine(perfList[i].Info());
                            break;
                        default: System.Environment.Exit(1); break;
                    }
                }
               // Console.ReadKey();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadKey();
            }
        }

       
    }
}
