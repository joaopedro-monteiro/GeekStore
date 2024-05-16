using GeekStore.Core.Services.Accounts;

namespace GeekStore.Core.Config
{
    public static class SeedUserRoleInitialConfig
    {
        public static void RegisterSeedUserRoleInitialConfig(this IServiceCollection services)
        {
            services.AddScoped<ISeedUserRoleInitial, SeedUserRoleInitial>();
        }
    }
}
