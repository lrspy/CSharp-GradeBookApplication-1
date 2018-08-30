using GradeBook.Enums;
using System;


namespace GradeBook.GradeBooks
{
    public class RankedGradeBook: BaseGradeBook
    {
        public RankedGradeBook(string name): base(name)
        {
            Type = GradeBookType.Ranked;
        }
        public override char GetLetterGrade(double averageGrade)
        {
            if (this.Students.Count < 5)
                throw new System.InvalidOperationException("Not enought Student");
            else
            {
                var listOfAverages = this.Students.AverageGrades.ToArray();
                var rankedPercentile = Percentile(listOfAverages, averageGrade);

                if (rankedPercentile <= .20)
                    return 'A';
                else if (rankedPercentile <= .40)
                    return 'B';
                else if (rankedPercentile <= .60)
                    return 'C';
                else if (rankedPercentile <= .80)
                    return 'D';
                else
                    return 'F';
            }

            
        }
        public double Percentile(double[] sequence, double averageGrade)
        {
            Array.Sort(sequence);
            int N = sequence.Length;
            int indexOf = Array.IndexOf(sequence, averageGrade);

            return (indexOf+1)/N; 
        }
   
    }
}
