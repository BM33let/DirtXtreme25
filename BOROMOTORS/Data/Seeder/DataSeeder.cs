using BOROMOTORS.Models;
using Microsoft.AspNetCore.Identity;

namespace BOROMOTORS.Data.Seeder
{
    public static class DataSeeder
    {
        public static async Task Initialize(IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = serviceProvider.GetRequiredService<UserManager<IdentityUser>>();
            var context = serviceProvider.GetRequiredService<ApplicationDbContext>();
            await SeedRoles(roleManager);
            await SeedUsers(userManager, roleManager);
            await SeedBikes(context);
            await SeedReviews(context);
        }

        private static async Task SeedReviews(ApplicationDbContext context)
        {
            List<Review> reviews = new List<Review>() { 
            new Review() { Author ="lidia alpha", Description="Невероятно!",ImageUrl="/images/download (9).jpg"},
            new Review() { Author ="Анна Иванова", Description="Най-добрите мотори, които съм карала!",ImageUrl="/images/download%20(1).jpg"},
            new Review() { Author ="Петър Димитров", Description="Прекрасно изживяване на пътя, напълно доволен!",ImageUrl="/images/images.jpg"},
            new Review() { Author ="Димитър Георгиев", Description="Моторите са супер, подходящи за всякакви терени!",ImageUrl="/images/images%20(1).jpg"},
            new Review() { Author ="Иван Димитров", Description="Това беше най-доброто решение за мен!",ImageUrl="/images/images%20(2).jpg"},
            new Review() { Author ="Петър Минков", Description="Препоръчвам го на всички, които обичат приключения!",ImageUrl="/images/download%20(3).jpg"},
            new Review() { Author ="Марин Георгиев", Description="Безопасни и мощни мотори. Много съм доволен!",ImageUrl="/images/images%20(4).jpg"},
            new Review() { Author ="Борис Димитров", Description="Моторите са невероятни, отлично качество!",ImageUrl="/images/images%20(5).jpg"},

            }; 
            if (context.Review.Count() == 0)
            {
                await context.Review.AddRangeAsync(reviews);
                await context.SaveChangesAsync();
            }
        }

        private static async Task SeedBikes(ApplicationDbContext context)
        {
            List<DirtBike> dirtBikes = new List<DirtBike>
{
    new DirtBike {
        Model = "Honda CRF450R", Manufacturer = "Honda", Price = 9599, Horsepower = 55,
        Weight = 244, TopSpeed = "90 mph", Year = 2023,
        Description = "Known for its excellent handling and stability...",
        ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTIq835m0k5UNvtfnO0Lu0bjaygM4PPvi0B3A&s" },

    new DirtBike {
        Model = "Yamaha YZ450F", Manufacturer = "Yamaha", Price = 9799, Horsepower = 58,
        Weight = 245, TopSpeed = "85 mph", Year = 2022,
        Description = "Equipped with Yamaha’s Power Tuner app...",
        ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTGnX7RJZb_nIfqsaVf4YAYMhUAXQFlycVHeQ&s" },

    new DirtBike {
        Model = "KTM 250 SX-F", Manufacturer = "KTM", Price = 8499, Horsepower = 47,
        Weight = 231, TopSpeed = "85 mph", Year = 2022,
        Description = "The KTM 250 SX-F offers a powerful engine...",
        ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTwtcH6NyzcY5p8Wcio6V79DarvsseMdyC1YQ&s" },

    new DirtBike {
        Model = "Kawasaki KX250", Manufacturer = "Kawasaki", Price = 7799, Horsepower = 47,
        Weight = 234, TopSpeed = "82 mph", Year = 2021,
        Description = "The Kawasaki KX250 is designed with high-performance riders...",
        ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTYBUBN8gtmNfzSFru9CKIF6rw15C7ixLdThA&s" },

    new DirtBike {
        Model = "Suzuki RMX450Z", Manufacturer = "Suzuki", Price = 8699, Horsepower = 51,
        Weight = 258, TopSpeed = "85 mph", Year = 2020,
        Description = "The RMX450Z is an enduro-focused bike...",
        ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSHWgFgoZLAzrBuQ2X5lzWSl3VdnpCT1pXipQ&s" },

    new DirtBike {
        Model = "KTM 300 XC-W", Manufacturer = "KTM", Price = 9099, Horsepower = 55,
        Weight = 233, TopSpeed = "87 mph", Year = 2023,
        Description = "The KTM 300 XC-W is known for high power-to-weight...",
        ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRD6kdGeAwWtIW1wb_ZygShYLLvGsMPpybokw&s" },

    new DirtBike {
        Model = "Yamaha WR250F", Manufacturer = "Yamaha", Price = 8599, Horsepower = 44,
        Weight = 245, TopSpeed = "85 mph", Year = 2021,
        Description = "The WR250F is an exceptional enduro bike...",
        ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcT3btyu1_WLesvmf_RX1Y_zvAaZm8Yp8GoV8Q&s" },

    new DirtBike {
        Model = "Beta 300 RR", Manufacturer = "Beta", Price = 9299, Horsepower = 50,
        Weight = 235, TopSpeed = "85 mph", Year = 2020,
        Description = "The Beta 300 RR is an agile and powerful two-stroke...",
        ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSW3GnLeBi-Gn8gXOUOCoQsDpknvj9T-x9v2Q&s" },

    new DirtBike {
        Model = "Sherco 300 SE-R", Manufacturer = "Sherco", Price = 9699, Horsepower = 50,
        Weight = 239, TopSpeed = "86 mph", Year = 2022,
        Description = "The Sherco 300 SE-R is built for extreme conditions...",
        ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQVFc144i4PTsjDYZq9wsRVl8D205bKNEzUFQ&s" }
};


            if (context.DirtBikes.Count() == 0)
            {
                await context.DirtBikes.AddRangeAsync(dirtBikes);
                await context.SaveChangesAsync();
            }
        }

        private static async Task SeedUsers(UserManager<IdentityUser>? userManager, RoleManager<IdentityRole> roleManager)
        {
            var adminUser = new IdentityUser()
            {
                UserName = "admin@admin.com",
                Email = "admin@admin.com",
                EmailConfirmed = true
            };
            string password = "Admin1!";
            var user = await userManager.FindByEmailAsync(adminUser.Email);
            if (user == null)
            {
                var created = await userManager.CreateAsync(adminUser, password);
                if (created.Succeeded)
                {
                    await userManager.AddToRoleAsync(adminUser, "Admin");
                }
            }

            var regularUser = new IdentityUser()
            {
                UserName = "user@user.com",
                Email = "user@user.com",
                EmailConfirmed = true
            };
            var userPassword = "User1!";
            var regularUserExist = await userManager.FindByEmailAsync(regularUser.Email);
            if (regularUserExist == null)
            {

                var created = await userManager.CreateAsync(regularUser, userPassword);
                if (created.Succeeded)
                {
                    await userManager.AddToRoleAsync(regularUser, "User");
                }
            }

        }


        private static async Task SeedRoles(RoleManager<IdentityRole> roleManager)
        {
            string[] roleNames = { "Admin", "User" };
            foreach (var roleName in roleNames)
            {
                bool roleExist = await roleManager.RoleExistsAsync(roleName);
                if (!roleExist)
                {
                    await roleManager.CreateAsync(new IdentityRole(roleName));
                }
            }
        }
    }
}

