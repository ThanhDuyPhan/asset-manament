﻿using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using GSoft.AbpZeroTemplate.Organizations.Dto;

namespace GSoft.AbpZeroTemplate.Organizations
{
    public interface IOrganizationUnitAppService : IApplicationService
    {
        Task<ListResultDto<OrganizationUnitDto>> GetOrganizationUnits();

        Task<PagedResultDto<OrganizationUnitUserListDto>> GetOrganizationUnitUsers(GetOrganizationUnitUsersInput input);

        Task<OrganizationUnitDto> CreateOrganizationUnit(CreateOrganizationUnitInput input);

        Task<OrganizationUnitDto> UpdateOrganizationUnit(UpdateOrganizationUnitInput input);

        Task<OrganizationUnitDto> MoveOrganizationUnit(MoveOrganizationUnitInput input);

        Task DeleteOrganizationUnit(EntityDto<long> input);

        Task RemoveUserFromOrganizationUnit(UserToOrganizationUnitInput input);

        Task AddUsersToOrganizationUnit(UsersToOrganizationUnitInput input);

        Task<PagedResultDto<NameValueDto>> FindUsers(FindOrganizationUnitUsersInput input);

        Task<ListResultDto<OrganizationUnitUserListDto>> GetListUsersOrganizationUnit(int id);

        Task<OrganizationUnitDto> GetOrganizationUnitByID(int id);

        Task<OrganizationUnitDto> GetOrganizationUnitByCode(string code);
    }
}
