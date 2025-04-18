using BlazingConso.Components;
using BlazingConso.Configuration;
using BlazingConso.Helpers;
using BlazingConso.Services.Implementations;
using BlazingConso.Services.Interfaces;
using MudBlazor.Services;
using Syncfusion.Blazor;


var builder = WebApplication.CreateBuilder(args);

// ----- Ajouter la configuration ApiSettings
builder.Services.Configure<ApiSettings>(builder.Configuration.GetSection("ApiSettings"));
// ----- Ajouter la configuration AppInfos
builder.Services.Configure<AppInfos>(builder.Configuration.GetSection("AppInfos"));

// ----- Ajouter HttpClient configuré avec IOptions<ApiSettings>
builder.Services.AddHttpClient("ConsommationClient", client =>
{
    var apiUrl = builder.Configuration["ApiSettings:BaseUrl"];
    if (string.IsNullOrEmpty(apiUrl))
        throw new InvalidOperationException("L'URL de l'API est introuvable !");

    client.BaseAddress = new Uri(apiUrl);
    client.DefaultRequestHeaders.Add("Accept", "application/json");
});

// ----- Active la licence Syncfusion
Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("Mzc5NjI1MEAzMjM5MmUzMDJlMzAzYjMyMzkzYktiTno1MHBFRFFYdnFsTTFqek0zS200ejROUThPenZLOE1rY2Jabjc0eTQ9;Mzc5NjI1MUAzMjM5MmUzMDJlMzAzYjMyMzkzYk55eUFvRWxJM3BRTWp5WlFuM1kwcFp4NGhiZy9UbEhIV21XYW5NWnRyZzg9");

// ----- Add MudBlazor services
builder.Services.AddMudServices();
// ----- Add SyncfusionBlazor services
builder.Services.AddSyncfusionBlazor();

// ------ Add Blazor services
builder.Services.AddScoped<IInfosConsoService, InfosConsoService>();
builder.Services.AddScoped<IConsoDayService, ConsoDayService>();    
builder.Services.AddScoped<IInfosCoutsService, InfosCoutsService>();
builder.Services.AddScoped<IConso30Service, Conso30Service>();
builder.Services.AddScoped<IConsoMonthService, ConsoMonthService>();
builder.Services.AddSingleton<MoisState>();

// ----- Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var app = builder.Build();

// ----- Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseRequestLocalization("fr-FR");

app.UseHttpsRedirection();

app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
