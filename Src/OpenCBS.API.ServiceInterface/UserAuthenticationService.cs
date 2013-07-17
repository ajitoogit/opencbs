using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ServiceStack.ServiceInterface;
using ServiceStack.ServiceInterface.Auth;
using OpenCBS.API.ServiceModel;
using OpenCBS.API.LogicLayer;

namespace OpenCBS.API.ServiceInterface
{
    public class UserAuthenticationService : CredentialsAuthProvider
    {
        public UserAuthenticationService()
        {
            this.Provider = "custom";
        }

        public override bool TryAuthenticate(IServiceBase authService, string userName, string password)
        {
            return true;
        }

        public override void OnAuthenticated(IServiceBase authService, IAuthSession session, IOAuthTokens tokens, Dictionary<string, string> authInfo)
        {

        }
        
        public override object Authenticate(IServiceBase authService, IAuthSession session, Auth request)
        {
            //let normal authentication happen
            //var authResponse = (AuthResponse)base.Authenticate(authService, session, request);
            return UserAuthenticationLogic.Authenticate(request, session, authService);
        }
         
    }
}
