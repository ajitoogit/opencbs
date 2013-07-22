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
                var roles = request.Id > 0
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

        public static RoleResponse InsertRole(RoleInsertRequest request)
        {
            try
            {
                
                var role = ConvertRoleDataToRole(request);
                var newRole = new RoleData {Id = RoleManager.InsertRole(role)};
                return new RoleResponse {Roles = new List<RoleData> {newRole}};
            }
            catch (Exception)
            {
                return new RoleResponse
                {
                    Status = new ResponseStatus
                    {
                        ErrorCode = "InsertRoleError",
                        Message = "Insert role processing error!"
                    }
                };
            }
        }

        public static RoleResponse UpdateRole(RoleUpdateRequest request)
        {
            try
            {
                var role = ConvertRoleDataToRole(request);
                RoleManager.UpdateRole(role);
                return new RoleResponse();

            }
            catch (Exception)
            {
                return new RoleResponse
                {
                    Status = new ResponseStatus
                    {
                        ErrorCode = "UpdateRoleError",
                        Message = "Update role processing error!"
                    }
                };
            }

        }

        public static RoleResponse DeleteRole(RoleDeleteRequest request)
        {
            try
            {
                RoleManager.DeleteRole(request.Id);
                return new RoleResponse();

            }
            catch (Exception)
            {
                return new RoleResponse
                {
                    Status = new ResponseStatus
                    {
                        ErrorCode = "DeleteRoleError",
                        Message = "Delete role processing error!"
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

        public static Role ConvertRoleDataToRole(RoleData requestRole)
        {
            return new Role
            {
                Id = requestRole.Id,
                Code = requestRole.Code,
                Deleted = requestRole.Deleted,
                Description = requestRole.Description,
                IsRoleOfLoan = requestRole.IsRoleOfLoan,
                IsRoleOfSaving = requestRole.IsRoleOfSaving,
                IsRoleOfTeller = requestRole.IsRoleOfTeller
            };
        }
    }
}
