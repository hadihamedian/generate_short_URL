using Microsoft.EntityFrameworkCore;
using ShortLink.ApplicationService.ManageLink;
using ShortLink.Contracts.DAL.ManageLink;
using ShortLink.Infra.SQL;
using ShortLink.Infra.SQL.ManageLink;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<ManageLinkService>();
builder.Services.AddScoped<ILinkRepository, LinkRepository>();
builder.Services.AddDbContext<LinkDbContext>(c => c.UseSqlServer("Server=.; Initial Catalog = GenerateShortLink; User Id = sa; Password=12345678; Encrypt = False"));

builder.Services.AddCors(c =>
{
    c.AddPolicy("AllowOrigin", options => options.AllowAnyOrigin());
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(x => x
               .AllowAnyMethod()
               .AllowAnyHeader()
               .SetIsOriginAllowed(origin => true)
               .AllowCredentials());

app.UseAuthorization();

app.MapControllers();

app.Run();
