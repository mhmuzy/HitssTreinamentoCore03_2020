using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Projeto.Infra.Data.Entities
{
    public class Fornecedor
    {
        public int IdFornecedor { get; set; }
        public string Nome { get; set; }
        public string Cnpj { get; set; }

        //Associação com a Tabela Produtos 1 - N
        //#region Produtos 

        //public int IdProduto { get; set; }

        //public List<Produto> Produtos { get; set; }

        //#endregion
    }
}
