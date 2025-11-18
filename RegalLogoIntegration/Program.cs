using RegalLogoIntegration.Extensions;

var builder = WebApplication.CreateBuilder(args);

// 1) Ayarları yükle
builder.Services.Configure<ApiSecurityOptions>(builder.Configuration.GetSection("ApiSecurity"));

// 2) Controller ve Swagger servisini ekle
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddProjectServices();

builder.Services.AddSwaggerGen(c =>
{
    c.AddSecurityDefinition("ApiKey", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
    {
        Description = "API Key header: X-API-KEY",
        Name = "X-API-KEY",
        In = Microsoft.OpenApi.Models.ParameterLocation.Header,
        Type = Microsoft.OpenApi.Models.SecuritySchemeType.ApiKey,
        Scheme = "ApiKeyScheme"
    });

    c.AddSecurityRequirement(new Microsoft.OpenApi.Models.OpenApiSecurityRequirement
    {
        {
            new Microsoft.OpenApi.Models.OpenApiSecurityScheme
            {
                Reference = new Microsoft.OpenApi.Models.OpenApiReference
                {
                    Type = Microsoft.OpenApi.Models.ReferenceType.SecurityScheme,
                    Id = "ApiKey"
                }
            },
            new string[] {}
        }
    });
});

var app = builder.Build();

// ⚠️ Swagger middleware'i ÖNCE çalışmalı
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// ✅ Artık Swagger erişilebilir olacak
// Burada custom middleware'i çağır
app.UseMiddleware<ApiKeyAndIpMiddleware>();

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();