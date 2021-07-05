using InterviewPrep.CSV.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace InterviewPrep.CSV.Helper
{
    public sealed class ConfigHelper
    {
        private readonly IConfigurationBuilder Builder;
        private readonly IConfiguration Config;
        private static readonly Lazy<ConfigHelper> lazy = new Lazy<ConfigHelper>(() => new ConfigHelper());
        public static ConfigHelper Instance { get { return lazy.Value; } }
        private ConfigHelper()
        {
            Builder = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("config.json", optional: false);
            Config = Builder.Build();
        }
        public AppConfiguration GetAppConfig()
        {
            return Config.GetSection("AppConfiguration").Get<AppConfiguration>();
        }
    }
}
