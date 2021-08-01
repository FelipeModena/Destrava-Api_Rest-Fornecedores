using Api_Fornecedor.BusinessImplementation;
using Api_Fornecedor.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api_Fornecedor.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    public class FornecedorController : ControllerBase
    {
        private readonly IFornecedorBusiness _fornecedorBusiness;

        public FornecedorController(IFornecedorBusiness fornecedorBusiness)
        {
            _fornecedorBusiness = fornecedorBusiness;
        }

        [AllowAnonymous]
        [HttpGet("GetFornecedor")]
        public IActionResult GetFornecedor(string cnpj)
        {
            var Fornecedor = _fornecedorBusiness.FindByCnpj(cnpj);
            return Ok(Fornecedor);
        }

        [AllowAnonymous]
        //1 - cadastrar um fornecedor
        [HttpPost("CadastraFornecedor")]
        public IActionResult CadastraFornecedor([FromBody] Fornecedor fornecedor)
        {

            if (fornecedor.Cnpj == "" || fornecedor.RazaoSocial == "" || fornecedor.NomeFantasia == "" || fornecedor.Email == "" || fornecedor.Senha == "")
            {
                return BadRequest();
            }
            else
            {
                return Ok(_fornecedorBusiness.Create(fornecedor));
            }
        }

        //2 - As vezes o fornecedor deseja alterar algumas informações, então preciso de um endpoint de alteração,mas nem todas as informações são mutaveis, abaixo segue as informações imutaveis:
        //3 - Precisamos ter uma ação de desativar um fornecedor
        [AllowAnonymous]
        [HttpPut("UpdateFornecedor")]
        public IActionResult UpdateFornecedor(Fornecedor fornecedor)
        {
            if (fornecedor == null)
            {
                return BadRequest();
            }
            else
            {
                return Ok(_fornecedorBusiness.Update(fornecedor));
            }
        }
         //4 - É triste mas as vezes também precisamos deletar um fornecedor
        [AllowAnonymous]
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            _fornecedorBusiness.Delete(id);
            return NoContent();
        }
    }
}
