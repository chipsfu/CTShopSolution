﻿using CTShopSolution.ViewModels.Common;
using CTShopSolution.ViewModels.System.Users;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace CTShopSolution.AdminApp.Services
{
    public class UserApiClient : IUserApiClient
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;

        public UserApiClient(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _httpClientFactory = httpClientFactory;
            _configuration = configuration;
        }
        public async Task<string> Authenticate(LoginRequest request)
        {
            var json = JsonConvert.SerializeObject(request);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");

           var client = _httpClientFactory.CreateClient();
           client.BaseAddress = new Uri(_configuration["BaseAddress"]);
           var response = await client.PostAsync("/api/users/auth", httpContent);
           var token = await response.Content.ReadAsStringAsync();
           return token;
        }

        public async Task<PagedResult<UserViewModel>> GetUserPaging(GetUserPagingRequest request)
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration["BaseAddress"]);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", request.BearerToken);

            var response = await client.GetAsync($"/api/users/paging?pageIndex=" + 
                                                 $"{request.PageIndex}&pageSize={request.PageSize}&keywords={request.Keyword}");
            var body = await response.Content.ReadAsStringAsync();
            var user = JsonConvert.DeserializeObject<PagedResult<UserViewModel>>(body);
            return user;
        }

        public async Task<bool> RegisterUser(RegisterRequest request)
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration["BaseAddress"]);
            var json = JsonConvert.SerializeObject(request);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PostAsync($"/api/users", httpContent);
          
            return response.IsSuccessStatusCode;
        }
    }
}
