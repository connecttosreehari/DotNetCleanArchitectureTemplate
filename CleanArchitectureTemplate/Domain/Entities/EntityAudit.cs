using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class EntityAudit
    {
        public DateTimeOffset CreatedAt { get; set; }
        public int CreatedBy { get; set; }
        public DateTimeOffset UpdatedAt { get; set; }
        public int UpdatedBy { get; set; }
    }
}
