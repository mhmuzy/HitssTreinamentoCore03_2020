using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto.Presentation.API.Repositories
{
    public class FornecedorEntity
    {
        public int IdFornecedor { get; set; }
        public string Nome { get; set; }
        public string Cnpj { get; set; }

        #region Produtos

        public int IdProduto { get; set; }
        public List<ProdutoEntity> Produtos { get; set; }

        #endregion
    }
}
