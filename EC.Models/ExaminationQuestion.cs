using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EC.Models
{
    public class ExaminationQuestion: BaseModel
    {
        public int ExaminationQuestionId { get; set; }
        public int ExaminationId { get; set; }
        public string ExaminationQuestionText { get; set; }
        public string Note { get; set; }
        public virtual Examination Examination { get; set; }
        public virtual List<ExaminationAnswer> ExaminationAnswers { get; set; }
    }
}
