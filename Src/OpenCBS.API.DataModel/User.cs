using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenCBS.API.DataModel
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Mail { get; set; }
        public string Sex { get; set; }
        public string Phone { get; set; }
        public bool Deleted { get; set; }
        public int ContactCount { get; set; }
        public int RoleId { get; set; }
    }
}
