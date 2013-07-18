using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ServiceStack.ServiceInterface;
using OpenCBS.API.ServiceModel;
using OpenCBS.API.LogicLayer;

namespace OpenCBS.API.ServiceInterface
{
    class RoleService: Service
    {
        public object Any(RoleRequest request)
        {

            return RoleManipulationLogic.GetRoles(request);
        }
    }
}
