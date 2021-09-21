using System;
using Xunit;

namespace Assignment2
{
    public class ImmutableStudentTest
    {
        [Fact]
        public void Test1()
        {

        }

        [Theory]
        [InlineData(2019, 07, 30, 2022, 05, 10)]
        [InlineData(2020, 08, 24, 2023, 06, 24)]
        [InlineData(2020, 08, 16, 2025, 07, 15)]
        public void Immutable_Student_is_active(int yearStart, int monthStart, int dayStart,
                                      int yearEnd, int monthEnd, int dayEnd)
        {
            DateTime startDate = new DateTime(yearStart, monthStart, dayStart);
            DateTime endDate = new DateTime(yearEnd, monthEnd, dayEnd);
            DateTime gradDate = new DateTime(yearEnd, monthEnd, dayEnd);

            ImmutableStudent student = new ImmutableStudent(42, "John", "Doe", startDate, endDate, gradDate);

            Assert.Equal(Status.Active, student.Status);
        }

        [Theory]
        [InlineData(2019, 01, 01, 2020, 01, 01, 2021, 01, 01)] 
        [InlineData(2019, 01, 01, 2019, 01, 02, 2021, 01, 01)]
        [InlineData(2018, 01, 01, 2021, 06, 01, 2021, 07, 01)]
        [InlineData(2020, 12, 24, 2021, 10, 01, 2023, 01, 01)]
        public void ImmutableStudent_has_dropped_out(int yearStart, int monthStart, int dayStart, 
                                          int yearEnd, int monthEnd, int dayEnd,
                                          int yearGrad, int monthGrad, int dayGrad) 
        {
            DateTime startTime = new DateTime(yearStart, monthStart, dayStart);
            DateTime gradiuationTime = new DateTime(yearGrad, monthGrad, dayGrad);
            DateTime endTime = new DateTime(yearEnd, monthEnd, dayEnd);
            
            ImmutableStudent student = new ImmutableStudent(1, "John", "Doe", startTime, endTime, gradiuationTime);

            Assert.Equal(Status.Dropout, student.Status);
        }

        [Theory]
        [InlineData(2017, 8, 25, 2020, 1, 09)] 
        [InlineData(2010, 8, 29, 2015, 6, 20)]
        [InlineData(1998, 9, 01, 2001, 1, 06)]
        public void immutableStudent_has_graduated(int yearStart, int monthStart, int dayStart,
                                          int yearEnd, int monthEnd, int dayEnd) 
        {

            DateTime startDate = new DateTime(yearStart, monthStart, dayStart);
            DateTime endDate = new DateTime(yearEnd, monthEnd, dayEnd);
            DateTime gradDate = new DateTime(yearEnd, monthEnd, dayEnd);
            
            ImmutableStudent student = new ImmutableStudent(1, "John", "Doe", startDate, endDate, gradDate);

            Assert.Equal(Status.Graduated, student.Status);
        }

        [Theory]
        [InlineData(2021, 8, 25, 2024, 1, 09)] 
        [InlineData(2021, 8, 29, 2024, 6, 20)]
        [InlineData(2021, 9, 01, 2024, 1, 06)]
        public void ImmutableStudent_is_new(int yearStart, int monthStart, int dayStart,
                                   int yearEnd, int monthEnd, int dayEnd) 
        {
        
            DateTime startDate = new DateTime(yearStart, monthStart, dayStart);
            DateTime endDate = new DateTime(yearEnd, monthEnd, dayEnd);
            DateTime gradDate = new DateTime(yearEnd, monthEnd, dayEnd);
            
            ImmutableStudent student = new ImmutableStudent(1, "John", "Doe", startDate, endDate, gradDate);

            Assert.Equal(Status.New, student.Status);
        }

    }
}
