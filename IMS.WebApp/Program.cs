using IMS.Plugins.InMemory;
using IMS.UseCases.Inventories;
using IMS.UseCases.Inventories.Interfaces;
using IMS.UseCases.NovaPasta;
using IMS.UseCases.PluginInterfaces;
using IMS.UseCases.Products;
using IMS.UseCases.Products.Interfaces;
using IMS.WebApp.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();

builder.Services.AddServerSideBlazor();

builder.Services.AddSingleton<WeatherForecastService>();
builder.Services.AddSingleton<IInventoryRepository, InventoryRepository>();
builder.Services.AddSingleton<IProductRepository, ProductRepository> ();

builder.Services.AddScoped<IViewInventoriesByNameUseCase, ViewInventoriesByNameUseCase>();

builder.Services.AddTransient<IViewInventoriesByNameUseCase, ViewInventoriesByNameUseCase>();
builder.Services.AddTransient<IAddInventoryUseCase, AddInventoryUseCase> ();
builder.Services.AddTransient<IEditInventoryUseCase, EditInventoryUseCase> ();
builder.Services.AddTransient<IViewInventoryByIdUseCase, ViewInventoryByIdUseCase> ();
builder.Services.AddTransient<IViewProductsByNameUseCase, ViewProductsByNameUseCase> ();
builder.Services.AddTransient<IAddProductUseCase, AddProductUseCase> ();
builder.Services.AddTransient<IViewProductByIdUseCase, ViewProductByIdUseCase> ();
builder.Services.AddTransient<IEditProductUseCase, EditProductUseCase> ();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
