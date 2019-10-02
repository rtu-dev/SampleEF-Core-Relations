using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleEF_Core_Relations.Entity
{
    public class GroupSub
    {
        public GroupSub()
        {
            Group = new Group();
            SubGroup = new SubGroup();
        }
        //public int GroupSubId { get; set; }
        public int GroupId { get; set; }
        public Group Group { get; set; }
        public int SubGroupId { get; set; }
        public SubGroup SubGroup { get; set; }
    }
}
