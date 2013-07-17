using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ServiceStack.ServiceInterface;
using ServiceStack.ServiceInterface.ServiceModel;
using ServiceStack.ServiceInterface.Auth;
using OpenCBS.API.ServiceModel;
using OpenCBS.API.DAL;
using OpenCBS.API.DataModel;
namespace OpenCBS.API.LogicLayer
{
    public class UserAuthenticationLogic
    {
        public static UserAuthenticationResponse Authenticate(Auth request, IAuthSession session, IServiceBase authService)
        {
            var user = GetUsers.GetUserByCredentials(request.UserName, request.Password);
            // --- Check for errors
            if (user == null)
            {
                return new UserAuthenticationResponse
                {
                    Status = new ResponseStatus
                    {
                        ErrorCode = "AuthError",
                        Message = "User does not exist"
                    }
                };
            }//if

            bool isSessionSaved = SaveSession(user, session, authService);

            if(isSessionSaved)
            return ConvertUserToUserAuthenticationResponse(user);

            return new UserAuthenticationResponse
            {
                Status = new ResponseStatus
                {
                    ErrorCode = "AuthSessionError",
                    Message = "Session processing error!"
                }
            };
        }

        private static bool SaveSession(User user, IAuthSession session, IServiceBase authService)
        {
            try
            {
                session.FirstName = user.FirstName;
                session.UserAuthId = user.Id.ToString();
                session.UserName = user.Username;
                session.Permissions = GetUsers.GetPermissionsByRoleId(user.RoleId);
                session.Roles = new List<string> {user.RoleId.ToString()};
                session.IsAuthenticated = true;

                authService.SaveSession(session, null);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        private static UserAuthenticationResponse ConvertUserToUserAuthenticationResponse(User user)
        {
            var response = new UserAuthenticationResponse
                {
                    Id = user.Id,
                    Username = user.Username,
                    Password = user.Password,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    RoleId = user.RoleId
                };

            return response;
        }
    }
}
