﻿using RpcCalc.UI.Interop.Usuarios;
using RpcCalc.UI.Services.Caches;
using System.Text.Json;

namespace RpcCalc.UI.Services.Usuarios
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ICacheService _cacheService;

        public UsuarioService(IHttpClientFactory httpClientFactory, ICacheService cacheService)
        {
            _httpClientFactory = httpClientFactory;
            _cacheService = cacheService;
        }

        public async Task<UsuarioDto?> Alterar(Guid id, UsuarioViewModel viewModel)
        {
            try
            {
                var usuarioLogadoCached = _cacheService.GetCachedToken("_token");
                var httpClient = _httpClientFactory.CreateClient("API");
                httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", usuarioLogadoCached!.Token);
                var response = await httpClient.PutAsJsonAsync($"api/Usuario/alterar/{id}", viewModel);

                if (response.IsSuccessStatusCode)
                {
                    var responseBody = await response.Content.ReadAsStreamAsync();
                    var usuarioUp = await JsonSerializer.DeserializeAsync<UsuarioDto>(responseBody, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                    return usuarioUp;
                }

                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                throw;
            }
        }

        public async Task<UsuarioDto?> Capturar(Guid id)
        {
            try
            {
                var usuarioLogadoCached = _cacheService.GetCachedToken("_token");
                var httpClient = _httpClientFactory.CreateClient("API");
                httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", usuarioLogadoCached!.Token);
                return await httpClient.GetFromJsonAsync<UsuarioDto>($"api/Usuario/{id}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                throw;
            }
        }

        public async Task<string> AlterarStatus(Guid id, UsuarioInativacaoViewModel viewModel)
        {
            try
            {
                var usuarioLogadoCached = _cacheService.GetCachedToken("_token");
                var httpClient = _httpClientFactory.CreateClient("API");
                httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", usuarioLogadoCached!.Token);
                var response = await httpClient.PutAsJsonAsync($"api/Usuario/alterarstatus/{id}", viewModel);

                var result = await response.Content.ReadAsStringAsync();

                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                throw;
            }
        }

        public async Task<bool> ExcluirUsuarioPerfil(Guid idusuario, Guid idperfil, Guid idpermissao)
        {
            try
            {
                var usuarioLogadoCached = _cacheService.GetCachedToken("_token");
                var httpClient = _httpClientFactory.CreateClient("API");
                httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", usuarioLogadoCached!.Token);
                var response = await httpClient.DeleteFromJsonAsync<bool>($"api/Usuario/excluir/usuario/{idusuario}/perfil/{idperfil}/permissao/{idpermissao}");

                return response;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                throw;
            }
        }

        public async Task<UsuarioDto?> Gravar(UsuarioViewModel viewModel)
        {
            try
            {
                var usuarioLogadoCached = _cacheService.GetCachedToken("_token");
                var httpClient = _httpClientFactory.CreateClient("API");
                httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", usuarioLogadoCached!.Token);
                var response = await httpClient.PostAsJsonAsync("api/Usuario/gravar", viewModel);

                if (response.IsSuccessStatusCode)
                {
                    var responseBody = await response.Content.ReadAsStreamAsync();
                    var usuarioAdd = await JsonSerializer.DeserializeAsync<UsuarioDto>(responseBody, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                    return usuarioAdd;
                }

                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                throw;
            }
        }

        public async Task<UsuarioDto?> ObterPorEmail(EmailViewModel viewModel)
        {
            try
            {
                var usuarioLogadoCached = _cacheService.GetCachedToken("_token");
                var httpClient = _httpClientFactory.CreateClient("API");
                httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", usuarioLogadoCached!.Token);
                var response = await httpClient.PostAsJsonAsync("api/Usuario/Cliente", viewModel);

                if (response.IsSuccessStatusCode)
                {
                    var responseBody = await response.Content.ReadAsStreamAsync();
                    var usuarioAdd = await JsonSerializer.DeserializeAsync<UsuarioDto>(responseBody, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                    return usuarioAdd;
                }

                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                throw;
            }
        }

        public async Task<IEnumerable<UsuarioDto>?> ObterTodos()
        {
            try
            {
                var usuarioLogadoCached = _cacheService.GetCachedToken("_token");
                var httpClient = _httpClientFactory.CreateClient("API");
                httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", usuarioLogadoCached!.Token);
                return await httpClient.GetFromJsonAsync<IEnumerable<UsuarioDto>?>("api/Usuario/ObterTodos");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                throw;
            }
        }
    }
}
