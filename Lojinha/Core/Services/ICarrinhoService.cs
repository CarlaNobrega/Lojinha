using Lojinha.Core.Models;

namespace Lojinha.Core.Services
{
    public interface ICarrinhoService
    {
        void Limpar(string usuario);
        Carrinho Obter(string usuario);
        void Salvar(string usuario, Carrinho carrinho);
    }
}