using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations; //validações

namespace Projeto.Presentation.API.Models.Requests
{
    public class CadastroProdutoRequests
    {
        [MinLength(6, ErrorMessage = "Por favor, informe no mínimo {1} caracteres.")]
        [MaxLength(150, ErrorMessage = "Por favor, informe no máximo {1} caracteres.")]
        [Required(ErrorMessage = "Por favor, informe o nome do fornecedor.")]
        public string Nome { get; set; }
    }
}
