using ExamSystem.Core;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            Exam exam = new Exam(File.ReadAllText($"{AppDomain.CurrentDomain.BaseDirectory}ExamFile.xml"));
            var e = exam.GetExam();
        }
    }
}
