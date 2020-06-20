using System;

namespace GradeBook
{
   
    class Program
    {
        static void Main(string[] args)
        {
            IBook book = new InMemoryBook("Jeonghwe");
            book.GradeAdded += whenGradeAdded;

            EnterGrades(book);

            var stats = book.GetStatistics();
            Console.WriteLine($"The avg. is {stats.Average}.");
            Console.WriteLine($"The max is {stats.High}.");
            Console.WriteLine($"The min is {stats.Low}.");
            Console.WriteLine($"The letter is {stats.Letter}.");
        }

        private static void EnterGrades(IBook book)
        {
            while (true)
            {
                Console.WriteLine("Type the grade or 'q' to quit.");
                var input = Console.ReadLine();
                if (input == "q")
                {
                    break;
                }
                try
                {
                    var grade = double.Parse(input);
                    book.AddGrade(grade);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }

            };
        }

        static void whenGradeAdded(object sender, EventArgs e)
        {
            Console.WriteLine($"A grade was added.");
        }
    }
}
