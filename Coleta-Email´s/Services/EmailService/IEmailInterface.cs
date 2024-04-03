using Coleta_Email_s.Models;

namespace ColetaEmail.Services.EmailService
{
    public interface IEmailInterface
    {
       
        Task<EmailModel> SalvarDadosCliente(EmailModel InfoRecebida);
        Task<List<EmailModel>> ListarEmails(string pesquisar = null);
        Task<EmailModel> ListarEmailPorId(int  id);

        bool EnviarEmail(string email, string mensagem, string assunto);

    }
}
