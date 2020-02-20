using System;

using Microsoft.Extensions.DependencyInjection;

using R5T.Dacia;
using R5T.Lombardy;


namespace R5T.Suebia.Default
{
    public static class IServiceCollectionExtensions
    {
        /// <summary>
        /// Adds the <see cref="DefaultSecretsFilePathProvider"/> implementation of <see cref="ISecretsFilePathProvider"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceCollection AddDefaultSecretsFilePathProvider(this IServiceCollection services,
            ServiceAction<ISecretsDirectoryPathProvider> addSecretsDirectoryPathProvider,
            ServiceAction<IStringlyTypedPathOperator> addStringlyTypedPathOperator)
        {
            services
                .AddSingleton<ISecretsFilePathProvider, DefaultSecretsFilePathProvider>()
                .RunServiceAction(addSecretsDirectoryPathProvider)
                .RunServiceAction(addStringlyTypedPathOperator)
                ;

            return services;
        }

        /// <summary>
        /// Adds the <see cref="DefaultSecretsFilePathProvider"/> implementation of <see cref="ISecretsFilePathProvider"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static ServiceAction<ISecretsFilePathProvider> AddDefaultSecretsFilePathProviderAction(this IServiceCollection services,
            ServiceAction<ISecretsDirectoryPathProvider> addSecretsDirectoryPathProvider,
            ServiceAction<IStringlyTypedPathOperator> addStringlyTypedPathOperator)
        {
            var serviceAction = new ServiceAction<ISecretsFilePathProvider>(() => services.AddDefaultSecretsFilePathProvider(
                addSecretsDirectoryPathProvider,
                addStringlyTypedPathOperator));
            return serviceAction;
        }
    }
}
