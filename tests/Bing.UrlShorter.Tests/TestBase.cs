﻿using Xunit.Abstractions;

namespace Bing.UrlShorter.Tests
{
    public class TestBase
    {
        protected ITestOutputHelper Output;

        public TestBase(ITestOutputHelper output)
        {
            Output = output;
        }
    }
}
