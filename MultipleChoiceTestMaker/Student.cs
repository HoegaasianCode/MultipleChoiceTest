using System;
using System.Collections.Generic;
using System.Text;

namespace MultipleChoiceTestMaker
{
    public class Student : IStudent
    {
        public string[] TestsTaken { get; set; }
        private readonly List<string> ResultList;

        public Student()
        {
            TestsTaken = new string[] { "No", " ", "Tests", " ", "Taken" };
            ResultList = new();
        }

        public void TakeTest(TestPaper paper, string[] answers)
        {
            CalcPercentage(paper, answers);
        }

        private void CalcPercentage(TestPaper testPaper, string[] answers)
        {
            int j = 0;
            for(int i = 0; i < answers.Length; i++)
            {
                string answer = answers[i];
                string correctAnwer = testPaper.MarkScheme[i];
                if (answer == correctAnwer) j++;
            }
            double percentage = Math.Round((double)j / testPaper.MarkScheme.Length * 100, 0);
            BuildString(percentage, testPaper);
        }

        private void BuildString(double percentage, TestPaper testPaper)
        {
            string result;
            string passedText = "Not Passed!";
            string percentText = percentage.ToString() + '%';
            int passMark = Convert.ToInt32(testPaper.PassMark.Remove(testPaper.PassMark.Length - 1));
            if (percentage > passMark) passedText = "Passed!";
            result = testPaper.Subject + ':' + ' ' + passedText + ' ' + percentText;
            ResultList.Add(result);
        }

        public void ListToSortedArray()
        {
            string[] stringArray = ResultList.ToArray();
            Array.Sort(stringArray);
            TestsTaken = stringArray;
        }
    }
}
