using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EC.Models
{
    public class ScheduledTask : BaseModel
    {
        public int ScheduledTaskId { get; set; }
        public int UserId { get; set; }
        public int TaskId { get; set; }
        public string Note { get; set; }
        public bool IsCompleted { get; set; }
        public virtual List<Task> Tasks { get; set; }
    }
}
