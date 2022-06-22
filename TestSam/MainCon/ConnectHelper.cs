using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestSam.MainCon
{
    public partial class Student
    {
        public string Evaluation 
        { 
            get
            { 
                var titles = string.Join(",", PerformanceJournal.Select(pj=> pj.Estimation).ToList());
                if (titles.Length == 0)
                {
                    return "Нет оценок";
                }
                else
                {
                    return titles;
                }
            }
        }
    }
}
