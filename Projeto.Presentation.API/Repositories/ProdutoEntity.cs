using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto.Presentation.API.Repositories
{
    public class ProdutoEntity
    {
        public int IdProduto { get; set; }
        public string Nome { get; set; }
        public double Preco { get; set; }
        public int Quantidade { get; set; }

        #region Fornecedor

        public int IdFornecedor { get; set; }
        public FornecedorEntity Fornecedor { get; set; }

        #endregion
    }
}
