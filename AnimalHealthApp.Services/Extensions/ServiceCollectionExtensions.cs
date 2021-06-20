using AnimalHealthApp.Data.Absract;
using Microsoft.EntityFrameworkCore;
using AnimalHealthApp.Data.Concreate;
using AnimalHealthApp.Services.Abstract;
using AnimalHealthApp.Services.Concrete;
using AnimalHealthApp.Entities.Concrete;
using Microsoft.Extensions.DependencyInjection;
using AnimalHealthApp.Data.Concreate.EntityFramework.Contexts;

namespace AnimalHealthApp.Services.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection LoadMyServices(this IServiceCollection serviceCollection, string connectionString)
        {
            serviceCollection.AddDbContext<AnimalHealthAppContext>(options => options.UseSqlServer(connectionString));
            serviceCollection.AddIdentity<User, Role>(options =>
            {
                // User Password Options
                options.Password.RequireDigit = false; // TODO: Should passwords contain numbers or not? It will be done true when the test phase is over.
                options.Password.RequiredLength = 5;
                options.Password.RequiredUniqueChars = 0; // How many should there be? ', ?
                options.Password.RequireNonAlphanumeric = false; // If you set the top to 1, make this true
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                // User Username and Email Options
                options.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
                options.User.RequireUniqueEmail = true;
            }).AddEntityFrameworkStores<AnimalHealthAppContext>();
            serviceCollection.AddScoped<IUnitOfWork, UnitOfWork>();
            serviceCollection.AddScoped<IVeterinaryClinicService, VeterinaryClinicManager>();
            serviceCollection.AddScoped<IAnimalService, AnimalManager>();
            serviceCollection.AddScoped<IHealthInformationService, HealthInformationManager>();
            return serviceCollection;
        }
    }
}
