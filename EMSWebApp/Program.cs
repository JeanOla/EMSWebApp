using EMSWebApp.Data;
using EMSWebApp.Repository;
using EMSWebApp.Repository.InMemory;
using EMSWebApp.Repository.msSQL;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
//db
builder.Services.AddDbContext<EmsDbContext>();
builder.Services.AddScoped<EmsDbContext, EmsDbContext>();
builder.Services.AddScoped<IEMSRepository, EMSDBRepository>();
builder.Services.AddScoped<IEmpRepository, EmpRepository>();

//inmemory
//builder.Services.AddSingleton<IEMSRepository, DeptInMemoryRepository>();
//builder.Services.AddSingleton<IEmpRepository, EmpImMemoryRepository>();


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

app.Run();
