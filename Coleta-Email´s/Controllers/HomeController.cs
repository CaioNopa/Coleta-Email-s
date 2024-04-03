using Coleta_Email_s.Models;
using ColetaEmail.Services.EmailService;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Coleta_Email_s.Controllers
{
    public class HomeController : Controller
    {
     
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Agradecimento(EmailModel InfoRecebida)
        {
            return View(InfoRecebida);
        }

        [HttpPost]
        public async Task<IActionResult> SalvarDadosCliente([FromServices]IEmailInterface emailInterface,EmailModel InfoRecebida)
        {
            if(ModelState.IsValid)
            {
                var registrofeito = await emailInterface.SalvarDadosCliente(InfoRecebida);

                return View("Agradecimento", registrofeito);
            }
            else
            {
                return RedirectToAction("Index");

            }


        }

    }
}
