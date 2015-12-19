using ExamSystem.Core.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ExamSystem.Core
{
    public class Exam
    {
        public int ChoiceCount { get; set; }
        public int JudgmentCount { get; set; }
        public List<ChoiceModel> ChoiceList { get; private set; }
        public List<JudgmentModel> JudgmentList { get; private set; }

        public Exam(string fileString)
        {
            Init(fileString);
        }

        private void Init(string fileString)
        {
            XDocument doc = XDocument.Parse(fileString);
            ChoiceList = (from item in doc.Descendants()
                          where item.Name == "Choice"
                          select new ChoiceModel
                          {
                              Title = item.Attribute(XName.Get("Title"))?.Value,
                              Selections = from selection in item.Descendants().Where(node => node.Name == "Selection")
                                           select new SelectionModel
                                           {
                                               Value = selection.Value,
                                               IsAnswer = selection.Attribute(XName.Get("IsAnswer"))?.Value == "true",
                                           }
                          }).ToList();
            ChoiceCount = ChoiceList.Count;
            JudgmentList = (from item in doc.Descendants()
                            where item.Name == "Judgment"
                            select new JudgmentModel
                            {
                                Title = item.Value,
                                IsTrue = item.Attribute(XName.Get("IsTrue"))?.Value == "true",
                            }).ToList();
            JudgmentCount = JudgmentList.Count;
        }

        public ExamModel GetExam()
        {
            if (ChoiceCount > ChoiceList.Count || JudgmentCount > JudgmentList.Count)
            {
                throw new Exception("Please check the ChoiceCount or JudgmentCount");
            }
            return new ExamModel(ChoiceList.OrderBy(a => Guid.NewGuid()).ToList().GetRange(0,ChoiceCount), JudgmentList.OrderBy(a => Guid.NewGuid()).ToList().GetRange(0,JudgmentCount));
        }
    }
}
