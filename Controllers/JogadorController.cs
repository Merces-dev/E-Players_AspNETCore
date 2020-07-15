using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using E_Players.Models;
using Microsoft.AspNetCore.Http;

namespace E_Players.Controllers
{
    public class JogadorController : Controller
    {
        Jogador jogadorModel = new Jogador();

        public IActionResult Index()
        {
            ViewBag.Jogadores = jogadorModel.ReadAll();
            return View();
        }    
        public IActionResult Cadastrar(IFormCollection form){
            Jogador novoJogador = new Jogador();
            novoJogador.IdJogador = Int32.Parse(form["IdJogador"]);
            novoJogador.Nome = form["Nome"];
            novoJogador.IdEquipe = Int32.Parse(form["IdEquipe"]);

            jogadorModel.Create(novoJogador);
            ViewBag.Jogadores = jogadorModel.ReadAll();
            return LocalRedirect("~/Jogador");
     
        }  
        [Route("[controller]/{id}")]
        public IActionResult Excluir(int id)
        {
            jogadorModel.Delete(id);
            ViewBag.Jogadores = jogadorModel.ReadAll();
            return LocalRedirect("~/Jogador");
        }
    }
}