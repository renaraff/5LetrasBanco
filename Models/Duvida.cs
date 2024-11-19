using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace _5LetrasBanco.Models
{
    [Table("Duvida")]
    public class Duvida
    {
        [Column("DuvidaId")]
        [Display(Name = "Identificação da Duvida")]
        public int Id { get; set; }

        [ForeignKey("AlunoId")]
        [Display(Name = "Aluno")]
        public int AlunoId { get; set; }

        public Alunos? Alunos { get; set; }

        [ForeignKey("MateriasId")]
        [Display(Name = "Selecione uma Materias")]
        public int MateriasId { get; set; }

        public Materias? Materias { get; set; }

        [Column("DuvidaTexto")]
        [Display(Name = "Conteudo")]
        public string DuvidaTexto { get; set; } = string.Empty;
    }
}
