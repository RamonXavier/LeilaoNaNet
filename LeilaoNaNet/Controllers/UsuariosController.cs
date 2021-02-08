using System.Net;
using System.Web.Mvc;
using LeilaoNaNet.RegraNegocio.Usuario;
using LeilaoNaNet.ViewModel.Usuario;

namespace LeilaoNaNet.Controllers
{
    public class UsuariosController : Controller
    {
        public ActionResult Index()
        {
            if (!Session["Login"].Equals("Admin"))
            {
                return RedirectToAction("Index", "Produtos");
            }
            var usuariosList = new UsuarioRN().BuscaUsuario();
            return View(usuariosList);
        }


        public ActionResult DetalhesUsuario(int? id)
        {
            if (!Session["Login"].Equals("Admin"))
            {
                return RedirectToAction("Index", "Produtos");
            }
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            else
            {
                var usuarioDetalhe = new UsuarioRN().BuscaUsuarioPorId(id);
                return View(usuarioDetalhe);
            }
        }


        [HttpPost]
        public ActionResult LogarUsuario(UsuarioViewModel usuarioViewModel)
        {
            var usuarioExistente = new UsuarioRN().LogarUsuario(usuarioViewModel);

            if (usuarioExistente > 0)
            {
                Session["Login"] = usuarioViewModel.Nome;
                Session["IdUser"] = usuarioExistente;
                Session["LoginFailed"] = null;
                return RedirectToAction("Index", "Produtos");
            }
            else
            {
                Session["LoginFailed"] = 0;
                return RedirectToAction("Login", "Home");
            }

        }

        [HttpPost]
        public ActionResult NovoUsuario(UsuarioViewModel usuarioViewModel)
        {
            var novoUsuario = new UsuarioRN();
            var cadastro = novoUsuario.NovoUsuario(usuarioViewModel);
            if (cadastro == false)
            {
                var resultadoNegativo = new
                {
                    Cor = "Red",
                    Mensagem = "Atenção - Já existe usuário com o nome escolhido."
                };
                return Json(resultadoNegativo, JsonRequestBehavior.AllowGet);
            }
            var resultadoPositivo = new
            {
                Cor = "Green",
                Mensagem = "Atenção - Cadastro efetuado com sucesso."
            };
            return Json(resultadoPositivo, JsonRequestBehavior.AllowGet);
        }

        public ActionResult NovoUsuario()
        {
            return View();
        }

        [HttpGet]
        public ActionResult EditarUsuario(int? id)
        {
            if (!Session["Login"].Equals("Admin"))
            {
                return RedirectToAction("Index", "Produtos");
            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var usuario = new UsuarioRN().BuscaUsuarioPorId(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditarUsuario(UsuarioViewModel usuarioViewModel)
        {
            if (!Session["Login"].Equals("Admin"))
            {
                return RedirectToAction("Index", "Produtos");
            }
            if (ModelState.IsValid)
            {
                var usuario = new UsuarioRN();
                usuario.EditarUsuario(usuarioViewModel);
            }
            return View();
        }


        [HttpGet]
        public ActionResult ApagarUsuario(int id)
        {
            if (!Session["Login"].Equals("Admin"))
            {
                return RedirectToAction("Index", "Produtos");
            }
            var apagar = new UsuarioRN();
            apagar.ApagarUsuarioPorId(id);
            return RedirectToAction("Index");
        }
    }
}
