using System.Threading.Tasks;
using Abp.Application.Services;
using Zdr.Roles.Dto;

namespace Zdr.Roles
{
    public interface IRoleAppService : IApplicationService
    {
        Task UpdateRolePermissions(UpdateRolePermissionsInput input);
    }
}
