﻿using Blazored.LocalStorage;
using RpcCalc.UI.Interop.Perfis;
using System.Text.Json;

namespace RpcCalc.UI.Services.Perfis
{
    public class PerfilService : IPerfilService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILocalStorageService _localStorageService;

        public PerfilService(IHttpClientFactory httpClientFactory, 
            ILocalStorageService localStorageService)
        {
            _httpClientFactory = httpClientFactory;
            _localStorageService = localStorageService;
        }

        public async Task<PerfilDto?> Alterar(Guid id, PerfilViewModel viewModel)
        {
            try
            {
                var httpClient = _httpClientFactory.CreateClient("API");
                var response = await httpClient.PutAsJsonAsync($"api/perfil/alterar/{id}", viewModel);

                if (response.IsSuccessStatusCode)
                {
                    var responseBody = await response.Content.ReadAsStreamAsync();
                    var perfilUp = await JsonSerializer.DeserializeAsync<PerfilDto>(responseBody, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                    return perfilUp;
                }

                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                throw;
            }
        }

        public async Task<PerfilDto?> Capturar(Guid id)
        {
            try
            {
                var httpClient = _httpClientFactory.CreateClient("API");
                return await httpClient.GetFromJsonAsync<PerfilDto>($"api/perfil/{id}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                throw;
            }
        }

        public async Task<bool> Excluir(Guid id)
        {
            try
            {
                var httpClient = _httpClientFactory.CreateClient("API");
                var response = await httpClient.DeleteFromJsonAsync<bool>($"api/perfil/excluir/{id}");

                return response;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                throw;
            }
        }

        public async Task<PerfilDto?> Gravar(PerfilViewModel viewModel)
        {
            try
            {
                var httpClient = _httpClientFactory.CreateClient("API");
                var response = await httpClient.PostAsJsonAsync("api/perfil/gravar", viewModel);

                if (response.IsSuccessStatusCode)
                {
                    var responseBody = await response.Content.ReadAsStreamAsync();
                    var perfilAdd = await JsonSerializer.DeserializeAsync<PerfilDto>(responseBody, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                    return perfilAdd;
                }

                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                throw;
            }
        }

        public async Task<IEnumerable<PerfilDto>?> ObterTodos()
        {
            //https://code-maze.com/add-bearertoken-httpclient-request/
            // tutorial

            try
            {
                //TODO pegar no cooke
                var token = "";

                var httpClient = _httpClientFactory.CreateClient("API");
                httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
                return await httpClient.GetFromJsonAsync<IEnumerable<PerfilDto>?>("api/perfil/ObterTodos");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                throw;
            }
        }
    }
}
