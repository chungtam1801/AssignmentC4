using Assignment.IServices;
using Assignment.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
//builder.Services.AddTransient<IProductServices, ProductServices>();
//builder.Services.AddSingleton<IProductServices, ProductServices>();
//builder.Services.AddScoped<IProductServices, ProductServices>();
/*
 * Singleton: Services sẽ chỉ được tạo 1 lần trong suốt lifetime của ứng dụng.
 * Phù hợp cho các service có tính toàn cục và không thay đổi.
 * Scope: Mỗi 1 request sẽ khỏi tạo lại service 1 lần. Dùng cho các service có
 * tính chất đặc thù nào đó.
 * Transient: Được khỏi tạo mỗi khi có yêu cầu, Mỗi request sẽ được nhận 1 
 * services khác nhau. Và được sử dụng với services có nhiều yêu cầu http
 */
builder.Services.AddSession(opions =>
{
    opions.IdleTimeout = TimeSpan.FromHours(1);
});
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
app.UseSession();
app.UseRouting();

app.UseAuthorization();
#region MapCtrl
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
    name: "RegisterView",
    pattern: "{controller=Home}/{action=RegisterView}/{id?}");
app.MapControllerRoute(
    name: "LoginView",
    pattern: "{controller=Home}/{action=LoginView}/{id?}");
app.MapControllerRoute(
    name: "ManageClothes",
    pattern: "{controller=Home}/{action=ListClotheses}/{id?}");
app.MapControllerRoute(
    name: "CreateClothesDetailView",
    pattern: "{controller = Home}/{action = CreateClothesDetail}/{ id ?}");
app.MapControllerRoute(
    name: "AddClothesToCart",
    pattern: "{controller = Home}/{action = AddClothesToCart}/{ id ?}");
app.MapControllerRoute(
    name: "ShowCart",
    pattern: "{controller = Home}/{action = ShowCart}/{ id ?}");
app.MapControllerRoute(
    name: "CreateClothesDetail",
    pattern: "{controller = Home}/{action = CreateClothesDetail}/{ id ?}");
app.MapControllerRoute(
    name: "Create",
    pattern: "{controller = Home}/{action = Create}/{ id ?}");
app.MapControllerRoute(
    name: "Chart",
    pattern: "{controller = Home}/{action = Chart}/{ id ?}");
app.MapControllerRoute(
    name: "GetColor",
    pattern: "{controller = Home}/{action = GetColor}/{ id ?}");
app.MapControllerRoute(
    name: "GetSize",
    pattern: "{controller = Home}/{action = GetSize}/{ id ?}");
app.MapControllerRoute(
    name: "BuyNow",
    pattern: "{controller = Home}/{action = BuyNow}/{ id ?}");
#endregion
app.Run();
