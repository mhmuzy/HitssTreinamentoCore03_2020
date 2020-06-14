﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Projeto.Presentation.API.Repositories;

namespace Projeto.Presentation.API.Models.Response
{
    public class CadastroFornecedorResponse
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public FornecedorEntity Data { get; set; }
    }
}
