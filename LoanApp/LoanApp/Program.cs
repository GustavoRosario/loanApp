using LoanApp.Application.Application.Adapters.Repository;
using LoanApp.Application.Application.Command;
using LoanApp.Application.Application.Query;
using LoanApp.Domain.Ports.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<IApplicationRepository, ApplicationRepository>();
builder.Services.AddScoped<ICommandCaller, CommandCaller>();
builder.Services.AddScoped<IApplicationRepository, ApplicationRepository>();
builder.Services.AddScoped<IDoctorTypeRepository, DoctorTypeRepository>();
builder.Services.AddScoped<IIdentificationTypeRepository, IdentificationTypeRepository>();
builder.Services.AddScoped<IProvinceRepository, ProvinceRepository>();
builder.Services.AddScoped<ISexRepository, SexRepository>();
builder.Services.AddScoped<ITypeFamilyRelationShipRepository, TypeFamilyRelationShipRepository>();
builder.Services.AddScoped<ILoanAmount, LoanAmount>();
builder.Services.AddScoped<ICommunicationChannelRepository, CommunicationChannelRepository>();
builder.Services.AddScoped<IYearOfResidenceRepository, YearOfResidenceRepository>();

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
