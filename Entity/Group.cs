using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleEF_Core_Relations.Entity
{
    public class Group
    {
        public Group()
        {
            GroupSubs = new List<GroupSub>();
            GroupUsers = new List<GroupUser>();
        }

        public int GroupId { get; set; }
        public string Name { get; set; }

        public ICollection<GroupSub> GroupSubs { get; set; }
        public ICollection<GroupUser> GroupUsers { get; set; }
    }
}
