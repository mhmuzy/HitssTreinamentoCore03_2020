using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Projeto.Presentation.API.Models.Requests
{
    public class EdicaoFornecedorRequest
    {
        [Required(ErrorMessage = "Por favor, informe o id do fornecedor.")]
        public int IdFornecedor { get; set; }
        
        [MinLength(6, ErrorMessage = "Por favor, informe no mínimo {1} caracteres.")]
        [MaxLength(150, ErrorMessage = "Por favor, informe no máximo {1} caracteres.")]
        [Required(ErrorMessage = "Por favor, informe o nome do fornecedeor.")]
        public string Nome { get; set; }

        [MinLength(14, ErrorMessage = "Por favor informe o cnpj do fornecedor em {1} caracteres.")]
        [MaxLength(14)]
        [Required(ErrorMessage = "Por favor, informe o cnpj do fornecedor.")]
        public string Cnpj { get; set; }
    }
}
