﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Projeto.Presentation.API.Repositories;

namespace Projeto.Presentation.API.Models.Responses
{
    public class ExclusaoProdutoResponse
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public ProdutoEntity Data { get; set; }
    }
}
