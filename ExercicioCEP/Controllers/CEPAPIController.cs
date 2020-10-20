using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExercicioCEP.DAL;
using ExercicioCEP.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExercicioCEP.Controllers
{
    [Route("api/Endereco")]
    [ApiController]
    public class CEPAPIController : ControllerBase
    {
        private readonly CEPDao _cepDao;
        public CEPAPIController(CEPDao cepDao)
        {
            _cepDao = cepDao;
        }

        //GET: /api/Endereco/ListarEnderecos
        [HttpGet]
        [Route("ListarEnderecos")]
        public IActionResult Listar()
        {
            return Ok(_cepDao.Listar());
        }

        //GET: /api/Endereco/ListarEndereco/{cep}
        [HttpGet]
        [Route("ListarEndereco/{cep}")]
        public IActionResult Listar(string cep)
        {
            return Ok(_cepDao.Listar(cep));
        }

        // POST: /api/Endereco/CadastrarEndereco
        [HttpPost]
        [Route("CadastrarEndereco")]
        public IActionResult Cadastrar(CEP cep)
        {
            _cepDao.Cadastrar(cep);
            return Created("", cep);
        }

        //PUT: /api/Endereco/AlterarEndereco
        [HttpPut]
        [Route("AlterarEndereco")]
        public IActionResult Alterar(CEP cep)
        {
            return Ok(_cepDao.Atualizar(cep));
        }

        //DELETE: /api/Endereco/DeletarEndereco/{cepID}
        [HttpDelete]
        [Route("DeletarEndereco/{id}")]
        public IActionResult Deletar(string enderecoid)
        {
            return Ok(_cepDao.Deletar(enderecoid));
        }


    }
}