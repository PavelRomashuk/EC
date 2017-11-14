using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EC.Models
{
    public class Task : BaseModel
    {
        public int TaskId { get; set; }
        public string TaskName { get; set; }
        public string Note { get; set; }
        public virtual ScheduledTask ScheduledTask { get; set; }
    }
}
