using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LeilaoNaNet.Models
{
    [Table("Produtos")]
    public class Produto
    {
        [Key]
        [Display(Name = "Código do Produto")]
        [Column("Id")]
        public int Id { get; set; }

        [Display(Name = "Nome do Produto")]
        [Column("Nome")]
        public string Nome { get; set; }

        [Display(Name = "Valor inicial do Produto")]
        [Column("Valor")]
        public decimal Valor { get; set; }

        [Display(Name = "Dias Ativo")]
        [Column("dias_ativo")]
        public int DiasAtivo { get; set; }

    }
}