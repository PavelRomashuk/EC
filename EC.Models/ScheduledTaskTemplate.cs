using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EC.Models
{
    public class ScheduledTaskTemplate: BaseModel
    {
        public int ScheduledTaskTemplateId { get; set; }
        public string Name { get; set; }
        public string Note { get; set; }
        public virtual List<ScheduledTaskTemplateContent> ScheduledTaskTemplateContents { get; set; }
    }
}
