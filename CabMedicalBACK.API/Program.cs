using System.Text;
using CabMedicalBACK.API.Services;
using CabMedicalBACK.BLL.Interfaces;
using CabMedicalBACK.BLL.Services;
using CabMedicalBACK.DAL.Interfaces;
using CabMedicalBACK.DAL.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Npgsql;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddTransient<NpgsqlConnection>(s =>
{
    string? connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
    return new NpgsqlConnection(connectionString);
});

builder.Services.AddControllers();

builder.Services.AddScoped<JwtService>();

builder.Services.AddScoped<IAuthService, AuthService>();

builder.Services.AddScoped<IRendezVousRepository, RendezVousRepository>();
builder.Services.AddScoped<IRendezVousService, RendezVousService>();

builder.Services.AddScoped<IPatientRepository, PatientRepository>();
builder.Services.AddScoped<IPatientService, PatientService>();

builder.Services.AddScoped<ITravailleurRepository, TravailleurRepository>();
builder.Services.AddScoped<ITravailleurService, TravailleurService>();

builder.Services.AddScoped<IUtilisateurRepository, UtilisateurRepository>();
builder.Services.AddScoped<IUtilisateurService, UtilisateurService>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c => {
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 1safsfsdfdfd\"",
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement {
        {
            // TODO Cleanup swagger https://github.com/domaindrivendev/Swashbuckle.AspNetCore?tab=readme-ov-file#add-security-definitions-and-requirements
            new OpenApiSecurityScheme {
                Reference = new OpenApiReference {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] {}
        }
    });
});

// Configuration de l'auth et du JWT
builder.Services.AddAuthentication(option =>
    {
        // Indique que le système d'authentification et de permission va se baser sur le schema du JWT Bearer
        option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    })
    .AddJwtBearer(option =>
        {
            // Configure la validation du token
            option.TokenValidationParameters = new TokenValidationParameters
            {
                // Vérifie que la clé utilisée pour signer le token est valide (TRUE ! Important !)
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"])),
                // Vérifie que le token provient du bon émetteur (optionnel)
                ValidateIssuer = true,
                ValidIssuer = builder.Configuration["Jwt:Issuer"],
                // Vérifie que le token provient du bon public (optionnel)
                ValidateAudience = true,
                ValidAudience = builder.Configuration["Jwt:Audience"],
                // Vérifie que le token n'a pas encore expiré
                ValidateLifetime = true,
                //ClockSkew = TimeSpan.Zero
            };
        }
    );

builder.Services.AddCors(c => c.AddDefaultPolicy(o =>
{
    o.AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader();
}));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors();
app.UseAuthorization();
app.MapControllers();

app.Run();

