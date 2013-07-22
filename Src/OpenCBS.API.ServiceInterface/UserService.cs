using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ServiceStack.ServiceInterface;
using OpenCBS.API.ServiceModel;
using OpenCBS.API.LogicLayer;

namespace OpenCBS.API.ServiceInterface
{
    class UserService: Service
    {
        // --- Get
        public object Get(UserRequest request)
        {

            return UserManipulationLogic.GetUsers(request);
        }

        // --- Insert
        public object Post(UserInsertRequest request)
        {
            return UserManipulationLogic.InsertUser(request);
        }

        // --- Update
        public object Post(UserUpdateRequest request)
        {
            return UserManipulationLogic.UpdateUser(request);
        }

        // --- Delete
        public object Any(UserDeleteRequest request)
        {
            return UserManipulationLogic.DeleteUser(request);
        }

    }
}
