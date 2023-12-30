using PlainWebApi.Controllers;
using BLL;
using BOL;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseRouting();

// app.MapControllerRoute(
//     name: "default",
//     pattern: "{controller}/{action=Index}");

app.MapGet("/api/emplist",   () =>{
        EmployeesData empdata = new EmployeesData();
        List<Employees> list = empdata.GetAllEmployees();
    return list;
});

app.Run();



