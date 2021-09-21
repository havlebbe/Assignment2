using System;
using Xunit;

namespace Assignment2
{
    public class StudentTest
    {
        [Theory]
        [InlineData(1, "Ole", "Moeller", 2019, 02, 02, 2022, 05, 10, 2022, 05, 10, 
                    "1: Ole Moeller. Started on 02/02/2019 and will graduate on 10/05/2022.")]
        [InlineData(2, "Karen", "Blixen", 2020, 01, 01, 2021, 06, 24, 2022, 05, 30, 
                    "2: Karen Blixen. Started on 01/01/2020 and dropped out on 24/06/2021.")]
        [InlineData(3, "Faisal", "Hassan",2021, 08, 16, 2025, 07, 15, 2025, 07, 15, 
                    "3: Faisal Hassan. Started on 16/08/2021 and will graduate on 15/07/2025.")]
        [InlineData(4, "Tamana", "Hansen", 2018, 08, 16, 2021, 07, 15, 2021, 07, 15, 
                    "4: Tamana Hansen. Started on 16/08/2018 and graduated on 15/07/2021.")]
        public void student_information_can_be_made_toString(int id, string firstname, string surname,
                                                             int yearStart, int monthStart, int dayStart, 
                                                             int yearEnd, int monthEnd, int dayEnd,
                                                             int yearGrad, int monthGrad, int dayGrad,
                                                             string printOut)
        {
            DateTime startDate = new DateTime(yearStart, monthStart, dayStart);
            DateTime endDate = new DateTime(yearEnd, monthEnd, dayEnd);
            DateTime gradDate = new DateTime(yearGrad, monthGrad, dayGrad);

            Student student = new Student(id, firstname, surname, startDate, endDate, gradDate);

            Assert.Equal(printOut, student.ToString());
        }

        [Theory]
        [InlineData(2019, 07, 30, 2022, 05, 10)]
        [InlineData(2020, 08, 24, 2023, 06, 24)]
        [InlineData(2020, 08, 16, 2025, 07, 15)]
        public void Student_is_active(int yearStart, int monthStart, int dayStart,
                                      int yearEnd, int monthEnd, int dayEnd)
        {
            DateTime startDate = new DateTime(yearStart, monthStart, dayStart);
            DateTime endDate = new DateTime(yearEnd, monthEnd, dayEnd);
            DateTime gradDate = new DateTime(yearEnd, monthEnd, dayEnd);

            Student student = new Student(42, "John", "Doe", startDate, endDate, gradDate);

            Assert.Equal(Status.Active, student.Status);
        }


        [Theory]
        [InlineData(2019, 01, 01, 2020, 01, 01, 2021, 01, 01)] 
        [InlineData(2019, 01, 01, 2019, 01, 02, 2021, 01, 01)]
        [InlineData(2018, 01, 01, 2021, 06, 01, 2021, 07, 01)]
        [InlineData(2020, 12, 24, 2021, 10, 01, 2023, 01, 01)]
        public void Student_has_dropped_out(int yearStart, int monthStart, int dayStart, 
                                          int yearEnd, int monthEnd, int dayEnd,
                                          int yearGrad, int monthGrad, int dayGrad) 
        {
            DateTime startTime = new DateTime(yearStart, monthStart, dayStart);
            DateTime gradiuationTime = new DateTime(yearGrad, monthGrad, dayGrad);
            DateTime endTime = new DateTime(yearEnd, monthEnd, dayEnd);
            
            Student student = new Student(1, "John", "Doe", startTime, endTime, gradiuationTime);

            Assert.Equal(Status.Dropout, student.Status);
        }

        [Theory]
        [InlineData(2017, 8, 25, 2020, 1, 09)] 
        [InlineData(2010, 8, 29, 2015, 6, 20)]
        [InlineData(1998, 9, 01, 2001, 1, 06)]
        public void Student_has_graduated(int yearStart, int monthStart, int dayStart,
                                          int yearEnd, int monthEnd, int dayEnd) 
        {

            DateTime startDate = new DateTime(yearStart, monthStart, dayStart);
            DateTime endDate = new DateTime(yearEnd, monthEnd, dayEnd);
            DateTime gradDate = new DateTime(yearEnd, monthEnd, dayEnd);
            
            Student student = new Student(1, "John", "Doe", startDate, endDate, gradDate);

            Assert.Equal(Status.Graduated, student.Status);
        }

        [Theory]
        [InlineData(2021, 8, 25, 2024, 1, 09)] 
        [InlineData(2021, 8, 29, 2024, 6, 20)]
        [InlineData(2021, 9, 01, 2024, 1, 06)]
        public void Student_is_new(int yearStart, int monthStart, int dayStart,
                                   int yearEnd, int monthEnd, int dayEnd) 
        {
        
            DateTime startDate = new DateTime(yearStart, monthStart, dayStart);
            DateTime endDate = new DateTime(yearEnd, monthEnd, dayEnd);
            DateTime gradDate = new DateTime(yearEnd, monthEnd, dayEnd);
            
            Student student = new Student(1, "John", "Doe", startDate, endDate, gradDate);

            Assert.Equal(Status.New, student.Status);
        }
    }
}
