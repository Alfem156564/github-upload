using Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAzure.Api
{
    internal class TestAzureConfig : ITestAzureConfig
    {
        public string DatabaseConnectionString => Environment.GetEnvironmentVariable("DefaultConnection");
    }
}
