using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lojinha.Core.Models
{
    public class Carrinho
    {
        public List<CarrinhoItem> Itens { get; set; }
        public Carrinho()
        {
            Itens = new List<CarrinhoItem>();
        }
        public void Add(Produto produto)
        {
            if (Itens.Any(x => x.Produto.Id == produto.Id))
            {
                var item = Itens.FirstOrDefault(x => x.Produto.Id == produto.Id);
                item.Quantidade++;
            }
            else
            {
                Itens.Add(new CarrinhoItem
                {

                    Produto = produto,
                    Quantidade = 1
                });
            }
        }
    }
}
