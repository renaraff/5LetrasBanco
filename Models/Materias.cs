using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace _5LetrasBanco.Models
{

    [Table("Materias")]
    public class Materias
    {
        [Column("MateriasId")]
        [Display(Name = "Identificação das Materias")]
        public int Id { get; set; }

        [Column("MateriasNome")]
        [Display(Name = "Materias")]
        public string MateriasNome { get; set; } = string.Empty;
    }
}
