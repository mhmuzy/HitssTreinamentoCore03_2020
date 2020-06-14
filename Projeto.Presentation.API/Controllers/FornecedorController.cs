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
    public class FornecedorController : ControllerBase
    {
        //atributo
        private readonly FornecedorRepository fornecedorRepository;

        //construtor para injeção de dependência
        public FornecedorController(FornecedorRepository fornecedorRepository)
        {
            this.fornecedorRepository = fornecedorRepository;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CadastroFornecedorResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Post(CadastroFornecedorRequests requests)
        {
            var entity = new FornecedorEntity
            { 
                IdFornecedor = new Random().Next(999, 999999),
                Nome =  requests.Nome,
                Cnpj = requests.Cnpj
            };

            fornecedorRepository.Add(entity);

            var response = new CadastroFornecedorResponse
            { 
                StatusCode = StatusCodes.Status200OK,
                Message = "Fornecedor cadastrado com sucesso.",
                Data = entity
            };

            return Ok(response);    
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(EdicaoFornecedorResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Put(EdicaoFornecedorRequest request)
        {
            var entity = fornecedorRepository.GetById(request.IdFornecedor);

            //verificando se o fornecedor não foi encontrado
            if (entity == null)
                return UnprocessableEntity();

            entity.Nome = request.Nome;
            entity.Cnpj = request.Cnpj;

            var response = new EdicaoFornecedorResponse
            { 
                StatusCode = StatusCodes.Status200OK,
                Message = "Fornecedor atualizado com sucesso.",
                Data = entity
            };

            return Ok(response);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ExclusaoFornecedorResponse))]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Delete(int id)
        {
            var entity = fornecedorRepository.GetById(id);

            //verificando se o fornecedor não foi encontrado
            if (entity == null)
                return UnprocessableEntity();

            fornecedorRepository.Remove(entity);

            var response = new ExclusaoFornecedorResponse
            { 
                StatusCode = StatusCodes.Status200OK,
                Message = "Fornecedor excluído com sucesso.",
                Data = entity
            };

            return Ok(response);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ConsultaFornecedorResponse))]
        public IActionResult GetAtt()
        {
            var response = new ConsultaFornecedorResponse
            { 
                StatusCode = StatusCodes.Status200OK,
                Data = fornecedorRepository.GetAll()    
            };

            return Ok(response);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ConsultaFornecedorResponse))]
        public IActionResult GetById(int id)
        {
            var response = new ConsultaFornecedorResponse
            { 
                StatusCode = StatusCodes.Status200OK,
                Data = new List<FornecedorEntity>()
            };

            response.Data.Add(fornecedorRepository.GetById(id));

            return Ok(response);
        }
    }
}
