using System;
using Xunit; 

namespace GradeBook.Tests
{
    public class BookTests
    {
        [Fact]
        public void Test1()
        {
            //Arange
            var book = new InMemoryBook("");
            book.AddGrade(85.1);
            book.AddGrade(90.4);
            book.AddGrade(77.9);
          

            //Action
            var stats = book.GetStatistics();

            //Assert
            Assert.Equal(84.5, stats.Average, 1);
            Assert.Equal(90.4, stats.High, 1);
            Assert.Equal(77.9, stats.Low, 1);
        }
    }
}
