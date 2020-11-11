﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.Infra.Data.Entities
{
    public class Cliente
    {
        public int IdCliente { get; set; }

        public string Nome { get; set; }

        public string Cpf { get; set; }
        public DateTime DataNascimento { get; set; }

        public int IdFuncionario { get; set; }
    }
}
