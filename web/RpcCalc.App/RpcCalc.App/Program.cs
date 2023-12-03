using RpcCalc.App.Client.Pages;
using RpcCalc.App.Components;
using RpcCalc.APP.Services.Perfis;
using RpcCalc.APP.Services.Permissoes;
using RpcCalc.APP.Services.Usuarios;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorComponents()
    .AddInteractiveWebAssemblyComponents();

var baseUrl = "https://localhost:7154/";

builder.Services.AddHttpClient("API", httpClient =>
{
    httpClient.BaseAddress = new Uri(baseUrl);
});

builder.Services.AddScoped<IUsuarioService, UsuarioService>();
builder.Services.AddScoped<IPerfilService, PerfilService>();
builder.Services.AddScoped<IPermissaoService, PermissaoService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(Counter).Assembly);

app.Run();
