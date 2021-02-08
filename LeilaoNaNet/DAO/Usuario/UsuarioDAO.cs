using System.Collections.Generic;
using LeilaoNaNet.Models;
using System.Linq;
using LeilaoNaNet.Models;
using LeilaoNaNet.ViewModel.Usuario;

namespace LeilaoNaNet.DAO.Usuario
{
    public class UsuarioDAO
    {
        private Context db = new Context();

        public List<Models.Usuario> BuscaUsuario()
        {
            return db.Usuarios.ToList();
        }

        public Models.Usuario BuscaUsuarioPorId(int? id)
        {
            var usuario = db.Usuarios.Find(id);
            return usuario;
        }

        public void SalvaNovoUsuario(Models.Usuario usuario)
        {
            db.Usuarios.Add(usuario);
            db.SaveChanges();
        }

        public void EditarUsuario(UsuarioViewModel usuarioViewModel)
        {
            Models.Usuario usuario = db.Usuarios.First(x => x.Id.Equals(usuarioViewModel.Id));
            usuario.Nome = usuarioViewModel.Nome;
            usuario.Idade = usuarioViewModel.Idade;
            usuario.Senha = usuarioViewModel.Senha;
            db.SaveChanges();
        }

        public void ApagarUsuarioPorId(int id)
        {
            Models.Usuario usuario = db.Usuarios.Find(id);
            db.Usuarios.Remove(usuario);
            db.SaveChanges();
        }
    }
}