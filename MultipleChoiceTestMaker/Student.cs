using System;
using System.Collections.Generic;
using System.Text;

namespace MultipleChoiceTestMaker
{
    public class Student : IStudent
    {
        public string[] TestsTaken { get; set; }
        private ITestPaper ITestPaper;
        private string[] Answers;
        private List<ITestPaper> TestPapers = new();
        private ITestPaper[] PaperArray;
        private string[] PaperArray1;


        private ITestPaper LastCase;
        private double CorrectAnswers;
        private double Percentage;
        private List<string> ResultList;


        public void TakeTest(ITestPaper paper, string[] answers)
        {
            ITestPaper = paper;
            Answers = answers;
            TestPapers.Add(ITestPaper);
        }

        public void PaperListToArray()
        {
            PaperArray = TestPapers.ToArray();
        }

        public void ShiftSubjectArray()
        { 
            List<string> stringBoi = new();
            ITestPaper[] testPaperArray1 = PaperArray;
            for (int i = 1; i < testPaperArray1.Length; i++)
            {
                ITestPaper s = testPaperArray1[i];
                stringBoi.Add(s.Subject);
            }
            string offsetLength = "å";
            stringBoi.Add(offsetLength);
            PaperArray1 = stringBoi.ToArray();
        }

        public void IsOddLengthSubjectArray()
        {
            if (PaperArray.Length % 2 != 0)
            {
                Array.Reverse(PaperArray);
                ITestPaper lastPaper = PaperArray[0];

                TestPapers.RemoveAt(0);
                Array.Reverse(PaperArray);
            }

        }

        // For odd-length subject-arrays: last case stowed away due to pairwise
        // iteration in SortSubjectStrings().

        public void SortSubjectStrings()
        {
            for (int i = 0; i < PaperArray.Length; i += 2)
            {
                ITestPaper result1 = PaperArray[i];
                string one = result1.Subject;
                string result2 = PaperArray1[i];

                if (one[0] < result2[0])
                {
                    result2.Add(result1);
                    continue;
                }
                if (one[0] > result2[0])
                {
                    result2.Add(result2);
                    continue;
                }
                if (one[0] == result2[0]) SortWithinSubjectString(one, result2);
            }
        }

        private void SortWithinSubjectString(string s1, string s2) // "Cabc, Cabc, Cabd" .... 
        {
            for (int i = 0; i < s1.Length; i++)
            {
                char char1 = s1[i];
                char char2 = s2[i];
                if (char1 == char2) continue;
                if (char1 < char2)
                {
                    StringList2.Add(s1);
                    continue;
                }
                if (char1 < char2)
                {
                    StringList2.Add(s1);
                    continue;
                }
            }
        }

        public void CompareLastValueToHighest()
        {

        }

        public void CountCorrectAnswers()
        {
            int j = 0;
            for(int i = 0; i < Answers.Length; i++)
            {
                //string answer = TestPapers[i];
                //string correctAnswer = MarkScheme[i];
                //if(answer == correctAnswer) j++;
                //else continue;
            }
            CorrectAnswers = j;
        }

        public void CalcPercentage()
        {
            //Percentage = Math.Round(CorrectAnswers / MarkScheme.Length * 100, 0);
        }


        public void BuildString()
        {
            string s;
            string passedText = "Not Passed!";
            string percentText = Percentage.ToString() + '%';
            int passMark = Convert.ToInt32(PassMark.Remove(PassMark.Length - 1));
            if (Percentage > passMark) passedText = "Passed!";
            if (Answers == null) s = "No tests taken";
            else s = ITestPaper.Subject + ':' + ' ' + passedText + ' ' + percentText;
            ResultList.Add(s);
        }


    }
}
