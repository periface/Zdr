using Abp.Auditing;
using Abp.AutoMapper;
using System;
using System.Threading.Tasks;
using Zdr.Sessions.Dto;

namespace Zdr.Sessions
{
    public class SessionAppService : ZdrAppServiceBase, ISessionAppService
    {
        [DisableAuditing]
        public async Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations()
        {
            try
            {
                var output = new GetCurrentLoginInformationsOutput
                {
                    User = (await GetCurrentUserAsync()).MapTo<UserLoginInfoDto>()
                };

                if (AbpSession.TenantId.HasValue)
                {
                    output.Tenant = (await GetCurrentTenantAsync()).MapTo<TenantLoginInfoDto>();
                }

                return output;
            }
            catch (Exception)
            {

                return null;
            }

        }
    }
}