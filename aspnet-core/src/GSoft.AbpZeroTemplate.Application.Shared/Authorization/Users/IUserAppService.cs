﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using GSoft.AbpZeroTemplate.Authorization.Users.Dto;
using GSoft.AbpZeroTemplate.Dto;
using GSoft.AbpZeroTemplate.Authorization.Roles;

namespace GSoft.AbpZeroTemplate.Authorization.Users
{
    public interface IUserAppService : IApplicationService
    {
        Task<IList<string>> GetCurrentRolesOfUser();

        Task<PagedResultDto<UserListDto>> GetUsers(GetUsersInput input);

        Task<FileDto> GetUsersToExcel();

        Task<GetUserForEditOutput> GetUserForEdit(NullableIdDto<long> input);

        Task<GetUserPermissionsForEditOutput> GetUserPermissionsForEdit(EntityDto<long> input);

        Task ResetUserSpecificPermissions(EntityDto<long> input);

        Task UpdateUserPermissions(UpdateUserPermissionsInput input);

        Task CreateOrUpdateUser(CreateOrUpdateUserInput input);

        Task DeleteUser(EntityDto<long> input);

        Task UnlockUser(EntityDto<long> input);
    }
}