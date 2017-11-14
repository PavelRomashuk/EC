using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EC.Models
{
    public class Document: BaseModel
    {
        public int DocumentId { get; set; }
        public byte[] DocumentContent { get; set; }
    }
}
