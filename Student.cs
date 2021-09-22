using System;
using System.Globalization;
using System.Threading;

namespace Assignment2
{
    public class Student
    {
        public int id { get; }
        public string GivenName;
        public string SurName;
        public DateTime StartDate;
        public DateTime EndDate;
        public DateTime GraduationDate;
        public Status Status
        {
            get
            {
                if (EndDate != GraduationDate)
                {
                    return Status.Dropout;
                }
                else if (DateTime.Now > GraduationDate)
                {
                    return Status.Graduated;
                }
                else if (DateTime.Now < StartDate.AddDays((double) 365 / 2))
                {
                    return Status.New;
                }
                else
                {
                    return Status.Active;
                }
            }
        }

        public Student(int id, string GivenName, string SurName, DateTime StartDate, DateTime EndDate, DateTime GraduationDate) 
        {
            this.id = id;
            this.GivenName = GivenName;
            this.SurName = SurName;
            this.StartDate = StartDate;
            this.EndDate = EndDate;
            this.GraduationDate = GraduationDate;
        }

        public override string ToString()
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("fr-FR");

            string toString = String.Format("{0}: {1} {2}. Started on {3} and ", id, GivenName, SurName, StartDate.ToShortDateString());
            
            if (this.Status == Status.Graduated)
            {
                toString += "graduated on " + GraduationDate.ToShortDateString();
            }
            else if (this.Status == Status.Dropout)
            {
                toString += "dropped out on " + EndDate.ToShortDateString();
            }
            else
            {
                toString += "will graduate on " + GraduationDate.ToShortDateString();
            }

            return toString + ".";
        }

    }

    public enum Status{
        New, 
        Active, 
        Dropout, 
        Graduated,
    }
}
