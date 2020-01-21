﻿//
// Settings.cs
//
// Author:
//       Godwin peter .O <me@godwin.dev>
//
// Copyright (c) 2020 MIT 
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.
using System;
using System.IO;
using Microsoft.Extensions.Configuration;

namespace uhf_rfid_catch.Helpers
{
    public class ConfigContext
    {
#if DEBUG
        private const String Filepath = "appsettings.Development.json";
#endif
#if !DEBUG
        private const String Filepath = "appsettings.json";
#endif
        public ConfigContext()
        { }

        public string Resolve(String settingPath)
        {
            if(String.IsNullOrEmpty(CheckConfig(settingPath)))
            {
                return "null";
            }
            return CheckConfig(settingPath);
        }

        private string CheckConfig(String param)
        {
            var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile(Filepath);

            IConfiguration rootConfig = builder.Build();

            return rootConfig[param];
        }
    }
}