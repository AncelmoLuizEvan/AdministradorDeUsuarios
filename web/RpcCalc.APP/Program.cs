using RpcCalc.APP.Components;
using RpcCalc.APP.Services.Perfis;
using RpcCalc.APP.Services.Permissoes;
using RpcCalc.APP.Services.Usuarios;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();


var baseUrl = "https://localhost:7154/";

//builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(baseUrl) });

//builder.Services.AddHttpClient();

builder.Services.AddHttpClient("API", httpClient =>
{
    httpClient.BaseAddress = new Uri(baseUrl);

    // using Microsoft.Net.Http.Headers;
    // The GitHub API requires two headers.
    //httpClient.DefaultRequestHeaders.Add(
    //    HeaderNames.Accept, "application/vnd.github.v3+json");
    //httpClient.DefaultRequestHeaders.Add(
    //    HeaderNames.UserAgent, "HttpRequestsSample");
});

builder.Services.AddScoped<IUsuarioService, UsuarioService>();
builder.Services.AddScoped<IPerfilService, PerfilService>();
builder.Services.AddScoped<IPermissaoService, PermissaoService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
