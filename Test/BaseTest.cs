using SymblAISharp.Authentication;
using Microsoft.Extensions.Configuration;

namespace SymblAI.Test
{
    /// <summary>
    /// The Base Test class for all of the Unit Testing related aspects
    /// </summary>
    public class BaseTest
    {
        protected IConfigurationRoot configurationRoot;

        public BaseTest()
        {
            configurationRoot = new ConfigurationBuilder()
                .AddJsonFile("appSettings.json").Build();
        }

        protected AuthResponse GetAuthToken()
        {
            string appId = configurationRoot["appId"];
            string appSecret = configurationRoot["appSecret"];

            AuthenticationApi authentication = new AuthenticationApi();

            var authResponse = authentication.GetAuthToken(
                new AuthRequest
                {
                    type = "application",
                    appId = appId,
                    appSecret = appSecret
                });

            return authResponse;
        }
    }
}
