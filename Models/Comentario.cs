using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace _5LetrasBanco.Models
{ 
    [Table("Comentario")]
    public class Comentario
    {
        [Column("ComentarioId")]
        [Display(Name = "Comentario")]
        public int Id { get; set; }

        [ForeignKey("ConteudoId")]
        [Display(Name = "Conteudo")]
        public int ConteudoId { get; set; }

        public Conteudo? Conteudo { get; set; }

        [ForeignKey("DuvidaId")]
        [Display(Name = "Duvida")]
        public int DuvidaId { get; set; }

        public Duvida? Duvida { get; set; }

        [ForeignKey("ProfessorId")]
        [Display(Name = "Professor")]
        public int ProfessorId { get; set; }

        public Professor? Professor { get; set; }

        [ForeignKey("AlunoId")]
        [Display(Name = "Aluno")]
        public int AlunoId { get; set; }

        public Alunos? Alunos { get; set; }

        [Column("ComentarioTexto")]
        [Display(Name = "Comentario")]
        public string ComentarioTexto { get; set; } = string.Empty;
    }
}
