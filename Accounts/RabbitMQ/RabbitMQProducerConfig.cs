using Microsoft.Extensions.Configuration;

namespace Accounts.RabbitMQ
{
    public class RabbitMQClientConfiguration
    {
        public string HostName { get; set; } //= "localhost",
        public string UserName { get; set; } //= "guest",
        public string Password { get; set; } //= "guest",
    }

    public static class RabbitMQClientConfigExtensions
    {
        private const string DefaultConfigKey = "RabbitMQ";

        public static RabbitMQClientConfiguration GetRabbitMQClientConfig(this IConfiguration configuration) =>
            configuration.GetRequiredSection(DefaultConfigKey).Get<RabbitMQClientConfiguration>()
                ?? throw new InvalidOperationException(
                   $"Configuration wasn't found for '${DefaultConfigKey}' key");

    }
}
