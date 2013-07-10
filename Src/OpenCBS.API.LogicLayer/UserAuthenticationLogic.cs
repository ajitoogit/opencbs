using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ServiceStack.ServiceInterface.ServiceModel;
using OpenCBS.API.ServiceModel;
using OpenCBS.API.DAL;
using OpenCBS.API.DataModel;
namespace OpenCBS.API.LogicLayer
{
    public class UserAuthenticationLogic
    {
        // ---- V etom klasse vozmojno razli4nie proverki
        // ---- kasatelno User i avtorizacii

        public static UserAuthenticationResponse GetUser(UserAuthenticationRequest request)
        {
            var user = GetUsers.GetUserByCredentials(request.Username, request.Password);
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

            return ConvertUserToUserAuthenticationResponse(user);

        }

        private static UserAuthenticationResponse ConvertUserToUserAuthenticationResponse(User user)
        {
            UserAuthenticationResponse response = new UserAuthenticationResponse();
            response.Id = user.Id;
            response.Username = user.Username;
            response.Password = user.Password;
            response.FirstName = user.FirstName;
            response.RoleId = user.RoleId;

            return response;
        }
    }
}
