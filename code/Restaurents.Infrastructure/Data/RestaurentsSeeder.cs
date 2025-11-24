using System;
using Microsoft.AspNetCore.Identity;
using Restaurents.Domain.Constents;
using Restaurents.Domain.Entities;
using Restaurents.Infrastructure.Persistance;

namespace Restaurents.Infrastructure.Data;

public class RestaurentsSeeder(RestaurentDbContext context) : IRestaurentsSeeder
{
    public async Task Seed()
    {
        if (await context.Database.CanConnectAsync())
        {
            if (!context.Restaurents.Any())
            {
                var restaurents = GetRestaurents();
                context.Restaurents.AddRange(restaurents);
                await context.SaveChangesAsync();
            }

            if (!context.Roles.Any())
            {
                var roles = GetRoles();
                context.Roles.AddRange(roles);
                await context.SaveChangesAsync();
            }
        }


    }


    private IEnumerable<IdentityRole> GetRoles()
    {
        List<IdentityRole> roles = [
            new (UserRoles.Admin)
            {
                NormalizedName = UserRoles.Admin.ToUpper()
            },
            new (UserRoles.Owner)
            {
                NormalizedName = UserRoles.Owner.ToUpper()
            },
            new (UserRoles.User)
            {
                NormalizedName = UserRoles.User.ToUpper()
            },

        ];

        return roles;
    }

