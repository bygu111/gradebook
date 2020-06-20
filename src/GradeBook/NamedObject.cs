namespace GradeBook
{
    public interface IBook
    {
        void AddGrade(double grade);
        Statistics GetStatistics();
        string Name { get; }
        event GradeAddedDelegate GradeAdded;


    }
    public class NamedObject
    {
        public NamedObject(string name)
        {
            Name = name;
        }

        public virtual string Name
        {
            get;
            set;
        }
    }

    public abstract class Book : NamedObject, IBook
    {
        public Book(string name) : base(name)
        {
        }
        public abstract void AddGrade(double grade);
        public abstract Statistics GetStatistics();
        public abstract event GradeAddedDelegate GradeAdded;
    }

}