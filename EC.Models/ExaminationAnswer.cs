using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EC.Models
{
    public class ExaminationAnswer : BaseModel
    {
        public int ExaminationAnswerId { get; set; }
        public int ExaminationId { get; set; }
        public int ExaminationQuestionId { get; set; }
        public string Answer { get; set; }
        public bool IsCorrect { get; set; }
        public virtual Examination Examination { get; set; }
        public virtual ExaminationQuestion ExaminationQuestion { get; set; }
    }
}
