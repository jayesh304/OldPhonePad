namespace OldPhonePad.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection RegisterServices(this IServiceCollection services)
    {
        services.AddScoped<IOldPhonePadService, OldPhonePadService>();
        return services;
    }
}
