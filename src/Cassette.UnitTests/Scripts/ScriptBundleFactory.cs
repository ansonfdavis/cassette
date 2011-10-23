﻿#region License
/*
Copyright 2011 Andrew Davey

This file is part of Cassette.

Cassette is free software: you can redistribute it and/or modify it under the 
terms of the GNU General Public License as published by the Free Software 
Foundation, either version 3 of the License, or (at your option) any later 
version.

Cassette is distributed in the hope that it will be useful, but WITHOUT ANY 
WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS 
FOR A PARTICULAR PURPOSE. See the GNU General Public License for more details.

You should have received a copy of the GNU General Public License along with 
Cassette. If not, see http://www.gnu.org/licenses/.
*/
#endregion

using Should;
using Xunit;

namespace Cassette.Scripts
{
    public class ScriptBundleFactory_Tests
    {
        [Fact]
        public void CreateBundleReturnsScriptBundle()
        {
            var factory = new ScriptBundleFactory();
            var bundle = factory.CreateBundle("~/test", null);
            bundle.ShouldBeType<ScriptBundle>();
        }

        [Fact]
        public void CreateBundleAssignsScriptBundleDirectory()
        {
            var factory = new ScriptBundleFactory();
            var bundle = factory.CreateBundle("~/test", null);
            bundle.Path.ShouldEqual("~/test");
        }

        [Fact]
        public void CreateBundleWithUrlCreatesExternalScriptBundle()
        {
            new ScriptBundleFactory().CreateBundle("http://test.com/api.js", null).ShouldBeType<ExternalScriptBundle>();
        }

        [Fact]
        public void GivenBundleDescriptorWithExternalUrl_WhenCreateWithApplicationRelativePath_ThenExternalScriptBundleIsReturned()
        {
            var descriptor = new BundleDescriptor(
                new[] { "*" },
                new string[0],
                "http://test.com/api.js",
                null
            );
            var bundle = new ScriptBundleFactory().CreateBundle("~/path", descriptor);

            bundle.ShouldBeType<ExternalScriptBundle>();
        }
    }
}

