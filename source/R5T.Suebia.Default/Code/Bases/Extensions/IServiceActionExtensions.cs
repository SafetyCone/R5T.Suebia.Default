using System;

using Microsoft.Extensions.DependencyInjection;

using R5T.Lombardy;

using R5T.T0062;
using R5T.T0063;


namespace R5T.Suebia.Default
{
    public static class IServiceActionExtensions
    {
        /// <summary>
        /// Adds the <see cref="SecretsDirectoryFilePathProvider"/> implementation of <see cref="ISecretsDirectoryFilePathProvider"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceAction<ISecretsDirectoryFilePathProvider> AddSecretsDirectoryFilePathProviderAction(this IServiceAction _,
            IServiceAction<ISecretsDirectoryPathProvider> secretsDirectoryPathProviderAction,
            IServiceAction<IStringlyTypedPathOperator> stringlyTypedPathOperatorAction)
        {
            var serviceAction = _.New<ISecretsDirectoryFilePathProvider>(services => services.AddSecretsDirectoryFilePathProvider(
                secretsDirectoryPathProviderAction,
                stringlyTypedPathOperatorAction));

            return serviceAction;
        }
    }
}
