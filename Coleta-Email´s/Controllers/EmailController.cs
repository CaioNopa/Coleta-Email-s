using Coleta_Email_s.Models;
using ColetaEmail.Services.EmailService;
using Microsoft.AspNetCore.Mvc;

namespace Coleta_Email.Controllers
{
    public class EmailController : Controller
    {
        public async Task <ActionResult<List<EmailModel>>> Index([FromServices]IEmailInterface emailInterface, string? pesquisar)
        {
            if(pesquisar != null)
            {
                var registrosEmailsFiltro = await emailInterface.ListarEmails(pesquisar);

                return View(registrosEmailsFiltro);
            }
            var registrosEmails = await emailInterface.ListarEmails();



            return View(registrosEmails);
        }



        [HttpGet]
        public async Task<ActionResult<EmailModel>> DetalhesEmail([FromRoute] int id, [FromServices]IEmailInterface emailInterface)
        {
            var registroEmail = await emailInterface.ListarEmailPorId(id);
            
            return View(registroEmail);
        }

        [HttpPost]
        public async Task<ActionResult<EmailModel>> EnviarEmail(string enderecoEmail,string TextoEmail,string AssuntoEmail, int id, [FromServices] IEmailInterface emailInterface)
        {
            var email = await emailInterface.ListarEmailPorId(id);

            if(email.Status == false)
            {
                TempData["MensagemErro"] = "Não é possível encaminhar email pra um registro inativo";
                return View("DetalhesEmail", email);
            }
            if(TextoEmail==null || AssuntoEmail == null)
            {
                TempData["MensagemErro"] = "Insira um Assunto e um Corpo para o Email";
                return View("DetalhesEmail", email);

            }

            bool resultado = emailInterface.EnviarEmail(enderecoEmail, TextoEmail, AssuntoEmail);
            if(resultado == true)
            {
                TempData["MensagemSucesso"] = "Email Encaminhado Com Sucesso";

            }
            else
            {
                TempData["MensagemErro"] = "Ocorreu um Erro";
            }

            return RedirectToAction("Index");
        }
    }
}
