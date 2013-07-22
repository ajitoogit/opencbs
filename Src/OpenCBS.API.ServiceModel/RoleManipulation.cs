using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ServiceStack.ServiceHost;
using ServiceStack.ServiceInterface.ServiceModel;

namespace OpenCBS.API.ServiceModel
{
    [Route("/roles/includedeleted/{Deleted}")]
    [Route("/roles/{Id}")]
    public class RoleRequest
    {
        public int Id { get; set; }
        public bool? Deleted { get; set; }
    }

    [Route("/roles/update")]
    public class RoleUpdateRequest : RoleData
    {
    }

    [Route("/roles/insert")]
    public class RoleInsertRequest : RoleData
    {
    }

    [Route("/roles/delete/{Id}")]
    public class RoleDeleteRequest
    {
        public int Id { get; set; }
    }

    public class RoleResponse
    {
        public List<RoleData> Roles { get; set; }
        public ResponseStatus Status { get; set; }
    }

    public class RoleData
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
