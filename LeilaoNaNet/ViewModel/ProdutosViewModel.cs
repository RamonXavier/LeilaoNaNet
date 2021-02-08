using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LeilaoNaNet.ViewModel
{
    public class ProdutosViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string ValorInicial { get; set; }
        public string imagem { get; set; }
        public int DiasRestantes { get; set; }
        public string TipoAcao { get; set; }
        public int IdUsuario { get; set; }
        public IEnumerable<KeyValuePair<string,decimal>> LancesProdtos{ get; set; }
    }
}