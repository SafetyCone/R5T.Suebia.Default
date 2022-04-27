using System;

using Microsoft.Extensions.DependencyInjection;

using R5T.Dacia;
using R5T.Lombardy;


namespace R5T.Suebia.Default
{
    public static partial class IServiceCollectionExtensions
    {
        /// <summary>
        /// Adds the <see cref="SecretsDirectoryFilePathProvider"/> implementation of <see cref="ISecretsDirectoryFilePathProvider"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceCollection AddSecretsDirectoryFilePathProvider_Old(this IServiceCollection services,
            IServiceAction<ISecretsDirectoryPathProvider> secretsDirectoryPathProviderAction,
            IServiceAction<IStringlyTypedPathOperator> stringlyTypedPathOperatorAction)
        {
            services
                .AddSingleton<ISecretsDirectoryFilePathProvider, SecretsDirectoryFilePathProvider>()
                .RunServiceAction(secretsDirectoryPathProviderAction)
                .RunServiceAction(stringlyTypedPathOperatorAction)
                ;

            return services;
        }

        /// <summary>
        /// Adds the <see cref="SecretsDirectoryFilePathProvider"/> implementation of <see cref="ISecretsDirectoryFilePathProvider"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceAction<ISecretsDirectoryFilePathProvider> AddSecretsDirectoryFilePathProviderAction_Old(this IServiceCollection services,
            IServiceAction<ISecretsDirectoryPathProvider> secretsDirectoryPathProviderAction,
            IServiceAction<IStringlyTypedPathOperator> sringlyTypedPathOperatorAction)
        {
            var serviceAction = new ServiceAction<ISecretsDirectoryFilePathProvider>(() => services.AddSecretsDirectoryFilePathProvider_Old(
                secretsDirectoryPathProviderAction,
                sringlyTypedPathOperatorAction));
            return serviceAction;
        }
    }
}
