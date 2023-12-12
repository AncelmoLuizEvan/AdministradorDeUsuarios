using RpcCalc.UI.Components;
using RpcCalc.UI.Services.Perfis;
using RpcCalc.UI.Services.Permissoes;
using RpcCalc.UI.Services.Usuarios;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var baseUrl = "https://localhost:7154/";

builder.Services.AddHttpClient("API", httpClient =>
{
    httpClient.BaseAddress = new Uri(baseUrl);
});

builder.Services.AddScoped<IUsuarioService, UsuarioService>();
builder.Services.AddScoped<IPerfilService, PerfilService>();
builder.Services.AddScoped<IPermissaoService, PermissaoService>();

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