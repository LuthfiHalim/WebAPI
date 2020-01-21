using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using WebAPI.Database;
using Microsoft.EntityFrameworkCore;
using System.IO;
using System.Text;

namespace WebAPI
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
            services.AddControllers();
            services.AddDbContext<CoreDBContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
        }

        public static void Logging(Microsoft.AspNetCore.Http.HttpContext context, TextWriter textWriter)
        {
            textWriter.WriteLine($"[{DateTime.Now}{TimeZoneInfo.Local}] {context.Request.Scheme.ToUpper()} {context.Request.Method.ToUpper()} {context.Request.Host}{context.Request.Path}");
        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.Use(async (context, next) =>
            {
                using (StreamWriter sw = File.AppendText("log.txt"))
                {
                    Logging(context, sw);
                    if (context.Request.Method.ToUpper() == "POST")
                    {
                        using (StreamReader sr = new StreamReader(context.Request.Body, Encoding.UTF8, true, 1024, true))
                        {
                            //var bodi = await sr.ReadToEndAsync();
                            //sw.WriteLine(bodi);
                        }
                    }
                }
                await next();
            });

            //app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
