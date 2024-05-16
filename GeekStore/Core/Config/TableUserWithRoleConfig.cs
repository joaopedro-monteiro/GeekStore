using GeekStore.Areas.Admin.Services.Tables;

namespace GeekStore.Core.Config
{
    public static class TableUserWithRoleConfig
    {
        public static void RegisterTableUserWithRoleConfig(this IServiceCollection services)
        {
            services.AddScoped<ITableUsersWithRoles, TableUsersWithRoles>();
        }
    }
}
