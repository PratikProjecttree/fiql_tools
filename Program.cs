using fiql_tools.Data;
using fiql_tools.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.OData.Edm;
using fiql_tools.Models;
using Microsoft.AspNetCore.OData;
using Microsoft.OData.ModelBuilder;

var builder = WebApplication.CreateBuilder(args);


var modelBuilder = new ODataConventionModelBuilder();
//modelBuilder.EntityType<Question>();
//modelBuilder.EntitySet<Question>("Questions");
//modelBuilder.EntitySet<QuestionType>("QuestionType");

// Add services to the container.
builder.Services.AddDbContext<GssContext>(options =>
       options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IOptionService, OptionService>();
builder.Services.AddControllers().AddOData(
options => options.Select().Filter().OrderBy().Expand().Count().SetMaxTop(null)
);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseRouting();
app.UseEndpoints(endpoints => endpoints.MapControllers());


app.Run();
