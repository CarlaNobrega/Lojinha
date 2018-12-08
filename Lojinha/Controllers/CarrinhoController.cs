using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Lojinha.Core.Models;
using Lojinha.Infrastructure.Storage;
using Lojinha.Core.Services;
using AutoMapper;
using Lojinha.Core.ViewModels;

namespace Lojinha.Controllers
{
    [Authorize]
    public class CarrinhoController : Controller
    {
        private readonly IProdutoServices _produtoServices;
        private readonly ICarrinhoService _carrinhoService;
        public CarrinhoController(IProdutoServices produtoService, ICarrinhoService carrinhoService)
        {
            _produtoServices = produtoService;
            _carrinhoService = carrinhoService;
        }
        public async Task<IActionResult> Add(string id)
        {
            var usuario = HttpContext.User.Identity.Name;

            Carrinho carrinho = _carrinhoService.Obter(usuario);

            carrinho.Add(await _produtoServices.ObterProduto(id));

            _carrinhoService.Salvar(usuario, carrinho);

            return PartialView("Index", carrinho);
        }

        public IActionResult Finalizar()
        {
            var usuario = HttpContext.User.Identity.Name;
            var carrinho = _carrinhoService.Obter(usuario);

            //TODO: Inserir Mensagem na Queue

            _carrinhoService.Limpar(usuario);

            return View(carrinho);
        }
    }
}
