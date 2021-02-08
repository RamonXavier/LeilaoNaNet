using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LeilaoNaNet.Models
{
    [Table("LancesLeilao")]
    public class Lances
    {
        [Key]
        [Column("Id")]
        public int Id { get; set; }

        [Display(Name = "Produto")]
        [Column("IdProduto")]
        [ForeignKey("Produto")]
        public int? IdProduto{ get; set; }
        public virtual Produto  Produto{ get; set; }

        [Display(Name = "Usuário")]
        [Column("IdUsuario")]
        [ForeignKey("Usuario")]
        public int? IdUsuario { get; set; }
        public virtual Usuario Usuario{ get; set; }

        [Display(Name = "Valor do Lance")]
        [Column("Valor")]
        public decimal Valor { get; set; }
    }
}