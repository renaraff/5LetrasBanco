using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace _5LetrasBanco.Models
{
    [Table("Aluno")]
    public class Alunos
    {
        [Column("AlunoId")]
        [Display(Name = "Identificação do Aluno")]
        public int Id { get; set; }

        [Column("AlunoNome")]
        [Display(Name = "Nome")]
        public string AlunoNome { get; set; } = string.Empty;

        [Column("AlunoEmail")]
        [Display(Name = "E-mail")]
        public string AlunoEmail { get; set; } = string.Empty;

        [Column("AlunoSenha")]
        [Display(Name = "Senha")]
        public string AlunoSenha { get; set; } = string.Empty;

        [Column("AlunoEscolaridade")]
        [Display(Name = "Escolaridade")]
        public string AlunoEscolaridade { get; set; } = string.Empty;
    }
}
