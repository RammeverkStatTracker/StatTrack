﻿using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel;

namespace StatTrack
{

class AppConfig
{
        private readonly IConfigurationRoot _configurationRoot;
        public AppConfig() {
            var builder = new ConfigurationBuilder()
            .SetBasePath(Package.Current.InstalledLocation.Path)
            .AddJsonFile("statTrackerDB.json", optional: false);

            _configurationRoot = builder.Build();

        }

}
}
