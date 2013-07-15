using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ServiceStack.Common.Extensions;
using ServiceStack.OrmLite;
using ServiceStack.ServiceInterface;
using ServiceStack.ServiceInterface.Auth;
using ServiceStack.ServiceHost;
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
            //Add here your custom auth logic (database calls etc)
            //Return true if credentials are valid, otherwise false
            return true;
        }

        public override void OnAuthenticated(IServiceBase authService, IAuthSession session, IOAuthTokens tokens, Dictionary<string, string> authInfo)
        {
            /*
            //Fill the IAuthSession with data which you want to retrieve in the app eg:
            session.FirstName = "some_firstname_from_db";
            session.UserName = "admin";
            session.Permissions = new List<string>();
            session.Permissions.Add("UserService");
            session.Permissions.Add("CustomerService");
            //...

            //Important: You need to save the session!
            authService.SaveSession(session, SessionExpiry);
             * */
        }

        
        public override object Authenticate(IServiceBase authService, IAuthSession session, Auth request)
        {
            //let normal authentication happen
            var authResponse = (AuthResponse)base.Authenticate(authService, session, request);
            //Fill the IAuthSession with data which you want to retrieve in the app eg:
            session.FirstName = "some_firstname_from_db";
            session.UserAuthId = "1";
            session.UserName = request.UserName;
            string password = request.Password;
            session.Permissions = new List<string>();
            if(request.UserName == "jsonName")
            session.Permissions.Add("TestService");

            if(request.UserName == "xmlName")
            session.Permissions.Add("CustomerService");
            session.Roles = new List<string>();
            session.Roles.Add("admin");
            session.IsAuthenticated = true;
            
            
            //...
            
            //Important: You need to save the session!
            authService.SaveSession(session, null);
            
            return new UserAuthenticationResponse() { Username = session.UserName, SessionId = session.Id, LastName = "OK" };
        }
        
        /*
        public object Any(UserAuthenticationRequest request)
        {
            return UserAuthenticationLogic.GetUser(request);
        
        }
         */
         
    }
}
