using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Businesses.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace ArticleTag.Extensions
{
    public static class SwaggerExtenssion
    {
        public static IServiceCollection AddSwaggerSupport(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                });
                var filePath = Path.Combine(AppContext.BaseDirectory, "ArticleTag.xml");
                c.IncludeXmlComments(filePath);
                //c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                //{
                //    Type = SecuritySchemeType.ApiKey,
                //    In = ParameterLocation.Header,
                //    Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
                //    Name = "Authorization",
                //    Scheme = "Bearer"
                //});
                c.CustomSchemaIds(GetSchemaId);
                //c.AddSecurityRequirement(new OpenApiSecurityRequirement()
                //{
                //    {
                //        new OpenApiSecurityScheme
                //        {
                //            Reference = new OpenApiReference
                //            {
                //                Type = ReferenceType.SecurityScheme,
                //                Id = "Bearer"
                //            },
                //            Name = "Bearer",
                //            In = ParameterLocation.Header,
                //        },
                //        new List<string>()
                //    }
                //});
            });

            return services;
        }

        private static string GetSchemaId(Type type)
        {
            if (!type.IsGenericType)
            {
                return type.Name;
            }
            else if (type.GetGenericTypeDefinition() == typeof(JsonResponseBase<,>))
            {
                var schemaId = new StringBuilder();
                var firstArgType = type.GenericTypeArguments[0];
                if (firstArgType.IsGenericType && firstArgType.GetGenericTypeDefinition() == typeof(IEnumerable<>))
                {
                    schemaId.Append(firstArgType.GenericTypeArguments[0].Name)
                        .Append("List");
                }
                else
                {
                    schemaId.Append(firstArgType.Name);
                }
                schemaId.Append("Response");
                return schemaId.ToString();
            }
            else if (type.GetGenericTypeDefinition() == typeof(IEnumerable<>))
            {
                var firstArgType = type.GenericTypeArguments[0];
                return firstArgType.Name + "List";
            }
            else
            {
                var schemaId = new StringBuilder();
                schemaId.Append(type.Name);
                foreach (var ta in type.GenericTypeArguments)
                {
                    schemaId.Append(".");
                    if (ta.IsGenericType)
                    {
                        schemaId.Append(GetSchemaId(ta));
                    }
                    else
                    {
                        schemaId.Append(ta.Name);
                    }
                }

                return schemaId.ToString();
            }
        }
    }
}
