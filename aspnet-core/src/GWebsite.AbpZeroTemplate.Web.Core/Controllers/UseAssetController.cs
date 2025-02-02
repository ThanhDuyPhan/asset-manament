﻿using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.UseAssets;
using GWebsite.AbpZeroTemplate.Application.Share.UseAssets.Dto;
using Microsoft.AspNetCore.Mvc;

namespace GWebsite.AbpZeroTemplate.Application.Controllers
{
    [Route("api/[controller]/[action]")]
    public class UseAssetController : GWebsiteControllerBase
    {
        private readonly IUseAssetAppService useAssetAppService;

        public UseAssetController(IUseAssetAppService useAssetAppService)
        {
            this.useAssetAppService = useAssetAppService;
        }

        [HttpGet]
        public PagedResultDto<UseAssetDto> GetUseAssetsByFilter(UseAssetFilter useAssetFilter)
        {
            return useAssetAppService.GetUseAssets(useAssetFilter);
        }

        [HttpGet]
        public UseAssetInput GetUseAssetForEdit(int id)
        {
            return useAssetAppService.GetUseAssetForEdit(id);
        }

        [HttpPost]
        public void CreateOrEditUseAsset([FromBody] UseAssetInput input)
        {
            useAssetAppService.CreateOrEditUseAsset(input);
        }

        [HttpDelete("{id}")]
        public void DeleteUseAsset(int id)
        {
            useAssetAppService.DeleteUseAsset(id);
        }

        [HttpGet]
        public UseAssetForViewDto GetUseAssetForView(int id)
        {
            return useAssetAppService.GetUseAssetForView(id);
        }
    }
}