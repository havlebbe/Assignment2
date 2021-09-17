using System;
using Xunit;

namespace Assignment2
{
    public class StudentTest
    {
        [Fact]
        public void Student_who_started_in_2020_is_Enrolled()
        {
            var student = new Student(1, "John", "Doe", new DateTime(2020, 9, 25), 
                                    new DateTime(2023, 7, 25), new DateTime()); 
            
            Assert.Equal(Status.Active, student.Status);
        }

        [Theory]
        [InlineData(2020, 8, 25, 0001, 1, 1, 0001, 1, 1, Status.Active)] 
        [InlineData(2010, 8, 29, 2015, 6, 20, 2015, 6, 20, Status.Graduated)]
        [InlineData(2010, 8, 29, 2015, 6, 20, 0001, 1, 1, Status.Dropout)]
        [InlineData(2021, 9, 01, 0001, 1, 1, 0001, 1, 1, Status.New)]
        public void Student_status(int yearStart, int monthStart, int dayStart, 
                                    int yearEnd, int monthEnd, int dayEnd,  
                                    int yearGrad, int monthGrad, int dayGrad, Status status) 
        {
            var student = new Student(1, "John", "Doe", new DateTime(yearStart, monthStart, dayStart), 
                                new DateTime(yearEnd, monthEnd, dayEnd), new DateTime(yearGrad, monthGrad, dayGrad));

            Assert.Equal(status, student.Status);
        }
    }
}
