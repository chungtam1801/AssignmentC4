var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "ShowClotheses",
    pattern: "{controller=Home}/{action=ShowClotheses}/{id?}");

app.MapControllerRoute(
    name: "Detail",
    pattern: "{controller=Home}/{action=Details}/{id?}");

app.MapControllerRoute(
    name: "ListClotheses",
    pattern: "{controller=Home}/{action=ListClotheses}/{id?}");

app.Run();
