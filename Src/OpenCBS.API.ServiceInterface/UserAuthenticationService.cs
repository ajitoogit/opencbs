using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ServiceStack.Common.Extensions;
using ServiceStack.OrmLite;
using ServiceStack.ServiceHost;
using OpenCBS.API.ServiceModel;
using OpenCBS.API.LogicLayer;

namespace OpenCBS.API.ServiceInterface
{
    public class UserAuthenticationService : IService
    {
        public object Any(UserAuthenticationRequest request)
        {
            return UserAuthenticationLogic.GetUser(request);
        
        }
    }
}
