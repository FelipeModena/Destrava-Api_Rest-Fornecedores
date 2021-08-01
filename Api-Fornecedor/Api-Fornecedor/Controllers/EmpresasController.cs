using Api_Empresas.Business.BusinessImplementation;
using Api_Fornecedor.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api_Fornecedor.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class EmpresasController : ControllerBase
    {
        private readonly IEmpresaBusiness _empresaBusiness;

        public EmpresasController(IEmpresaBusiness empresaBusiness)
        {
            _empresaBusiness = empresaBusiness;
        }

        [AllowAnonymous]
        [HttpPost("CadastraEmpresa")]
        public IActionResult CadastraFornecedor([FromBody] Empresas empresa)
        {
            if (empresa == null)
            {
                return BadRequest();
            }
            else
            {
                return Ok(_empresaBusiness.Create(empresa));
            }
        }

        [AllowAnonymous]
        [HttpGet("GetEmpresasEFornecedores")]
        public IActionResult GetEmpresasEFornecedores( string cnpj)
        {

            return Ok(_empresaBusiness.FindByCnpj(cnpj));
        }


    }
}
