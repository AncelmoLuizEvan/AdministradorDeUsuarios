using Blazored.LocalStorage;
using RpcCalc.UI.Auth;
using RpcCalc.UI.Components;
using RpcCalc.UI.Services.Authentication;
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

builder.Services.AddBlazoredLocalStorage();
builder.Services.AddAuthenticationCore();
builder.Services.AddTransient<AuthProvider>();
builder.Services.AddScoped<IUsuarioService, UsuarioService>();
builder.Services.AddScoped<IPerfilService, PerfilService>();
builder.Services.AddScoped<IPermissaoService, PermissaoService>();
builder.Services.AddScoped<IRoleService, RoleService>();
builder.Services.AddScoped<IAuthService, AuthService>();

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
