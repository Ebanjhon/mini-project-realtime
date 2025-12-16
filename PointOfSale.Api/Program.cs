using Amazon.S3;
using Microsoft.EntityFrameworkCore;
using PointOfSale.Api.Data;
using PointOfSale.Api.Services;

var builder = WebApplication.CreateBuilder(args);

// MinIO config
var minioConfig = builder.Configuration.GetSection("MinIO");

builder.Services.AddSingleton<IAmazonS3>(sp =>
{
    var config = new AmazonS3Config
    {
        ServiceURL = minioConfig["Endpoint"],
        ForcePathStyle = true
    };

    return new AmazonS3Client(
        minioConfig["AccessKey"],
        minioConfig["SecretKey"],
        config
    );
});

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddOpenApi();

builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<MyDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IS_User, S_User>();
builder.Services.AddScoped<IS_Category, S_Category>();
builder.Services.AddScoped<IS_Product, S_Product>();
builder.Services.AddScoped<S_Minio>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    //app.UseSwagger();
    //app.UseSwaggerUI();

    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "POS API V1");
        c.RoutePrefix = string.Empty;
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
