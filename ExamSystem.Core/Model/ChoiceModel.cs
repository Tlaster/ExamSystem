using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamSystem.Core.Model
{
    public class ChoiceModel
    {
        public IEnumerable<SelectionModel> Selections { get; internal set; }
        public string Title { get; internal set; }
    }
}
