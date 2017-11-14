using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EC.Models
{
    public class Theory: BaseModel
    {
        public int TheoryId { get; set; }
        public string Caption { get; set; }
        public string Content { get; set; }
    }
}
