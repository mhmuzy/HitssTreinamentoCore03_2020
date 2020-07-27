using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Projeto.Presentation.API.Repositories;
using Projeto.Infra.Data.Entities;

namespace Projeto.Presentation.API.Models.Responses
{
    public class ConsultaProdutoResponse
    {
        public int StatusCode { get; set; }
        public List<Produto> Data { get; set; }
    }
}
