using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ServiceStack.ServiceInterface.ServiceModel;
using ServiceStack.ServiceHost;
namespace OpenCBS.API.ServiceModel
{
    [Route("/UserAuthentication/{Username}/{Password}")]
    public class UserAuthenticationRequest
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }

    public class UserAuthenticationResponse
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string FirstName { get;set;}
        public string LastName { get; set; }
        public int RoleId { get; set; }

        public ResponseStatus Status;
    }
}
