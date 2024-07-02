namespace GeekStore.Core.Config
{
    public static class RoutesConfig
    {
        public static void RegisterRoutes(this IServiceCollection services) 
        {
            services.AddRazorPages(options =>
            {
                options.Conventions.AddPageRoute("/Application/Clientes/Pages/Index", "Clientes/Index");
                options.Conventions.AddPageRoute("/Application/Clientes/Pages/Create", "Clientes/Create");
                options.Conventions.AddPageRoute("/Application/Clientes/Pages/Edit", "Clientes/Edit");
                options.Conventions.AddPageRoute("/Application/Clientes/Pages/Delete", "Clientes/Delete");
            });
        }
    }
}
