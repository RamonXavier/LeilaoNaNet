using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LeilaoNaNet.Models;
using LeilaoNaNet.RegraNegocio.Produto;
using LeilaoNaNet.ViewModel;

namespace LeilaoNaNet.Controllers
{
    public class ProdutosController : Controller
    {
        private Context db = new Context();

        public ActionResult Index()
        {
            var produtos = new ProdutoRN();
            var viewModel = produtos.BuscaProdutos();
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult DetalheProduto(int id)
        {
            var produtos = new ProdutoRN().DetalheProduto(id, "Detalhe");
            return View("_DetalheProduto", produtos);
        }

        public ActionResult NovoProduto()
        {
            if (!Session["Login"].Equals("Admin"))
            {
                return RedirectToAction("Index", "Produtos");
            }
            return View();
        }

        [HttpPost]
        public ActionResult CadastroProduto(ProdutosViewModel produtosViewModel)
        {
            if (!Session["Login"].Equals("Admin"))
            {
                return RedirectToAction("Index", "Produtos");
            }
            if (ModelState.IsValid)
            {
                var produto = new ProdutoRN();
                produto.CadastroProduto(produtosViewModel);
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index", "Produtos");
        }

        [HttpPost]
        public ActionResult EditarProdutoModal(int id)
        {
            if (!Session["Login"].Equals("Admin"))
            {
                return RedirectToAction("Index", "Produtos");
            }
            var viweModel = new ProdutoRN().DetalheProduto(id, "Editar");
            return View("_DetalheProduto", viweModel);
        }

        [HttpPost]
        public ActionResult EditarProduto(ProdutosViewModel produtosViewModel)
        {
            if (!Session["Login"].Equals("Admin"))
            {
                return RedirectToAction("Index", "Produtos");
            }
            if (ModelState.IsValid)
            {
                var produto = new ProdutoRN();
                produto.EditarProdutos(produtosViewModel);
                return RedirectToAction("Index");
            }
            return View("Index");
        }

        [HttpGet]
        public ActionResult ApagarProduto(int id)
        {
            if (!Session["Login"].Equals("Admin"))
            {
                return RedirectToAction("Index", "Produtos");
            }
            var produto = new ProdutoRN();
            produto.ApagarProduto(id);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Lance(int id)
        {
            var viweModel = new ProdutoRN().DetalheProduto(id, "Lance");
            return View("_DetalheProduto", viweModel);
        }

        [HttpPost]
        public JsonResult FazerLance(ProdutosViewModel produtosViewModel)
        {
            var usuario = (int)Session["IdUser"];
            var lanceRN = new ProdutoRN();
            var returnLAnce = lanceRN.FazerLAnce(usuario, produtosViewModel);

            if (returnLAnce == false)
            {
                var resultadoNegativo = new
                {
                    Cor = "Red",
                    Mensagem = "Atenção - O lance atual deve ser maior que o último lance. // // // // " +
                               "Atenção - O usuário deve ter o mínimo de 18 anos de idade"
                };
                return Json(resultadoNegativo, JsonRequestBehavior.AllowGet);
            }
            var resultadoPositivo = new
            {
                Cor = "Green",
                Mensagem = "Atenção - Lance Efetuado com sucesso."
            };
            return Json(resultadoPositivo, JsonRequestBehavior.AllowGet);
        }
    }
}
