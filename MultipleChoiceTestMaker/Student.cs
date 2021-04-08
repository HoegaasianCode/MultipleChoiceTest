using System;
using System.Collections.Generic;
using System.Text;

namespace MultipleChoiceTestMaker
{
    public class Student : IStudent
    {
        public string[] TestsTaken { get; set; }
        private TestPaper _testPaper;
        private string[] _answers;
        private readonly List<string> ResultList;

        public Student()
        {
            TestsTaken = new string[] { "No", " ", "Tests", " ", "Taken" };
            ResultList = new();
        }

        public void TakeTest(TestPaper paper, string[] answers)
        {
            _testPaper = paper;
            _answers = answers;
            CalcPercentage();
        }

        private void CalcPercentage()
        {
            int j = 0;
            for(int i = 0; i < _answers.Length; i++)
            {
                string answer = _answers[i];
                string correctAnwer = _testPaper.MarkScheme[i];
                if (answer == correctAnwer) j++;
            }
            double percentage = Math.Round((double)j / _testPaper.MarkScheme.Length * 100, 0);
            BuildString(percentage);
        }

        private void BuildString(double percentage)
        {
            string result;
            string passedText = "Not Passed!";
            string percentText = percentage.ToString() + '%';
            int passMark = Convert.ToInt32(_testPaper.PassMark.Remove(_testPaper.PassMark.Length - 1));
            if (percentage > passMark) passedText = "Passed!";
            result = _testPaper.Subject + ':' + ' ' + passedText + ' ' + percentText;
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
