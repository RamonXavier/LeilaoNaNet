using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using LeilaoNaNet.Models;
using LeilaoNaNet.ViewModel;

namespace LeilaoNaNet.DAO.Produto
{
    public class ProdutoDAO
    {
        private Context db = new Context();
        public void CadastroProduto(Models.Produto produto, ProdutosViewModel produtosViewModel)
        {
            db.Produtos.Add(produto);
            db.SaveChanges();
            var imagemProduto = new ImagemProduto()
            {
                Imagem = produtosViewModel.imagem,
                IdProduto = produto.Id
            };
            db.ImagemProdutos.Add(imagemProduto);
            db.SaveChanges();
        }

        public List<Models.Produto> BuscaProdutos()
        {
            return db.Produtos.ToList();
        }

        public Models.Produto BuscaProdutoPorId(int id)
        {
            var produto = db.Produtos.Find(id);
            return produto;
        }

        public List<Lances> BuscaLances(int id)
        {
            var lances = db.Lances.Where(x=>x.IdProduto == id).ToList();
            return lances;
        }

        public ImagemProduto ImagemProdutoPorId(int id)
        {
            var imagem = db.ImagemProdutos.Where(x => x.IdProduto == id).FirstOrDefault();
            return imagem;
        }

        public void EditarProduto(ProdutosViewModel produtosViewModel)
        {
            var buscaProduto = new ProdutoDAO();
            var produto = buscaProduto.BuscaProdutoPorId(produtosViewModel.Id);

            produto.Id = produtosViewModel.Id;
            produto.Nome = produtosViewModel.Nome;
            produto.DiasAtivo = produtosViewModel.DiasRestantes;
            produto.Valor = Convert.ToDecimal(produtosViewModel.ValorInicial);

            db.Entry(produto).State = EntityState.Modified;
            db.SaveChanges();

            ImagemProduto imagem = db.ImagemProdutos.Where(x => x.IdProduto == produtosViewModel.Id).FirstOrDefault();
            imagem.Imagem = produtosViewModel.imagem;
            db.Entry(produto).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void ApagarProduto(int id)
        {
            ImagemProduto imagem = db.ImagemProdutos.Where(x => x.IdProduto == id).FirstOrDefault();
            db.ImagemProdutos.Remove(imagem);
            db.SaveChanges();

            Models.Produto produto = db.Produtos.Find(id);
            db.Produtos.Remove(produto);
            db.SaveChanges();
        }

        public void NovoLanceProduto(Lances lance)
        {
            db.Lances.Add(lance);
            db.SaveChanges();
        }
    }
}