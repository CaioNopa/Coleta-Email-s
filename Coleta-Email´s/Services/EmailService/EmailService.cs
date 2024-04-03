using Coleta_Email_s.Data;
using Coleta_Email_s.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Net.Mail;



namespace ColetaEmail.Services.EmailService
{
    public class EmailService : IEmailInterface
    {
        private readonly AppDbContext _context;
        private readonly IConfiguration _configuration;

        public EmailService(AppDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public bool EnviarEmail(string email, string mensagem, string assunto)
        {
            try
            {
                string host = _configuration.GetValue<string>("SMTP:Host");
                string nome = _configuration.GetValue<string>("SMTP:Nome");
                string username = _configuration.GetValue<string>("SMTP:Username");
                string senha = _configuration.GetValue<string>("SMTP:Senha");
                int porta = _configuration.GetValue<int>("SMTP:Porta");

                MailMessage mail = new MailMessage()
                {
                    From = new MailAddress(username, nome)
                };
                mail.To.Add(email);
                mail.Subject = assunto;
                mail.Body = mensagem;
                mail.IsBodyHtml = true;
                mail.Priority = MailPriority.High;

                using(SmtpClient smtp = new SmtpClient(host, porta))
                {
                    smtp.Credentials = new NetworkCredential(username, senha);
                    smtp.EnableSsl = true;
                    smtp.Send(mail);
                    return true;
                }
            }

            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<EmailModel> ListarEmailPorId(int id)
        {
            try
            {
                var registroEmail = await _context.Emails.FirstOrDefaultAsync(x => x.Id == id);


              return registroEmail;
            }
            
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public async Task<List<EmailModel>> ListarEmails(string pesquisar = null)
        {
            List<EmailModel> RegistroEmails = new List<EmailModel>();

            try
            {
                if (pesquisar == null)
                {
                    RegistroEmails = await _context.Emails.ToListAsync();
                }else
                {
                    RegistroEmails = await _context.Emails
                        .Where(email => email.Nome.Contains(pesquisar) || 
                                email.Email.Contains(pesquisar))
                        .ToListAsync();
                }


                return RegistroEmails;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<EmailModel> SalvarDadosCliente(EmailModel InfoRecebida)
        {
            try
            {
                _context.Add(InfoRecebida);
                await _context.SaveChangesAsync();

                return (InfoRecebida);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    
    }
}
