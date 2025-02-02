﻿using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using GWebsite.AbpZeroTemplate.Application;
using GWebsite.AbpZeroTemplate.Application.Share.Revokes;
using GWebsite.AbpZeroTemplate.Application.Share.Revokes.Dto;
using GWebsite.AbpZeroTemplate.Core.Authorization;
using GWebsite.AbpZeroTemplate.Core.Models;
using System.Linq;
using System.Linq.Dynamic.Core;

namespace GWebsite.AbpZeroTemplate.Web.Core.Revokes
{
    [AbpAuthorize(GWebsitePermissions.Pages_Administration_MenuClient)]
    public class RevokeAppService : GWebsiteAppServiceBase, IRevokeAppService
    {
        private readonly IRepository<Revoke> revokeRepository;

        public RevokeAppService(IRepository<Revoke> revokeRepository)
        {
            this.revokeRepository = revokeRepository;
        }

        #region Public Method

        public void CreateOrEditRevoke(RevokeInput revokeInput)
        {
            if (revokeInput.Id == 0)
            {
                Create(revokeInput);
            }
            else
            {
                Update(revokeInput);
            }
        }

        public void DeleteRevoke(int id)
        {
            var revokeEntity = revokeRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (revokeEntity != null)
            {
                revokeEntity.IsDelete = true;
                revokeRepository.Update(revokeEntity);
                CurrentUnitOfWork.SaveChanges();
            }
        }

        public RevokeInput GetRevokeForEdit(int id)
        {
            var revokeEntity = revokeRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (revokeEntity == null)
            {
                return null;
            }
            return ObjectMapper.Map<RevokeInput>(revokeEntity);
        }

        public RevokeForViewDto GetRevokeForView(int id)
        {
            var revokeEntity = revokeRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (revokeEntity == null)
            {
                return null;
            }
            return ObjectMapper.Map<RevokeForViewDto>(revokeEntity);
        }

        public PagedResultDto<RevokeDto> GetRevokes(RevokeFilter input)
        {
            var query = revokeRepository.GetAll().Where(x => !x.IsDelete);

            // filter by value
            if (input.AssetId != null)
            {
                query = query.Where(x => x.AssetId.ToLower().Equals(input.AssetId));
            }

            var totalCount = query.Count();

            // sorting
            if (!string.IsNullOrWhiteSpace(input.Sorting))
            {
                query = query.OrderBy(input.Sorting);
            }

            // paging
            var items = query.PageBy(input).ToList();

            // result
            return new PagedResultDto<RevokeDto>(
                totalCount,
                items.Select(item => ObjectMapper.Map<RevokeDto>(item)).ToList());
        }

        #endregion

        #region Private Method

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_MenuClient_Create)]
        private void Create(RevokeInput revokeInput)
        {
            var revokeEntity = ObjectMapper.Map<Revoke>(revokeInput);
            SetAuditInsert(revokeEntity);
            revokeRepository.Insert(revokeEntity);
            CurrentUnitOfWork.SaveChanges();
        }

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_MenuClient_Edit)]
        private void Update(RevokeInput revokeInput)
        {
            var revokeEntity = revokeRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == revokeInput.Id);
            if (revokeEntity == null)
            {
            }
            ObjectMapper.Map(revokeInput, revokeEntity);
            SetAuditEdit(revokeEntity);
            revokeRepository.Update(revokeEntity);
            CurrentUnitOfWork.SaveChanges();
        }

        #endregion
    }
}