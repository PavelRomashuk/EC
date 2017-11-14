using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EC.Models
{
    public class Examination: BaseModel
    {
        public int ExaminationId { get; set; }
        public int ExaminationName { get; set; }
        public virtual List<ExaminationQuestion> ExaminationQuestions { get; set; }
        public virtual List<ExaminationAnswer> ExaminationAnswers { get; set; }
    }
}
