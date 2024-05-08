using GeekStore.Core.Data.Context;

namespace GeekStore.Core.Config
{
    public static class DataBaseConfig
    {
        public static void RegisterDatabase(this IServiceCollection services)
        {
            services.AddDbContext<GeekStoreDbContext>();
        }
    }
}
