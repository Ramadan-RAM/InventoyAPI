using AngularERPApi.Data;
using AngularERPApi.Models;
using AngularERPApi.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json.Serialization;
using System.IO;
using System.Text;
using System.Text.Json.Serialization;

namespace AngularERPApi
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

            services.AddControllers().AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve);

            services.AddDbContext<ApplicationDbContext>(options =>
              options.UseSqlServer(Configuration.GetConnectionString("Con")));

            services.AddIdentity<ApplicationUser, IdentityRole>()
                    .AddEntityFrameworkStores<ApplicationDbContext>()
                     .AddDefaultTokenProviders();

            services.AddTransient<INumberSequence, Services.NumberSequence>();

            services.AddAuthentication(options =>
            {

                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;

            }).AddJwtBearer(options =>
            {
                options.SaveToken = true;
                options.RequireHttpsMetadata = false;
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidIssuer = Configuration["JWT:ValidIssuer"],
                    ValidAudience = Configuration["JWT:ValidAudience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JWT:SecretKey"]))
                };
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1",
                   new OpenApiInfo { 
                   Title = "AngularERPApi",
                   Version = "v1",
                   Description = "AngularERPApi with Authentication "
                   });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme() 
                {
                  Name = "Authorization",
                  Type= SecuritySchemeType.ApiKey,
                  Scheme = "Bearer",
                  BearerFormat = "JWT",
                  In = ParameterLocation.Header,
                  Description = "Enter `Bearer` [space] and then your valid token in the text input below.\r\n\r\nExample: \"Bearer dfsfswer22rweweerwwrryy\""
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        }
                           , new string[]{}
                    }
                
                });
            });

            // Enable CORS
            services.AddCors(c =>
            {
                c.AddPolicy("AllowOrigin", options => options.AllowAnyOrigin().AllowAnyMethod()
                .AllowAnyHeader());

            });


            //JSON Serializer
            services.AddControllersWithViews()
                .AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft
                .Json.ReferenceLoopHandling.Ignore)
                .AddNewtonsoftJson(options => options.SerializerSettings.ContractResolver
                = new DefaultContractResolver());

            // Enable  Us in CORS V. 6.0
            //services.AddCors((setup) =>
            //{
            //    setup.AddPolicy("default", (options) => {
            //        options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
            //    });
            //});


            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // Us in CORS V. 6.0
            //app.UseCors("default");

            app.UseCors(options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "AngularERPApi v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });


            app.UseStaticFiles(new StaticFileOptions
            {
              FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "uploadImg")),RequestPath = "/uploadImg",
            });


            app.UseStaticFiles(new StaticFileOptions
            {
               FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "uploadFile")),RequestPath = "/uploadFile",
            });

            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "prouductImg")),
                RequestPath = "/prouductImg",
            });

        }
    }
}
