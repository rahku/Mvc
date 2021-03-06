// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Runtime.Versioning;
using Microsoft.Dnx.Runtime;

namespace Microsoft.AspNet.Mvc.FunctionalTests
{
    // An application environment that overrides the base path of the original
    // application environment in order to make it point to the folder of the original web
    // aaplication so that components like ViewEngines can find views as if they were executing
    // in a regular context.
    public class TestApplicationEnvironment : IApplicationEnvironment
    {
        private readonly IApplicationEnvironment _original;

        public TestApplicationEnvironment(IApplicationEnvironment original, string name, string basePath)
        {
            _original = original;
            ApplicationName = name;
            ApplicationBasePath = basePath;
        }

        public string ApplicationName { get; }

        public string ApplicationVersion
        {
            get
            {
                return _original.ApplicationVersion;
            }
        }

        public string ApplicationBasePath { get; }

        public string Configuration
        {
            get
            {
                return _original.Configuration;
            }
        }

        public FrameworkName RuntimeFramework
        {
            get
            {
                return _original.RuntimeFramework;
            }
        }

        public object GetData(string name)
        {
            return _original.GetData(name);
        }

        public void SetData(string name, object value)
        {
            _original.SetData(name, value);
        }
    }
}