using MessageBird.Objects;
using MessageBird;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Managers
{
    public class DaltonMessageBird
    {

        public Verify TestMessageBird()
        {
            var client = Client.CreateDefault("YOUR_ACCESS_KEY");

            var optionalArguments = new VerifyOptionalArguments
            {
                Type = MessageType.Email,
                Originator = "verify@company.com"
                // The originator email domain needs to be set up as an email channel in your account at https://dashboard.messagebird.com/en/channels/
            };

            var verify = client.CreateVerify("client-email@example.com", optionalArguments);

            return verify;
        }
    }
}
