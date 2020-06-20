using System;
using System.Collections.Generic;

namespace GradeBook
{
    public delegate void GradeAddedDelegate(object sender, EventArgs args);
    public class InMemoryBook : Book
    {
        public InMemoryBook(string name) : base(name)
        {   
            grades = new List<double>();
        }
        public void AddGrade(char letter)
        {
            switch(letter)
            {
                case 'A':
                    AddGrade(90);
                    break;
                case 'B':
                    AddGrade(80);
                    break;
                case 'C':
                    AddGrade(70);
                    break;
                case 'D':
                    AddGrade(60);
                    break;
                case 'F':
                    AddGrade(50);
                    break;
                default:
                    throw new ArgumentException($"Invalid {nameof(letter)}");
            
            };
        }
        public override void AddGrade(double grade)
        {
            if (grade >= 0 && grade <= 100)
            {
                grades.Add(grade);
                if (GradeAdded != null)
                {
                    GradeAdded(this, new EventArgs());
                }
            }
            else 
            {
                Console.WriteLine($"Invalid {nameof(grade)}");
            }
            
        }
        public override Statistics GetStatistics()
        {
            var result = new Statistics();

            foreach(var grade in grades)
            {
                result.Add(grade);
                
            }

            return result;
        }
 
        public List<double> grades;
        public override event GradeAddedDelegate GradeAdded;
        
    }
}