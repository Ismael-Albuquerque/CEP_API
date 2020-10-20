using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using ExercicioCEP.DAL;
using ExercicioCEP.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;


//Ismael da Silva Machado de Albuquerque


namespace ExercicioCEP.Controllers
{
    public class CEPController : Controller
    {
        private readonly CEPDao _cepDao;
        public CEPController(CEPDao cepDao)
        {
            _cepDao = cepDao;
        }
        public IActionResult Index()
        {
            if (TempData["CEP"] != null)
            {
                string resultado = TempData["CEP"].ToString();
                CEP cep = JsonConvert.DeserializeObject<CEP>(resultado);

                _cepDao.Cadastrar(cep);      

                return View(_cepDao.Listar());


            }
            return View(_cepDao.Listar());
        }

        [HttpPost]
        public IActionResult PesquisarCEP(string txtCEP)
        {
            string url = $@"https://viacep.com.br/ws/{txtCEP}/json/";
            WebClient client = new WebClient();
            TempData["CEP"] = client.DownloadString(url);
            return RedirectToAction("Index");
        }

    }
}
