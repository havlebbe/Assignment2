using System;
using Xunit;

namespace Assignment2
{
    public class ImmutableStudentTest
    {
        [Theory]
        [InlineData(1, "Per", "Olsen", 2019, 01, 30, 2022, 05, 10)]
        [InlineData(99, "Hans", "Steffenssen", 2009, 12, 24, 2012, 1, 1)]
        public void Record_equality_comparer_shows_equal(int id, string firstname, string surname, int yearStart, int monthStart, int dayStart, int yearEnd, int monthEnd, int dayEnd)
        {
            ImmutableStudent student1 = new ImmutableStudent(id, firstname, surname, new DateTime(yearStart, monthStart, dayStart), new DateTime(yearEnd, monthEnd, dayEnd), new DateTime(yearEnd, monthEnd, dayEnd));
            ImmutableStudent student2 = new ImmutableStudent(id, firstname, surname, new DateTime(yearStart, monthStart, dayStart), new DateTime(yearEnd, monthEnd, dayEnd), new DateTime(yearEnd, monthEnd, dayEnd));

            Assert.True(student1 == student2);
        }

        [Theory]
        [InlineData(1, "Per", "Olsen", 2019, 01, 30, 2022, 05, 10, 
                    2, "Ole", "Petersen", 2020, 01, 30, 2023, 05, 10)]
        [InlineData(1, "alice", "alice", 2019, 01, 09, 2023, 08, 23, 
                    2, "bob", "bob", 2019, 01, 09, 2023, 08, 23)]
        public void Record_equality_comparer_shows_false(int id1, string givenName1, string surName1, int yearStart1, int monthStart1, int dayStart1, int yearEnd1, int monthEnd1, int dayEnd1, 
                                                         int id2, string givenName2, string surName2, int yearStart2, int monthStart2, int dayStart2, int yearEnd2, int monthEnd2, int dayEnd2)
        {
            DateTime startDate1 = new DateTime(yearStart1, monthStart1, dayStart1);
            DateTime endDate1 = new DateTime(yearEnd1, monthEnd1, dayEnd1);
            DateTime gradDate1 = new DateTime(yearEnd1, monthEnd1, dayEnd1);
            
            DateTime startDate2 = new DateTime(yearStart2, monthStart2, dayStart2);
            DateTime endDate2 = new DateTime(yearEnd2, monthEnd2, dayEnd2);
            DateTime gradDate2 = new DateTime(yearEnd2, monthEnd2, dayEnd2);
            
            ImmutableStudent student1 = new ImmutableStudent(id1, givenName1, surName1, startDate1, endDate1, gradDate1);
            ImmutableStudent student2 = new ImmutableStudent(id2, givenName2, surName2, startDate2, endDate2, gradDate2);

            Assert.False(student1 == student2);
        }

        [Fact]
        public void Record_built_in_to_string() 
        {
            DateTime startDate = new DateTime(2019, 08, 30);
            DateTime endDate = new DateTime(2022, 06, 15);
            DateTime gradDate = new DateTime(2022, 06, 15);
            
            ImmutableStudent alice = new ImmutableStudent(1, "John", "Doe", startDate, endDate, gradDate);
            ImmutableStudent bob = new ImmutableStudent(1, "John", "Doe", startDate, endDate, gradDate);
            
            Assert.True(bob.ToString() == alice.ToString());
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
