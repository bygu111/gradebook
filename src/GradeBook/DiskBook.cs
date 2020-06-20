using System;
using System.IO;

namespace GradeBook
{
    internal class DiskBook : Book
    {
        public DiskBook(string name) : base(name)
        {
        }
        public override void AddGrade(double grade)
        {
            if (grade >= 0 && grade <= 100)
            {
                using (var writer = File.AppendText($"{Name}.txt"))
                {
                    writer.WriteLine(grade);
                    if (GradeAdded != null)
                    {
                        GradeAdded(this, new EventArgs());
                    }
                }
            }
            else 
            {
                Console.WriteLine($"Invalid {nameof(grade)}");
            }
        }
        public override Statistics GetStatistics()
        {
            var result =  new Statistics();
            using (var reader = File.OpenText($"{Name}.txt"))
            {
                var line =reader.ReadLine();
                while (line != null)
                {
                    result.Add(double.Parse(line));
                    line = reader.ReadLine();
                }
            }
            return result;

        }

        public override event GradeAddedDelegate GradeAdded;
    }
}