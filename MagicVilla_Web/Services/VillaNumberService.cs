using MagicVilla_Utility;
using MagicVilla_Web.Models.Dto;
using MagicVilla_Web.Models;
using MagicVilla_Web.Services.IServices;
using System.Linq.Expressions;

namespace MagicVilla_Web.Services
{
    public class VillaNumberService : BaseServices, IVillaNumberService
    {
        private readonly IHttpClientFactory _clientFactory;
        private string villaUrl;
        public VillaNumberService(IHttpClientFactory clientFactory, IConfiguration configuration) : base(clientFactory)
        {
            _clientFactory = clientFactory;
            villaUrl = configuration.GetValue<string>("ServiceUrls:VillaAPI");
        }

        public Task<T> CreateAsync<T>(VillaNumberCreateDTO dto, string token)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = StaticDetail.ApiType.POST,
                Data = dto,
                Url = villaUrl + "/api/v1/VillaNumberAPI",
                Token = token
            });
        }

        public Task<T> DeleteAsync<T>(int id, string token)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = StaticDetail.ApiType.DELETE,
                Url = villaUrl + "/api/v1/VillaNumberAPI/" + id,
                Token = token
            });
        }

        public Task<T> GetAllAsync<T>(string token)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = StaticDetail.ApiType.GET,
                Url = villaUrl + "/api/v1/VillaNumberAPI",
                Token = token
            });
        }

        public Task<T> GetAsync<T>(int id, string token)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = StaticDetail.ApiType.GET,
                Url = villaUrl + "/api/v1/VillaNumberAPI/" + id,
                Token = token
            });
        }

        public Task<T> UpdateAsync<T>(VillaNumberUpdateDTO dto, string token)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = StaticDetail.ApiType.PUT,
                Data = dto,
                Url = villaUrl + "/api/v1/VillaNumberAPI/" + dto.VillaNo,
                Token = token
            });
        }
    }
}
