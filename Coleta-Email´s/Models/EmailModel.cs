using System.ComponentModel.DataAnnotations;

namespace Coleta_Email_s.Models
{
    public class EmailModel
    {
       
        public int Id { get; set; }
        [Required(ErrorMessage = "Insira o Nome!")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Insira o Email!")]
        public string Email { get; set; }
        public bool Status { get; set; } = true;
        public DateTime DataDeRegistro { get; set; } = DateTime.Now;

    }
}
