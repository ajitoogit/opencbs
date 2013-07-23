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
        // --- Get
        public object Get(RoleRequest request)
        {

            return RoleManipulationLogic.GetRoles(request);
        }

        // --- Insert
        public object Post(RoleInsertRequest request)
        {
            return RoleManipulationLogic.InsertRole(request);
        }

        // --- Update
        public object Post(RoleUpdateRequest request)
        {
            return RoleManipulationLogic.UpdateRole(request);
        }

        // --- Delete
        public object Any(RoleDeleteRequest request)
        {
            return RoleManipulationLogic.DeleteRole(request);
        }

    }
}
