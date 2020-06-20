using System;

namespace GradeBook
{
    public class Statistics
    {
        public double Average
        {
            get
            {
                return sum / count;
            }
        }
        public double High;
        public double Low;
        public char Letter
        {
            get
            {
                switch (Average)
                {
                    case var d when d >= 90:
                        return 'A';
                     case var d when d >= 80:
                        return 'B';
                    case var d when d >= 70:
                        return 'C';
                    case var d when d >= 60:
                        return 'D';
                    default:
                        return 'F';
                }
            }     
        }
        public double sum;
        public int count;

        public Statistics()
        {
            sum = 0.0;
            count = 0;
            High = double.MinValue;
            Low = double.MaxValue;
        }
        public void Add(double num)
        {
            sum += num;
            count += 1;
            High = Math.Max(num, High);
            Low = Math.Min(num, Low);
        }

        
    }
}