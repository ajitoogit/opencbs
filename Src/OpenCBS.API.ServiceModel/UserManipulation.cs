using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ServiceStack.ServiceHost;
using ServiceStack.ServiceInterface.ServiceModel;

namespace OpenCBS.API.ServiceModel
{
    [Route("/userss/includedeleted/{Deleted}")]
    [Route("/users/{Id}")]
    public class UserRequest
    {
        public int Id { get; set; }
        public bool? Deleted { get; set; }
    }

    [Route("/users/update")]
    public class UserUpdateRequest : UserData
    {
    }

    [Route("/users/insert")]
    public class UserInsertRequest : UserData
    {
    }

    [Route("/users/delete/{Id}")]
    public class UserDeleteRequest
    {
        public int Id { get; set; }
    }

    public class UserResponse
    {
        public List<UserData> Users { get; set; }
        public ResponseStatus Status { get; set; }
    }

    public class UserData
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
