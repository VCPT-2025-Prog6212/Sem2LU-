using Identity_MVC_Demo.Data; // Importing the ApplicationDbContext class from the project
using Microsoft.AspNetCore.Identity; // Provides classes for ASP.NET Core Identity
using Microsoft.EntityFrameworkCore; // Enables Entity Framework Core features

namespace Identity_MVC_Demo
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            // Creating a new WebApplication builder to configure the application
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the dependency injection container.
            // Retrieve the connection string from configuration (appsettings.json or environment variables)
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
                                   ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

            // Register the DbContext with SQL Server support
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connectionString));

            // Adds a developer exception filter to display detailed error pages for EF Core migrations
            builder.Services.AddDatabaseDeveloperPageExceptionFilter();

            // Configures ASP.NET Core Identity with default settings
            // No email confirmation required for sign-in
            builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = false)
                .AddRoles<IdentityRole>() // Enables support for roles
                .AddEntityFrameworkStores<ApplicationDbContext>(); // Uses EF Core for user store

            // Adds support for MVC controllers and views
            builder.Services.AddControllersWithViews();

            // Build the web application based on the services configured
            var app = builder.Build();

            // Configure the request pipeline based on the environment (development or production)
            if (app.Environment.IsDevelopment())
            {
                // Enables migration endpoint if in development mode
                app.UseMigrationsEndPoint();
            }
            else
            {
                // Use a custom error page in production for unhandled exceptions
                app.UseExceptionHandler("/Home/Error");

                // Enforces HTTP Strict Transport Security (HSTS) for production environments
                app.UseHsts();
            }

            // Redirects HTTP requests to HTTPS
            app.UseHttpsRedirection();

            // Serve static files (e.g., CSS, JavaScript, images)
            app.UseStaticFiles();

            // Adds routing middleware to route incoming requests
            app.UseRouting();

            // Adds authorization middleware (authentication & role-based authorization)
            app.UseAuthorization();

            // Configures a default route pattern for controller actions
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            // Maps Razor Pages (for Identity scaffolding or custom Razor pages)
            app.MapRazorPages();

            // Creates a scope for service resolution to initialize roles
            using (var scope = app.Services.CreateScope())
            {
                // Resolves RoleManager to manage roles
                var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
                var roles = new[] { "Admin", "Manager", "Member" }; // Array of roles to be created

                // Loop through each role and create it if it doesn't already exist
                foreach (var role in roles)
                {
                    if (!await roleManager.RoleExistsAsync(role)) // Check if the role exists
                        await roleManager.CreateAsync(new IdentityRole(role)); // Create the role if not found
                }
            }

            // Creates another scope to initialize a default admin user
            using (var scope = app.Services.CreateScope())
            {
                // Resolves UserManager to manage user accounts
                var userManager = scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();

                string email = "admin@admin.com"; // Admin email address
                string password = "Welcome123!"; // Admin account password

                // Check if the admin user already exists
                if (await userManager.FindByEmailAsync(email) == null)
                {
                    var user = new IdentityUser(); // Create a new IdentityUser object
                    user.UserName = email; // Set the username to the email
                    user.Email = email; // Set the email address

                    // Create the user with the specified password
                    await userManager.CreateAsync(user, password);

                    // Add the user to the "Admin" role
                    await userManager.AddToRoleAsync(user, "Admin");
                }
            }

            // Start the web application and listen for incoming requests
            app.Run();
        }
    }
}
