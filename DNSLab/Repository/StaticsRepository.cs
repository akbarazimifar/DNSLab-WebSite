﻿using DNSLab.DTOs.Statics;
using DNSLab.Interfaces.Helper;
using DNSLab.Interfaces.Repository;

namespace DNSLab.Repository
{
    public class StaticsRepository : IStaticsRepository
    {
        private readonly IHttpService _httpService;
        public StaticsRepository(IHttpService httpService)
        {
            this._httpService = httpService;
        }

        public async Task<bool> PageVisit(string ip, string url)
        {
            var response = await _httpService.Post<bool>($"/Statics/PageVisit?ip={ip}&pageUrl={url}");
            if (!response.Success)
                return false;
            else
                return response.Response;
        }

        public async Task<int> PageVisitCount(string url)
        {
            var response = await _httpService.Get<int>($"/Statics/PageVisitCount?pageUrl={url}");
            if (!response.Success)
                return 0;
            else
                return response.Response;
        }

        public async Task<bool> AddSiteChange(SiteChangesDTO siteChanges)
        {
            var response = await _httpService.Post<SiteChangesDTO, bool>($"/Statics/AddSiteChange", siteChanges);
            if (response.Success)
                return response.Response;

            return false;
        }

        public async Task<bool> UpdateSiteChange(SiteChangesDTO siteChanges)
        {
            var response = await _httpService.Put<SiteChangesDTO, bool>($"/Statics/UpdateSiteChange", siteChanges);
            if (response.Success)
                return response.Response;

            return false;
        }

        public async Task<bool> DeleteSiteChange(Guid id)
        {
            var response = await _httpService.Delete<bool>($"/Statics/DeleteSiteChange?id={id}");
            if (response.Success)
                return response.Response;

            return false;
        }

        public async Task<SiteChangesDTO> GetSiteChange(Guid id)
        {
            var response = await _httpService.Get<SiteChangesDTO>($"/Statics/GetSiteChange?id={id}");
            if (response.Success)
                return response.Response;

            return null;
        }

        public async Task<IEnumerable<SiteChangesDTO>> GetLastChanges()
        {
            var response = await _httpService.Get<IEnumerable<SiteChangesDTO>>($"/Statics/GetLastChanges");
            if (response.Success)
                return response.Response;

            return null;
        }
    }
}
