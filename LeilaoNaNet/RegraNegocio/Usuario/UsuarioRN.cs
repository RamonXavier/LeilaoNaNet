using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using LeilaoNaNet.DAO.Usuario;
using LeilaoNaNet.Models;
using LeilaoNaNet.ViewModel.Usuario;

namespace LeilaoNaNet.RegraNegocio.Usuario
{
    public class UsuarioRN
    {
        public int LogarUsuario(UsuarioViewModel usuarioViewModel)
        {

            var loginUsuario = new Models.Usuario()
            {
                Nome = usuarioViewModel.Nome,
                Senha = usuarioViewModel.Senha
            };

            var usuarios = new UsuarioDAO().BuscaUsuario();
            if (usuarios.Count(x => x.Nome == loginUsuario.Nome && x.Senha == loginUsuario.Senha) > 0)
            {
                var possui = usuarios.Where(x => x.Nome == loginUsuario.Nome && x.Senha == loginUsuario.Senha).FirstOrDefault();
                return possui.Id;
            }
            return 0;
        }

        public bool NovoUsuario(UsuarioViewModel usuarioViewModel)
        {
            var existeUsuario = new UsuarioDAO();
            var existeuserResult = existeUsuario.BuscaUsuario().Where(x=>x.Nome == usuarioViewModel.Nome).Count();

            if (existeuserResult > 0)
            {
                return false;
            }
            else
            {
                var idadeTradada = DateTime.Now.Year - usuarioViewModel.Idade;
                var novoUsuario = new Models.Usuario()
                {
                    Idade = idadeTradada,
                    Nome = usuarioViewModel.Nome,
                    Senha = usuarioViewModel.Senha
                };
                var salvarUsuario = new UsuarioDAO();
                salvarUsuario.SalvaNovoUsuario(novoUsuario);
                return true;
            }
        }

        public List<Models.Usuario> BuscaUsuario()
        {
            var usuarioList = new UsuarioDAO().BuscaUsuario();
            return usuarioList;
        }
        public Models.Usuario BuscaUsuarioPorId(int? id)
        {
            var usuarioList = new UsuarioDAO().BuscaUsuarioPorId(id);
            return usuarioList;
        }

        public void EditarUsuario(UsuarioViewModel usuarioViewModel)
        {
            var editaUsuario = new UsuarioDAO();
                editaUsuario.EditarUsuario(usuarioViewModel);
        }

        public void ApagarUsuarioPorId(int id)
        {
            var apagarUsuario = new UsuarioDAO();
            apagarUsuario.ApagarUsuarioPorId(id);
        }
    }
}