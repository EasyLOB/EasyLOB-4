using Microsoft.AspNet.Identity;
using System.Threading.Tasks;

namespace EasyLOB.Identity
{
    public class EmailService : IIdentityMessageService
    {
        public Task SendAsync(IdentityMessage message)
        {
            // Plug in your email service here to send an email.
            EasyLOBHelper.GetService<IMailManager>()
                .Mail(null, message.Destination, message.Subject, message.Body, true);

            return Task.FromResult(0);
        }
    }
}