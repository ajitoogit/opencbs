using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenCBS.API.DataModel
{
    public class Role
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public bool Deleted { get; set; }
        public string Description { get; set; }
        public bool IsRoleOfLoan { get; set; }
        public bool IsRoleOfSaving { get; set; }
        public bool IsRoleOfTeller { get; set; }
    }
}
