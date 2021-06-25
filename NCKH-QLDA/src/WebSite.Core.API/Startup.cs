using Autofac;
using FluentValidation.AspNetCore;
using IdentityModel.AspNetCore.OAuth2Introspection;
using IdentityServer4.AccessTokenValidation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using NCKH.Infrastruture.Binding.CustomAttributes;
using NCKH.Infrastruture.Binding.Middleware;
using NCKH.Infrastruture.Binding.ModelBinders;
using NCKH.Infrastruture.Binding.OperationFilter;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerUI;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Linq;
using System.Reflection;
using WebSite.Core.Infrastructure.AutofacModules;


namespace WebSite.Core.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<IISOptions>(options =>
            {
                options.ForwardClientCertificate = false;
                options.AutomaticAuthentication = false;
            });
            // services.AddControllers();
            services.AddHttpClient();
            services.AddOptions();
            services.AddMemoryCache();
            services.AddResponseCaching();
            services.AddCors();
            // Add resources support
            services.AddMvcCore(options =>
            {
                options.Filters.Add(typeof(ModelStateFilter));
                options.Conventions.Add(new DefaultFromBodyBindingConvention());
                options.ModelBinderProviders.Insert(0, new DateTimeModelBinderProvider());
            })
               .AddAuthorization()
               .AddFluentValidation()
               .AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix, options => { options.ResourcesPath = "Resources"; })
               .AddDataAnnotationsLocalization();

            services.AddDataProtection().PersistKeysToFileSystem(new DirectoryInfo(Directory.GetCurrentDirectory()));

            services.AddAuthorization();

            services.AddAuthentication(IdentityServerAuthenticationDefaults.AuthenticationScheme)
             .AddIdentityServerAuthentication(options =>
             {
                 var authority = Configuration["ApiUrlSettings:Authority"];
                 options.Authority = !string.IsNullOrEmpty(authority) ? authority : "http://localhost:8001"; // auth server base endpoint (will use to search for disco doc)
                 options.RequireHttpsMetadata = false; // dev only!
                 options.ApiName = "GHM_NailSpa_Api"; // required audience of access tokens
                 options.ApiSecret = Configuration["ApiServiceInfo:ClientSecret"];
                 options.SupportedTokens = SupportedTokens.Both;
                 //options.EnableCaching = true;
                 //options.CacheDuration = TimeSpan.FromHours(1);
                 options.TokenRetriever = new Func<HttpRequest, string>(req =>
                 {
                     var fromHeader = TokenRetrieval.FromAuthorizationHeader();
                     var fromQuery = TokenRetrieval.FromQueryString();
                     return fromHeader(req) ?? fromQuery(req);
                 });
             });

            //services.AddControllers()
            //    .AddNewtonsoftJson();
            services.AddControllers()
                .AddNewtonsoftJson(options =>
                {
                    options.SerializerSettings.Converters.Add(new StringEnumConverter());
                    options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                });

            //services.AddSwaggerGenNewtonsoftSupport();

            services.AddSwaggerGen(options =>
            {

                //options.OperationFilter<MyHeaderFilter>();
                //options.OperationFilter<AuthorizeCheckOperationFilter>();
                options.EnableAnnotations();
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    //TermsOfService = "http://daotao.humg.edu.vn/",
                    Version = "v1",
                    Title = "NCKH-QLDA API",
                    Description = "HUMG NCKH Quản lý đồ án",
                    Contact = new OpenApiContact
                    {
                        Name = "HUMG",
                        Email = string.Empty,
                        Url = new Uri("http://daotao.humg.edu.vn/")
                    },
                    License = new OpenApiLicense
                    {
                        Name = "Về chúng tôi.",
                        Url = new Uri("http://daotao.humg.edu.vn/")
                    },
                    
                });


                options.AddFluentValidationRules();
                options.EnableAnnotations();

                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "JWT Authorization (Include \"Bearer\" before your auth token)",
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey

                });

                options.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer" }
                        }, new List<string>() }
                });

                options.OperationFilter<MyHeaderFilter>();
                options.OperationFilter<AuthorizeCheckOperationFilter>(); // Required to use access token

            });
        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterModule(new ApplicationModule(Configuration.GetConnectionString("WebsiteConnection")));
            builder.RegisterModule(new ValidationModule());

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            #region Allow Origins
            var allowOrigins = Configuration.GetSection("AllowOrigins")
                .GetChildren().Select(x => x.Value).ToArray();
            app.UseCors(builder =>
            {
                builder.WithOrigins(allowOrigins);
                builder.AllowAnyHeader();
                builder.AllowAnyMethod();
                builder.AllowCredentials();
            });
            #endregion

            JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();

            app.UseDefaultFiles();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "HUMG API V1");
                ////options.SwaggerEndpoint("/swagger/v2/swagger.json", "My API V2");
                options.RoutePrefix = "api";
                options.DocumentTitle = "NCKH Website Api";
                options.DisplayOperationId();
                options.DisplayRequestDuration();
                options.EnableDeepLinking();
                //options.MaxDisplayedTags(20);
                options.EnableFilter();
                options.ShowExtensions();
                options.DocExpansion(DocExpansion.None);
            });
            app.Map(pathMatch: "/Error", MiddlewareExtension.GHMError);
            app.GHMWelcome();
        }
    }
}
