using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Projeto.Presentation.API.Models.Requests;
using Projeto.Presentation.API.Models.Response;
using Projeto.Presentation.API.Models.Responses;

namespace Projeto.Presentation.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FornecedorController : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CadastroFornecedorResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Post(CadastroFornecedorRequests requests)
        {
            var response = new CadastroFornecedorResponse
            { 
                StatusCode = StatusCodes.Status200OK,
                Message = "Fornecedor cadastrado com sucesso."
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
            var response = new EdicaoFornecedorResponse
            { 
                StatusCode = StatusCodes.Status200OK,
                Message = "Fornecedor atualizado com sucesso."
            };

            return Ok(response);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ExclusaoFornecedorResponse))]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Delete(int id)
        {
            var response = new ExclusaoFornecedorResponse
            { 
                StatusCode = StatusCodes.Status200OK,
                Message = "Fornecedor excluído com sucesso."
            };

            return Ok(response);
        }

        [HttpGet]
        public IActionResult GetAtt()
        {
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok();
        }
    }
}
