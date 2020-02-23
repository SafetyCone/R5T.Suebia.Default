using System;

using Microsoft.Extensions.DependencyInjection;

using R5T.Dacia;
using R5T.Lombardy;


namespace R5T.Suebia.Default
{
    public static class IServiceCollectionExtensions
    {
        /// <summary>
        /// Adds the <see cref="DefaultSecretsDirectoryFilePathProvider"/> implementation of <see cref="ISecretsDirectoryFilePathProvider"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceCollection AddDefaultSecretsDirectoryFilePathProvider(this IServiceCollection services,
            ServiceAction<ISecretsDirectoryPathProvider> addSecretsDirectoryPathProvider,
            ServiceAction<IStringlyTypedPathOperator> addStringlyTypedPathOperator)
        {
            services
                .AddSingleton<ISecretsDirectoryFilePathProvider, DefaultSecretsDirectoryFilePathProvider>()
                .RunServiceAction(addSecretsDirectoryPathProvider)
                .RunServiceAction(addStringlyTypedPathOperator)
                ;

            return services;
        }

        /// <summary>
        /// Adds the <see cref="DefaultSecretsDirectoryFilePathProvider"/> implementation of <see cref="ISecretsDirectoryFilePathProvider"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static ServiceAction<ISecretsDirectoryFilePathProvider> AddDefaultSecretsDirectoryFilePathProviderAction(this IServiceCollection services,
            ServiceAction<ISecretsDirectoryPathProvider> addSecretsDirectoryPathProvider,
            ServiceAction<IStringlyTypedPathOperator> addStringlyTypedPathOperator)
        {
            var serviceAction = new ServiceAction<ISecretsDirectoryFilePathProvider>(() => services.AddDefaultSecretsDirectoryFilePathProvider(
                addSecretsDirectoryPathProvider,
                addStringlyTypedPathOperator));
            return serviceAction;
        }
    }
}
