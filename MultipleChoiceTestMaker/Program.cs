using System;

namespace MultipleChoiceTestMaker
{
    class Program
    {
        /// <summary>
        /// https://edabit.com/challenge/thXMEAWNWyk9cCZcM
        /// JUST STARTED ;)
        /// </summary>

        static void Main(string[] args) //  "Maths: Passed! (80%)" 
        {
            TestPaper paper1 = new("Maths", new string[] { "1A", "2C", "3D", "4A", "5A" }, "60%");
            TestPaper paper2 = new("Chemistry", new string[] { "1C", "2C", "3D", "4A" }, "75%");
            TestPaper paper3 = new("Computing", new string[] { "1D", "2C", "3C", "4B", "5D", "6C", "7A" }, "75%");
            Student student1 = new();
            Student student2 = new();
            student1.TakeTest(paper1, new string[] { "1A", "2D", "3D", "4A", "5A" });
            student1.CountCorrectAnswers();
            student1.CalcPercentage();

        }
    }
}
