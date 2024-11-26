using Microsoft.EntityFrameworkCore;

namespace _5LetrasBanco.Models
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options) : base(options)
        {

        }
        public DbSet<Alunos>? Alunos { get; set; }

        public DbSet<Comentario>? Comentario { get; set; }

        public DbSet<Conteudo>? Conteudo { get; set; }

        public DbSet<Duvida>? Duvida { get; set; }

        public DbSet<Materias>? Materias { get; set; }

        public DbSet<Professor>? Professor { get; set; }

    }
}
