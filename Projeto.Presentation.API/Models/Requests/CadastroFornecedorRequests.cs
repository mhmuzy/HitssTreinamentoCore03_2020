using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations; //validações

namespace Projeto.Presentation.API.Models.Requests
{
    public class CadastroFornecedorRequests
    {
        [MinLength(6, ErrorMessage = "Por favor, informe no mínimo {1} caracteres.")]
        [MaxLength(150, ErrorMessage = "Por favor, informe no máximo {1} caracteres.")]
        [Required(ErrorMessage = "Por favor, informe o nome do fornecedor.")]
        public string Nome { get; set; }

        [MinLength(14, ErrorMessage = "Por favor, informe o Cnpj em {1} caracteres.")]
        [MaxLength(14)]
        public string Cnpj { get; set; }
    }
}
