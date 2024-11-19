using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace _5LetrasBanco.Models
{
    [Table("Avaliacao")]
    public class Avaliacao
    {
        [Column("AvaliacaoId")]
        [Display(Name = "Identificação da Avaliação")]
        public int Id { get; set; }

        [ForeignKey("AlunoId")]
        [Display(Name = "Aluno")]
        public int AlunoId { get; set; }

        public Alunos? Alunos { get; set; }

        [ForeignKey("ProfessorId")]
        [Display(Name = "Selecione um Professor para avaliar")]
        public int ProfessorId { get; set; }

        public Professor? Professor { get; set; }

        [Column("AvaliacaoDescricao")]
        [Display(Name = "Descrição da Avaliação")]
        public string AvaliacaoDescricao { get; set; } = string.Empty;


        [Column("AvaliacaoEstrela")]
        [Display(Name = "Avalie o professor com estrelas de 0 a 5")]
        public int AvaliacaoEstrela { get; set; }

    }
}
