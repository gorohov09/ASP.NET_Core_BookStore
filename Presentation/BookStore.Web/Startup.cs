using BookStore.Domain.Interfaces;
using BookStore.Domain.Services;
using BookStore.Memory;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace BookStore.Web
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
            services.AddControllersWithViews();
            services.AddDistributedMemoryCache();
            //Добавление и настройка сессий
            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(20); //Время жизни сессии
                options.Cookie.HttpOnly = true; //Доступ к кукам осуществляется только сервером
                options.Cookie.IsEssential = true;
            });

            services.AddSingleton<IBookRepository, BookRepository>();
            services.AddSingleton<IOrderRepository, OrderRepository>();
            services.AddSingleton<BookService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseSession(); //Включить сессии

            app.UseEndpoints(endpoints =>
            {
                //controller/action/{id}
                //book/index
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
