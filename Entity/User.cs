using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleEF_Core_Relations.Entity
{
    public class User
    {        
        public int UserId { get; set; }
        public string Name { get; set; }

        public ICollection<GroupUser> GroupUsers { get; set; }
    }
}
