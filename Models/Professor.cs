using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace _5LetrasBanco.Models
{

    [Table("Professor")]
    public class Professor
    {
        [Column("ProfessorId")]
        [Display(Name = "Identificação do Professor")]
        public int Id { get; set; }

        [Column("ProfessorNome")]
        [Display(Name = "Nome")]
        public string ProfessorNome { get; set; } = string.Empty;

        [Column("ProfessorEmail")]
        [Display(Name = "Email")]
        public string ProfessorEmail { get; set; } = string.Empty;

        [Column("ProfessorSenha")]
        [Display(Name = "Senha")]
        public string ProfessorSenha { get; set; } = string.Empty;

        [Column("ProfessorGraduacao")]
        [Display(Name = "Graduação")]
        public string ProfessorGraduacao { get; set; } = string.Empty;

        [Column("ProfessorDescricao")]
        [Display(Name = "Descrição")]
        public string ProfessorDescricao { get; set; } = string.Empty;

        [Column("ProfessorOcupacao")]
        [Display(Name = "Ocupação")]
        public string ProfessorOcupacao { get; set; } = string.Empty;
    }
}
