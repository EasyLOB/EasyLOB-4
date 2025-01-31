using Microsoft.AspNet.Identity;
using System.Threading.Tasks;

namespace EasyLOB.Identity
{
    public class SmsService : IIdentityMessageService
    {
        public Task SendAsync(IdentityMessage message)
        {
            // Plug in your SMS service here to send a text message.
            EasyLOBHelper.GetService<IMailManager>()
                .Mail(null, message.Destination, message.Subject, message.Body, true);

            return Task.FromResult(0);
        }
    }
}