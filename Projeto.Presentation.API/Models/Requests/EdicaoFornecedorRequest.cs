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

    }
}
