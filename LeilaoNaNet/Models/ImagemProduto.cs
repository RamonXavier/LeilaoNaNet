using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace LeilaoNaNet.Models
{
    [Table("ImagemProduto")]
    public class ImagemProduto
    {
        [Key]
        [Column("Id")]
        public int Id { get; set; }

        [Display(Name = "Produto")]
        [Column("IdProduto")]
        [ForeignKey("Produto")]
        public int? IdProduto { get; set; }
        public virtual Produto Produto { get; set; }

        [Display(Name = "Imagem")]
        [Column("Imagem")]
        public string Imagem { get; set; }
    }
}