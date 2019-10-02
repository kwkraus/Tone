using Microsoft.Extensions.DependencyInjection;
using System;
using Tone.LibraryManagement.Azure.Services.Options;
using Tone.LibraryManagement.Core.Services;

namespace Tone.LibraryManagement.Azure.Services.Extensions
{
    public static class AzureStorageServiceCollectionExtensions
    {
        public static void AddAzureStorageService(
            this IServiceCollection services, 
            Action<AzureStorageOptions> configureOptions)
        {
            //Options bound and configured by a delegate
            services.Configure<AzureStorageOptions>(configureOptions);
            services.AddTransient(typeof(IStorageService), typeof(AzureStorageService));
        }
    }
}
