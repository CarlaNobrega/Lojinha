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
    public class ProdutosController : Controller
    {
        private readonly IProdutoServices _produtoServices;
        private readonly IMapper _mapper;
        public ProdutosController(IProdutoServices produtoServices, IMapper mapper)
        {
            _produtoServices = produtoServices;
            _mapper = mapper;
        }
        

        public IActionResult Create()
        {
            var produto = new Produto {
                Id = 331760,
                Nome = "Geladeira",
                Categoria = new Categoria
                {
                    Id = 2,
                    Nome = "Eletrodomésticos"
                },
                Descricao = "Geladeira FrostFree",
                Fabricante = new Fabricante {
                    Id = 3,
                    Nome = "Brastemp",
                },
                Preco = 3500m,
                Tags = new[] { "geladeira", "eletrodomesticos", "frostfree" },
                ImagemPrincipalUrl = "https://io.fastshop.com.br/wcsstore/FastShopCAS/imagens/_LB_LinhaBranca/BRBRE57AK/BRBRE57AK_PRD_447_1.jpg"
            };

           // _produtoServices(produto);

            return Content("OK");

        }

        public async Task<IActionResult> List()
        {
            var produtos = await _produtoServices.ObterProdutos();
            var vm = _mapper.Map<List<ProdutoViewModel>>(produtos);

            return View(vm);
        }

        public async Task<IActionResult> Details(string id)
        {
            var produto = await _produtoServices.ObterProduto(id);
            return Json(produto);
        }
    }
}
