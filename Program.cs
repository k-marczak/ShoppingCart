using Microsoft.EntityFrameworkCore;
using ShoppingCart.Infrastracture;
using ShoppingCart.Infrastructure;

namespace ShoppingCart
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<DataContext>(options =>
            {
                options.UseSqlServer(builder.Configuration["ConnectionStrings:DbConnection"]);
            });

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "products",
                pattern: "/products/{categorySlug?}",
                    defaults: new {controller = "Products", action = "Index" });


            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");


            var context = app.Services.CreateScope().ServiceProvider.GetRequiredService<DataContext>();
            SeedData.SeedDatabase(context);

            app.Run();
        }
    }
}