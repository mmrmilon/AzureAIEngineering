using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI102ConsoleExercise
{
    public static class ReadUserSecrets
    {
        public static T ReadSecrets<T>(string serviceName)
        { 
            var builder = new ConfigurationBuilder()
                .AddUserSecrets<Program>()
                .Build();

            var secrets = builder.GetSection(serviceName);

            return secrets.Get<T>()!;
        }
    }
}
