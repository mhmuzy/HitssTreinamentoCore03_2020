using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Projeto.Presentation.API.Models.Requests;
using Projeto.Presentation.API.Models.Response;
using Projeto.Presentation.API.Models.Responses;
using Projeto.Presentation.API.Repositories;

namespace Projeto.Presentation.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        //atributo
        private readonly ProdutoRepository produtoRepository;

        //construtor para injeção de dependência
        public ProdutoController(ProdutoRepository produtoRepository)
        {
            this.produtoRepository = produtoRepository;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CadastroProdutoResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Post(CadastroProdutoRequests requests)
        {
            var entity = new ProdutoEntity
            { 
                IdProduto = new Random().Next(999, 999999),
                Nome = requests.Nome,
                Preco = requests.Preco,
                Quantidade = requests.Quantidade
            };

            produtoRepository.Add(entity);

            var response = new CadastroProdutoResponse
            { 
                StatusCode = StatusCodes.Status200OK,
                Message = "Produto cadastrado com sucesso.",
                Data = entity
            };

            return Ok(response);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(EdicaoProdutoResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Put(EdicaoProdutoRequest request)
        {
            var entity = produtoRepository.GetById(request.IdProduto);

            //verificando se o produto não foi encontrado
            if (entity == null)
                return UnprocessableEntity();

            entity.Nome = request.Nome;
            entity.Preco = request.Preco;

            var response = new EdicaoProdutoResponse
            { 
                StatusCode = StatusCodes.Status200OK,
                Message = "Produto atualizado com sucesso."
            };

            return Ok(response);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ExclusaoProdutoResponse))]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Delete(int id)
        {
            var response = new ExclusaoProdutoResponse
            { 
                StatusCode = StatusCodes.Status200OK,
                Message = "Produto excluido com sucesso."
            };

            return Ok(response);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ConsultaProdutoResponse))]
        public IActionResult GetAll()
        {
            var response = new ConsultaProdutoResponse
            { 
                StatusCode = StatusCodes.Status200OK,
                Data = produtoRepository.GetAll()
            };

            return Ok(response);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ConsultaProdutoResponse))]
        public IActionResult GetById(int id)
        {
            var response = new ConsultaProdutoResponse
            { 
                StatusCode = StatusCodes.Status200OK,
                Data = new List<ProdutoEntity>()
            };

            response.Data.Add(produtoRepository.GetById(id));

            return Ok(response);
        }
    }
}
