using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class TodoTask : BaseEntity<int>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Status { get; set; }
        public DateTime LastModifiedAt { get; set; }
    }
}
