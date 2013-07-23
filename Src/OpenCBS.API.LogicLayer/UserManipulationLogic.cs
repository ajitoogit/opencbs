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
    public class UserManipulationLogic
    {
        public static UserResponse GetUsers(UserRequest request)
        {
            try
            {
                var roles = request.Id > 0
                                ? new List<User>() {UserManager.GetUserById(request.Id)}
                                : (request.Deleted.HasValue
                                       ? UserManager.GetUsers((bool) request.Deleted)
                                       : null);
                return ConvertUserListToUserResponse(roles);
            }
            catch (Exception ex)
            {
                return new UserResponse
                {
                    Status = new ResponseStatus
                    {
                        ErrorCode = "GetUsersError",
                        Message = "Get users processing error!"
                    }
                };
                
            }

        }

        public static UserResponse InsertUser(UserInsertRequest request)
        {
            try
            {
                var user = ConvertUserDataToUser(request);
                var newUser = new UserData() {Id = UserManager.InsertUser(user)};
                return new UserResponse {Users = new List<UserData> {newUser}};
            }
            catch (Exception)
            {
                return new UserResponse
                {
                    Status = new ResponseStatus
                    {
                        ErrorCode = "InsertUserError",
                        Message = "Insert user processing error!"
                    }
                };
            }
        }

        public static UserResponse UpdateUser(UserUpdateRequest request)
        {
            try
            {
                var user = ConvertUserDataToUser(request);
                UserManager.UpdateUser(user);
                return new UserResponse();

            }
            catch (Exception)
            {
                return new UserResponse
                {
                    Status = new ResponseStatus
                    {
                        ErrorCode = "UpdateUserError",
                        Message = "Update user processing error!"
                    }
                };
            }

        }

        public static UserResponse DeleteUser(UserDeleteRequest request)
        {
            try
            {
                UserManager.DeleteUser(request.Id);
                return new UserResponse();

            }
            catch (Exception)
            {
                return new UserResponse
                {
                    Status = new ResponseStatus
                    {
                        ErrorCode = "DeleteUserError",
                        Message = "Delete user processing error!"
                    }
                };
            }
        }

        private static UserResponse ConvertUserListToUserResponse(List<User> users)
        {
            var response = new UserResponse {Users = new List<UserData>()};

            users.ForEach(user =>
            {
                var userData = new UserData
                {
                    Id = user.Id,
                    FirstName = user.FirstName,
                    LastName =  user.LastName,
                    Username = user.Username,
                    Password = user.Password,
                    Mail = user.Mail,
                    Sex = user.Sex,
                    Phone = user.Phone,
                    Deleted = user.Deleted,
                    ContactCount = user.ContactCount,
                    RoleId = user.RoleId
                };
                response.Users.Add(userData);
            });

            return response;
        }

        public static User ConvertUserDataToUser(UserData requestUser)
        {
            return new User
            {
                Id = requestUser.Id,
                FirstName = requestUser.FirstName,
                LastName = requestUser.LastName,
                Username = requestUser.Username,
                Password = requestUser.Password,
                Mail = requestUser.Mail,
                Sex = requestUser.Sex,
                Phone = requestUser.Phone,
                Deleted = requestUser.Deleted,
                ContactCount = requestUser.ContactCount,
                RoleId = requestUser.RoleId
            };
        }
    }
}
