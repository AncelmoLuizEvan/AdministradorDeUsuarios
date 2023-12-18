using RpcCalc.UI.CacheServices;
using RpcCalc.UI.Components;
using RpcCalc.UI.Services.Authentication;
using RpcCalc.UI.Services.Caches;
using RpcCalc.UI.Services.Perfis;
using RpcCalc.UI.Services.Permissoes;
using RpcCalc.UI.Services.Roles;
using RpcCalc.UI.Services.Usuarios;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var baseUrl = "https://localhost:7154/";

builder.Services.AddHttpClient("API", httpClient =>
{
    httpClient.BaseAddress = new Uri(baseUrl);
});

builder.Services.AddMemoryCache();
builder.Services.AddScoped<IUsuarioService, UsuarioService>();
builder.Services.AddScoped<IPerfilService, PerfilService>();
builder.Services.AddScoped<IPermissaoService, PermissaoService>();
builder.Services.AddScoped<IRoleService, RoleService>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<ICacheService, CacheService>();
builder.Services.AddScoped<ICacheProvider, CacheProvider>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
