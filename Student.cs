using System;

namespace Assignment2
{
    public class Student
    {
        public int id { get; }
        string GivenName;
        string SurName;
        public readonly Status Status;
        DateTime StartDate;
        DateTime EndDate;
        DateTime GraduationDate;

        public Student(int id, string GivenName, string SurName, DateTime StartDate, DateTime EndDate, DateTime GraduationDate) 
        {
            this.id = id; 
            this.GivenName = GivenName;
            this.SurName = SurName;
            this.StartDate = StartDate;
            this.EndDate = EndDate;
            this.GraduationDate = GraduationDate;

            if (DateTime.MinValue.CompareTo(EndDate) == 0 && DateTime.MinValue.CompareTo(EndDate) == 0) 
            {
                //check if new or active
            }

            if (DateTime.Now.CompareTo(GraduationDate) > 0) 
            {
                Status = Status.Graduated;
            } else if (DateTime.Now.CompareTo(EndDate) > 0 && DateTime.MinValue.CompareTo(EndDate) != 0) 
            {

            }

        }

        public override string ToString()
        {
            return "";
        }

    }

    public enum Status{
        New, 
        Active, 
        Dropout, 
        Graduated,
    }
}
