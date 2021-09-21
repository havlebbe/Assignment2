using System;

namespace Assignment2
{
    public record ImmutableStudent
    {
        public int id { get; init; }
        public string GivenName { get; init; }
        public string SurName { get; init; }
        public DateTime StartDate { get; init; }
        public DateTime EndDate { get; init; }
        public DateTime GraduationDate { get; init; }
        public Status Status
        {
            get
            {
                if (!EndDate.Equals(GraduationDate))
                {
                    return Status.Dropout;
                }
                else if (DateTime.Now.CompareTo(GraduationDate) > 0)
                {
                    return Status.Graduated;
                }
                else if (DateTime.Now.CompareTo(StartDate.AddDays((double) 365 / 2)) < 0)
                {
                    return Status.New;
                }
                else
                {
                    return Status.Active;
                }
            }
        }

        public ImmutableStudent(int id, string GivenName, string SurName, DateTime StartDate, DateTime EndDate, DateTime GraduationDate) 
        {
            this.id = id;
            this.GivenName = GivenName;
            this.SurName = SurName;
            this.StartDate = StartDate;
            this.EndDate = EndDate;
            this.GraduationDate = GraduationDate;
        }
    }
}
