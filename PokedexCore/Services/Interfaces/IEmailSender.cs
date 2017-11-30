using System.Threading.Tasks;

namespace PokedexCore.Services.Interfaces {
    public interface IEmailSender
    {
        Task SendEmailAsync(string email, string subject, string message);
    }
}
