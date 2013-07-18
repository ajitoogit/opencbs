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
    public class RoleManipulationLogic
    {
        public static RoleResponse GetRoles(RoleRequest request)
        {
            try
            {
                var roles = request.Id != default(int)
                                       ? new List<Role>() {RoleManager.GetRoleById(request.Id)}
                                       : (request.Deleted.HasValue
                                              ? RoleManager.GetAllRoles((bool) request.Deleted)
                                              : null);
                return ConvertRoleListToRoleResponse(roles);
            }
            catch (Exception ex)
            {
                return new RoleResponse
                {
                    Status = new ResponseStatus
                    {
                        ErrorCode = "GetRolesError",
                        Message = "Get roles processing error!"
                    }
                };
                
            }

        }

        private static RoleResponse ConvertRoleListToRoleResponse(List<Role> roles)
        {
            var response = new RoleResponse {Roles = new List<RoleData>()};

            roles.ForEach(role =>
            {
                var roleData = new RoleData
                {
                    Id = role.Id, 
                    Code = role.Code, 
                    Deleted = role.Deleted, 
                    Description = role.Description, 
                    IsRoleOfLoan = role.IsRoleOfLoan, 
                    IsRoleOfSaving = role.IsRoleOfSaving, 
                    IsRoleOfTeller = role.IsRoleOfTeller
                };
                response.Roles.Add(roleData);
            });

            return response;
        }
    }
}
