using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Projeto.Presentation.API.Repositories;

namespace Projeto.Presentation.API.Models.Responses
{
    public class ConsultaFornecedorResponse
    {
        public int StatusCode { get; set; }
        public List<FornecedorEntity> Data { get; set; }
    }
}
