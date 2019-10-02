using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using Tone.LibraryManagement.AWS.Services;
using Tone.LibraryManagement.Azure.Services.Options;
using Tone.LibraryManagement.Core.Services;

namespace Tone.LibraryManagement.Azure.Services.Extensions
{
    public static class AWSStorageServiceCollectionExtensions
    {
        public static void AddAWSStorageService(
            this IServiceCollection services, 
            Action<AWSStorageOptions> configureOptions)
        {
            //Options bound and configured by a delegate
            services.Configure<AWSStorageOptions>(configureOptions);
            services.AddTransient(typeof(IStorageService), typeof(AWSStorageService));
        }

        public static void AddAWSStorageService(
            this IServiceCollection services,
            IConfigurationSection configureOptions)
        {
            //Options bound and configured by a delegate
            services.Configure<AWSStorageOptions>(configureOptions);
            services.AddTransient(typeof(IStorageService), typeof(AWSStorageService));
        }
    }
}
