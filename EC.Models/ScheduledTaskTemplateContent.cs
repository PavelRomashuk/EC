using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EC.Models
{
    public class ScheduledTaskTemplateContent: BaseModel
    {
        public int ScheduledTaskTemplateContentId { get; set; }
        public int ScheduledTaskId { get; set; }
        public string  Note { get; set; }
        public virtual ScheduledTaskTemplate ScheduledTaskTemplate { get; set; }
    }
}
