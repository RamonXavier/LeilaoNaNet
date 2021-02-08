using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using LeilaoNaNet.DAO.Produto;
using LeilaoNaNet.DAO.Usuario;
using LeilaoNaNet.Models;
using LeilaoNaNet.ViewModel;

namespace LeilaoNaNet.RegraNegocio.Produto
{
    public class ProdutoRN
    {
        public void CadastroProduto(ProdutosViewModel produtosViewModel)
        {
            var valorInicial = Convert.ToDecimal(produtosViewModel.ValorInicial);
            var produto = new Models.Produto()
            {
                Nome = produtosViewModel.Nome,
                DiasAtivo = produtosViewModel.DiasRestantes,
                Valor = valorInicial
            };
            var salvarProduto = new ProdutoDAO();
            salvarProduto.CadastroProduto(produto, produtosViewModel);
        }

        public List<Models.Produto> BuscaProdutos()
        {
            var produtos = new ProdutoDAO();
            var listaProdutos = produtos.BuscaProdutos();
            return listaProdutos;
        }

        public ProdutosViewModel DetalheProduto(int id, string acao)
        {
            var buscaProduto = new ProdutoDAO();
            var produto = buscaProduto.BuscaProdutoPorId(id);

            var buscaImagemProduto = new ProdutoDAO();
            var imagem = buscaImagemProduto.ImagemProdutoPorId(id);

            var lances = BuscaLances(id);

            var viewModel = new ProdutosViewModel()
            {
                Nome = produto.Nome,
                Id = produto.Id,
                imagem = imagem.Imagem,
                ValorInicial = produto.Valor.ToString(),
                DiasRestantes = produto.DiasAtivo,
                TipoAcao = acao,
                LancesProdtos = lances
            };
            return viewModel;
        }

        public void EditarProdutos(ProdutosViewModel produtosViewModel)
        {
            var editarProduto = new ProdutoDAO();
            editarProduto.EditarProduto(produtosViewModel);
        }

        public void ApagarProduto(int id)
        {
            var apagarProduto = new ProdutoDAO();
            apagarProduto.ApagarProduto(id);
        }

        public IEnumerable<KeyValuePair<string, decimal>> BuscaLances(int id)
        {
            var listaLances = new ProdutoDAO();
            var lista = listaLances.BuscaLances(id);

            var listaUser = new UsuarioDAO();
            var usuarios = listaUser.BuscaUsuario();

            var listaLancesUsuarios =
                from lances in lista
                join user in usuarios on lances.IdUsuario equals user.Id
                orderby lances.Valor descending 
                select new KeyValuePair<string, decimal>(user.Nome, lances.Valor);
            return listaLancesUsuarios;
        }

        public bool FazerLAnce(int user, ProdutosViewModel produtosViewModel)
        {

            var produto = produtosViewModel.Id;
            var valor = Convert.ToDecimal(produtosViewModel.ValorInicial);
            var ultimoLance = new ProdutoDAO();
            var buscaDadosUser = new UsuarioDAO();
            var usuario = buscaDadosUser.BuscaUsuarioPorId(user);
            var ultimoLanceResult = ultimoLance.BuscaLances(produto).Where(x => x.IdProduto == produto).OrderByDescending(x=>x.Id).FirstOrDefault();
            if (ultimoLanceResult.Valor >= valor || usuario.Idade < 18)
            {
                return false;
            }
            var lance = new Lances()
            {
                IdProduto = produto,
                IdUsuario = user,
                Valor = valor
            };
            var novoLanceProduto = new ProdutoDAO();
            novoLanceProduto.NovoLanceProduto(lance);
            return true;
        }
    }
}