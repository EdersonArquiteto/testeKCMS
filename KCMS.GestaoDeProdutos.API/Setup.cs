using KCMS.GestaoDeProdutos.Application.Interface;
using KCMS.GestaoDeProdutos.Application.Services;
using KCMS.GestaoDeProdutos.Domain.Interfaces.Repositories;
using KCMS.GestaoDeProdutos.Domain.Interfaces.Services;
using KCMS.GestaoDeProdutos.Domain.Services;
using KCMS.GestaoDeProdutos.Infra.MongoDB.Contexts;
using KCMS.GestaoDeProdutos.Infra.MongoDB.Repositories;
using KCMS.GestaoDeProdutos.Infra.MongoDB.Settings;
using Microsoft.OpenApi.Models;

namespace KCMS.GestaoDeProdutos.API
{
    public static class Setup
    {
        public static void AddRegisterServices(this WebApplicationBuilder builder)
        {
            builder.Services.AddTransient<ICategoriaAppService, CategoriaAppService>();
            builder.Services.AddTransient<IProdutoAppService, ProdutoAppService>();
            
            builder.Services.AddTransient<CategoriaDomainService>();
            builder.Services.AddTransient<ProdutoDomainService>();
            builder.Services.AddTransient<ICategoriaRepository,CategoriaRepository>();
            builder.Services.AddTransient<IProdutoRepository,ProdutoRepository>();
        }
        public static void AddAutoMapperServices(this WebApplicationBuilder builder)
        {
            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        }

        public static void AddMongoDBServices(this WebApplicationBuilder builder)
        {
            builder.Services.Configure<MongoDBSettings>(builder.Configuration.GetSection("MongoDBSettings"));

            builder.Services.AddSingleton<MongoDBContext>();
            
        }

        public static void AddSwagger(this WebApplicationBuilder builder)
        {
            builder.Services.AddSwaggerGen(s =>
            {
                s.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "API - Gestão de Produtos",
                    Description = "Teste para Desenvolvedor BackEnd",
                    Contact = new OpenApiContact { Name = "Ederson Silva", Email = "edersonmat@hotmail.com" }
                });

                s.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });

                s.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            },
                            Scheme = "oauth2",
                            Name = "Bearer",
                            In = ParameterLocation.Header,

                        },
                        new List<string>()
                    }
                });
            });
        }

        public static void AddCors(this WebApplicationBuilder builder)
        {
            builder.Services.AddCors(
                   s => s.AddPolicy("DefaultPolicy", builder =>
                   {
                       builder.AllowAnyOrigin() //qualquer origem pode acessar a API
                              .AllowAnyMethod() //qualquer método (POST, PUT, DELETE, GET)
                              .AllowAnyHeader(); //qualquer informação de cabeçalho
                   })
               );
        }
        public static void UseCors(this WebApplication app)
        {
            app.UseCors("DefaultPolicy");
        }



    }
}
