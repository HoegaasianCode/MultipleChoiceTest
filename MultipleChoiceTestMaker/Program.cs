using System;

namespace MultipleChoiceTestMaker
{
    class Program
    {
        // https://edabit.com/challenge/thXMEAWNWyk9cCZcM
        // Solved - although this assignment could do with tests

        static void Main(string[] args)
        {
            Student student = new();
            TestPaper paper = new("Chemistry", new string[] { "1C", "2C", "3D", "4A" }, "75%");
            TestPaper paper1 = new("Algebra", new string[] { "1D", "2C", "3C", "4B", "5D", "6C", "7A" }, "75%");
            student.TakeTest(paper, new string[] { "1C", "2D", "3A", "4C" });
            student.TakeTest(paper1, new string[] { "1A", "2C", "3A", "4C", "5D", "6C", "7B" });
            student.ListToSortedArray();
            string[] results = student.TestsTaken;
            foreach (string result in results) Console.WriteLine(result);
        }
    }
}
