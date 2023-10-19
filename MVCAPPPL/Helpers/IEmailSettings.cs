using MVCAPPDAL.Models;

namespace MVCAPPPL.Helpers
{
    public interface IEmailSettings
    {
        public void SendEmail(Email email);
    }
}
