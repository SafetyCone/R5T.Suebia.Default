using System;

using R5T.Lombardy;


namespace R5T.Suebia.Default
{
    /// <summary>
    /// Provides secrets file paths using a <see cref="ISecretsDirectoryPathProvider"/> service.
    /// Assumes that secrets files are in the secrets directory directly.
    /// </summary>
    public class SecretsDirectoryFilePathProvider : ISecretsDirectoryFilePathProvider
    {
        public ISecretsDirectoryPathProvider SecretsDirectoryPathProvider { get; }
        public IStringlyTypedPathOperator StringlyTypedPathOperator { get; }


        public SecretsDirectoryFilePathProvider(ISecretsDirectoryPathProvider secretsDirectoryPathProvider, IStringlyTypedPathOperator stringlyTypedPathOperator)
        {
            this.SecretsDirectoryPathProvider = secretsDirectoryPathProvider;
            this.StringlyTypedPathOperator = stringlyTypedPathOperator;
        }

        public string GetSecretsFilePath(string fileName)
        {
            var secretsDirectoryPath = this.SecretsDirectoryPathProvider.GetSecretsDirectoryPath();

            var secretsFilePath = this.StringlyTypedPathOperator.GetFilePath(secretsDirectoryPath, fileName);
            return secretsFilePath;
        }
    }
}
