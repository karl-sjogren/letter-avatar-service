using Amazon.Extensions.NETCore.Setup;
using Amazon.Runtime;
using Microsoft.Extensions.Configuration;

namespace LetterAvatarService.Extensions {
    public static class ConfigurationExtensions {
        public static AWSOptions GetAWSOptionsWithCredentials(this IConfiguration config) {
            var options = config.GetAWSOptions();

            var accessKey = config["AWS:AccessKey"];
            var secretKey = config["AWS:SecretKey"];
            if(!string.IsNullOrWhiteSpace(accessKey) && !string.IsNullOrWhiteSpace(secretKey)) {
                options.Credentials = new BasicAWSCredentials(accessKey, secretKey);
            }

            return options;
        }
    }
}
