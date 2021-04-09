using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultipleChoiceTestMaker
{
    interface IStudent
    {
        string[] TestsTaken { get; set; }
        void TakeTest(TestPaper testpaper, string[] answers);
    }
}
