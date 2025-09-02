using MaterialApi.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;

var builder = WebApplication.CreateBuilder(args);

// --- Configure Services ---

// 1. Add CORS policy
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins",
        policyBuilder => policyBuilder.AllowAnyOrigin()
                          .AllowAnyMethod()
                          .AllowAnyHeader());
});

// 2. Add Database Context
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
if (string.IsNullOrEmpty(connectionString))
{
    throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
}
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));

// 3. Add Controllers and NewtonsoftJson support
builder.Services.AddControllers().AddNewtonsoftJson();

// 4. Add Swagger for API testing
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "MaterialApi", Version = "v1" });
});


// --- Build the Application ---
var app = builder.Build();


// --- Configure the HTTP Request Pipeline ---

// 1. Configure for Development environment
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "MaterialApi v1"));
}

// 2. Enable serving default files (like index.html) and static files
app.UseDefaultFiles();
app.UseStaticFiles();

// 3. Add Routing, CORS, and Authorization middleware
app.UseRouting();
app.UseCors("AllowAllOrigins");
app.UseAuthorization();

// 4. Map controller endpoints
app.MapControllers();

// 5. Run the application
app.Run();