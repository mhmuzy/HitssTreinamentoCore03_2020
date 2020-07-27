﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Projeto.Presentation.API.Repositories;
using Projeto.Infra.Data.Entities;

namespace Projeto.Presentation.API.Models.Responses
{
    public class ExclusaoFornecedorResponse
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public Fornecedor Data { get; set; }
    }
}
