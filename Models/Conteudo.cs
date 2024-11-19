using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace _5LetrasBanco.Models
{
    [Table("Conteudo")]
    public class Conteudo
    {
        [Column("ConteudoId")]
        [Display(Name = "Identificação do Conteudo")]
        public int Id { get; set; }

        [ForeignKey("ProfessorId")]
        [Display(Name = "Professor")]
        public int ProfessorId { get; set; }

        public Professor? Professor { get; set; }

        [ForeignKey("MateriasId")]
        [Display(Name = "Materia")]
        public int MateriasId { get; set; }

        public Materias? Materias { get; set; }

        [Column("ConteudoTexto")]
        [Display(Name = "Conteudo")]
        public string ConteudoTexto { get; set; } = string.Empty;
    }
}
