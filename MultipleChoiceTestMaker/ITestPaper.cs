using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultipleChoiceTestMaker
{
    public interface ITestPaper
    {
        string Subject { get; }
        string[] MarkScheme { get; }
        string PassMark { get; }
    }
}