    public IEnumerable<Restaurent> GetRestaurents()
    {
        var restaurents = new List<Restaurent>
            {
                new Restaurent
                {
                    Name = "Spice Garden",
                    Description = "Authentic Indian cuisine with rich flavors.",
                    Category = "Indian",
                    HasDelivery = true,
                    ContactEmail = "contact@spicegarden.com",
                    ContactNumber = "9876543210",
                    CreatedAt = DateTime.UtcNow,
                    Address = new Address
                    {
                        Street = "MG Road",
                        City = "Hyderabad",
                        PostalCode = "500001"
                    },
                    OwnerId="9832afe5-dd9c-4f92-8095-76d91859e331"


                },
                new Restaurent
                {
                    Name = "Ocean Breeze",
                    Description = "Seafood restaurant with coastal vibes.",
                    Category = "Seafood",
                    HasDelivery = false,
                    ContactEmail = "hello@oceanbreeze.com",
                    ContactNumber = "9123456780",
                    CreatedAt = DateTime.UtcNow,
                    Address = new Address
                    {
                        Street = "Beach Road",
                        City = "Chennai",
                        PostalCode = "600004"
                    },
                    OwnerId="9832afe5-dd9c-4f92-8095-76d91859e331"

                },
                new Restaurent
                {
                    Name = "Green Bowl",
                    Description = "Healthy vegetarian and vegan meals.",
                    Category = "Vegan",
                    HasDelivery = true,
                    ContactEmail = "info@greenbowl.com",
                    ContactNumber = "9988776655",
                    CreatedAt = DateTime.UtcNow,
                    Address = new Address
                    {
                        Street = "Park Avenue",
                        City = "Bangalore",
                        PostalCode = "560001"
                    },
                    OwnerId="9832afe5-dd9c-4f92-8095-76d91859e331"

                },new Restaurent
                {
                    Name = "Urban Tadka",
                    Description = "Modern North Indian dishes with a fusion twist.",
                    Category = "Indian",
                    HasDelivery = true,
                    ContactEmail = "info@urbantadka.com",
                    ContactNumber = "9123456780",
                    CreatedAt = DateTime.UtcNow,
                    Address = new Address
                    {
                        Street = "Jubilee Hills",
                        City = "Hyderabad",
                        PostalCode = "500033"
                    },
                    OwnerId = "9832afe5-dd9c-4f92-8095-76d91859e331"
                },

                new Restaurent
                {
                    Name = "Dragon Wok",
                    Description = "Authentic Chinese cuisine with bold flavors.",
                    Category = "Chinese",
                    HasDelivery = true,
                    ContactEmail = "support@dragonwok.com",
                    ContactNumber = "9988776655",
                    CreatedAt = DateTime.UtcNow,
                    Address = new Address
                    {
                        Street = "Banjara Hills",
                        City = "Hyderabad",
                        PostalCode = "500034"
                    },
                    OwnerId = "9832afe5-dd9c-4f92-8095-76d91859e331"
                },

                new Restaurent
                {
                    Name = "Italiano Bistro",
                    Description = "Classic Italian pasta, pizza, and desserts.",
                    Category = "Italian",
                    HasDelivery = true,
                    ContactEmail = "hello@italianobistro.com",
                    ContactNumber = "9012345678",
                    CreatedAt = DateTime.UtcNow,
                    Address = new Address
                    {
                        Street = "Hitech City",
                        City = "Hyderabad",
                        PostalCode = "500081"
                    },
                    OwnerId = "9832afe5-dd9c-4f92-8095-76d91859e331"
                },

                new Restaurent
                {
                    Name = "Burger Hub",
                    Description = "Juicy handcrafted burgers with fresh ingredients.",
                    Category = "Fast Food",
                    HasDelivery = true,
                    ContactEmail = "orders@burgerhub.com",
                    ContactNumber = "9845632100",
                    CreatedAt = DateTime.UtcNow,
                    Address = new Address
                    {
                        Street = "Kukatpally",
                        City = "Hyderabad",
                        PostalCode = "500072"
                    },
                    OwnerId = "9832afe5-dd9c-4f92-8095-76d91859e331"
                },

                new Restaurent
                {
                    Name = "Sushi Maki",
                    Description = "Fresh sushi, sashimi, and Japanese delicacies.",
                    Category = "Japanese",
                    HasDelivery = false,
                    ContactEmail = "contact@sushimaki.com",
                    ContactNumber = "9876501234",
                    CreatedAt = DateTime.UtcNow,
                    Address = new Address
                    {
                        Street = "Gachibowli",
                        City = "Hyderabad",
                        PostalCode = "500032"
                    },
                    OwnerId = "9832afe5-dd9c-4f92-8095-76d91859e331"
                },

                new Restaurent
                {
                    Name = "Arabian Nights",
                    Description = "Traditional Middle Eastern flavors and grills.",
                    Category = "Arabian",
                    HasDelivery = true,
                    ContactEmail = "support@arabiannights.com",
                    ContactNumber = "9765423109",
                    CreatedAt = DateTime.UtcNow,
                    Address = new Address
                    {
                        Street = "Malakpet",
                        City = "Hyderabad",
                        PostalCode = "500036"
                    },
                    OwnerId = "9832afe5-dd9c-4f92-8095-76d91859e331"
                },

                new Restaurent
                {
                    Name = "Punjab Rasoi",
                    Description = "Traditional Punjabi dishes with home-style taste.",
                    Category = "Punjabi",
                    HasDelivery = true,
                    ContactEmail = "info@punjabrasoi.com",
                    ContactNumber = "9654321870",
                    CreatedAt = DateTime.UtcNow,
                    Address = new Address
                    {
                        Street = "Ameerpet",
                        City = "Hyderabad",
                        PostalCode = "500016"
                    },
                    OwnerId = "9832afe5-dd9c-4f92-8095-76d91859e331"
                },

                new Restaurent
                {
                    Name = "Green Leaf Cafe",
                    Description = "Healthy salads, smoothies, and vegan meals.",
                    Category = "Healthy",
                    HasDelivery = false,
                    ContactEmail = "care@greenleaf.com",
                    ContactNumber = "9321456789",
                    CreatedAt = DateTime.UtcNow,
                    Address = new Address
                    {
                        Street = "Madhapur",
                        City = "Hyderabad",
                        PostalCode = "500081"
                    },
                    OwnerId = "9832afe5-dd9c-4f92-8095-76d91859e331"
                },

                new Restaurent
                {
                    Name = "BBQ Delight",
                    Description = "Smoked barbeque, ribs and grilled platters.",
                    Category = "BBQ",
                    HasDelivery = true,
                    ContactEmail = "orders@bbqdelight.com",
                    ContactNumber = "9102837465",
                    CreatedAt = DateTime.UtcNow,
                    Address = new Address
                    {
                        Street = "Secunderabad",
                        City = "Hyderabad",
                        PostalCode = "500003"
                    },
                    OwnerId = "9832afe5-dd9c-4f92-8095-76d91859e331"
                },

                new Restaurent
                {
                    Name = "Tandoori Flames",
                    Description = "Authentic tandoor-cooked kebabs and breads.",
                    Category = "North Indian",
                    HasDelivery = true,
                    ContactEmail = "connect@tandooriflames.com",
                    ContactNumber = "9192837465",
                    CreatedAt = DateTime.UtcNow,
                    Address = new Address
                    {
                        Street = "Dilsukhnagar",
                        City = "Hyderabad",
                        PostalCode = "500060"
                    },
                    OwnerId = "9832afe5-dd9c-4f92-8095-76d91859e331"
                },

            };

        return restaurents;
    }

}
