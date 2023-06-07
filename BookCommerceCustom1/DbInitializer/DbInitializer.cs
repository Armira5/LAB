using BookCommerceCustom1.Data;
using BookCommerceCustom1.Helpers;
using BookCommerceCustom1.Models;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BookCommerceCustom1.DbInitializer
{
    public class DbInitializer:IDbInitializer
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly Konteksti _konteksti;

        public DbInitializer(
            UserManager<IdentityUser> userManager,
            RoleManager<IdentityRole> roleManager,
            Konteksti konteksti)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _konteksti = konteksti;
        }

        public void Initialize()
        {
            try
            {
                if (_konteksti.Database.GetPendingMigrations().Count()>0)
                {
                    _konteksti.Database.Migrate();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            if (!_roleManager.RoleExistsAsync(Sd.RoliAdmin).GetAwaiter().GetResult())
            {
                _roleManager.CreateAsync(new IdentityRole(Sd.RoliAdmin)).GetAwaiter().GetResult();
                _roleManager.CreateAsync(new IdentityRole(Sd.RoliPunetor)).GetAwaiter().GetResult();
                _roleManager.CreateAsync(new IdentityRole(Sd.RolePerdorusIndividual)).GetAwaiter().GetResult();
                _roleManager.CreateAsync(new IdentityRole(Sd.RolePerdorusKompani)).GetAwaiter().GetResult();

                _userManager.CreateAsync(new Perdorusi()
                {
                    UserName = "ak51925@ubt-uni.net",
                    Email = "ak51925@ubt-uni.net",
                    Emri = "Armira Krasniqi",
                    PhoneNumber = "045555555",
                    Rruga = "",
                    Shteti = "Kosove",
                    KodiPostal = "10000",
                    Qyteti = "Prishtine"
                },"Aab123456!").GetAwaiter().GetResult();

                Perdorusi perdorusi = _konteksti.Perdorusit.
                    FirstOrDefault(x => x.Email == "ak51925@ubt-uni.net");

                _userManager.AddToRoleAsync(perdorusi, Sd.RoliAdmin).GetAwaiter().GetResult();
            }
            return;
        }
    }
}
