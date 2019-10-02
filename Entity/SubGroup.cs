using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleEF_Core_Relations.Entity
{
    public class SubGroup
    {
        public int SubGroupId { get; set; }
        public string Name { get; set; }

        public ICollection<GroupSub> GroupSubs { get; set; }
    }
}
