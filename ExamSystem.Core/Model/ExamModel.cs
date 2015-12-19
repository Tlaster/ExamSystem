using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamSystem.Core.Model
{
    public class ExamModel
    {
        public ExamModel(List<ChoiceModel> choiceList, List<JudgmentModel> judgmentList)
        {
            ChoiceList = choiceList;
            JudgmentList = judgmentList;
        }
        public List<ChoiceModel> ChoiceList { get; internal set; }
        public List<JudgmentModel> JudgmentList { get; internal set; }
    }
}
