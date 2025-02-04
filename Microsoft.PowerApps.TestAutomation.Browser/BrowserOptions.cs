﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license.

using Microsoft.Win32;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using System;
using System.IO;
using OpenQA.Selenium;

namespace Microsoft.PowerApps.TestAutomation.Browser
{
    public class BrowserOptions
    {
        public BrowserOptions()
        {
            this.DriversPath = Path.Combine(Directory.GetCurrentDirectory()); //, @"Drivers\");
            this.BrowserType = BrowserType.Chrome;
            this.PageLoadTimeout = new TimeSpan(0, 3, 0);
            this.CommandTimeout = new TimeSpan(0, 10, 0);
            this.StartMaximized = true;
            this.FireEvents = false;
            this.TraceSource = Constants.DefaultTraceSource;
            this.EnableRecording = false;
            this.RecordingScanInterval = TimeSpan.FromMilliseconds(Constants.Browser.Recording.DefaultScanInterval);
            this.Credentials = BrowserCredentials.Default;
            this.HideDiagnosticWindow = true;
        }

        public BrowserType BrowserType { get; set; }
        public BrowserCredentials Credentials { get; set; }
        public string DriversPath { get; set; }
        public bool PrivateMode { get; set; }
        public bool CleanSession { get; set; }
        public TimeSpan PageLoadTimeout { get; set; }
        public TimeSpan CommandTimeout { get; set; }
        public bool StartMaximized { get; set; }
        public bool FireEvents { get; set; }
        public bool EnableRecording { get; set; }
        public TimeSpan RecordingScanInterval { get; set; }
        public string TraceSource { get; set; }
        public bool HideDiagnosticWindow { get; set; }
        public bool Headless { get; set; }
        public bool UserAgent { get; set; }
        public string UserAgentValue { get; set; }

        public virtual ChromeOptions ToChrome()
        {
            var options = new ChromeOptions();

            if (this.StartMaximized)
            {
                options.AddArgument("--start-maximized");
            }

            if (this.PrivateMode)
            {
                options.AddArgument("--incognito");
            }

            if (this.Headless)
            {
                options.AddArgument("--headless");
            }

            if (UserAgent && !string.IsNullOrEmpty(UserAgentValue))
            {
                options.AddArgument("--user-agent=" + UserAgentValue);
            }

            return options;
        }
       

        public  virtual FirefoxOptions ToFireFox()
        {
            var options = new FirefoxOptions()
            {
                UseLegacyImplementation = false
            };

            return options;
        }

        public virtual EdgeOptions ToEdge()
        {
            var options = new EdgeOptions()
            {
                PageLoadStrategy = PageLoadStrategy.Normal
            };

            return options;
        }
    }
}
