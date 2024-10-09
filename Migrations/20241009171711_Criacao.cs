using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _5LetrasBanco.Migrations
{
    /// <inheritdoc />
    public partial class Criacao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Aluno",
                columns: table => new
                {
                    AlunoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AlunoNome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AlunoEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AlunoSenha = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AlunoEscolaridade = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aluno", x => x.AlunoId);
                });

            migrationBuilder.CreateTable(
                name: "Materias",
                columns: table => new
                {
                    MateriasId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MateriasNome = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Materias", x => x.MateriasId);
                });

            migrationBuilder.CreateTable(
                name: "Professor",
                columns: table => new
                {
                    ProfessorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProfessorNome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProfessorEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProfessorSenha = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProfessorGraduacao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProfessorDescricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProfessorOcupacao = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Professor", x => x.ProfessorId);
                });

            migrationBuilder.CreateTable(
                name: "Duvida",
                columns: table => new
                {
                    DuvidaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AlunoId = table.Column<int>(type: "int", nullable: false),
                    AlunosId = table.Column<int>(type: "int", nullable: true),
                    MateriasId = table.Column<int>(type: "int", nullable: false),
                    DuvidaTexto = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Duvida", x => x.DuvidaId);
                    table.ForeignKey(
                        name: "FK_Duvida_Aluno_AlunosId",
                        column: x => x.AlunosId,
                        principalTable: "Aluno",
                        principalColumn: "AlunoId");
                    table.ForeignKey(
                        name: "FK_Duvida_Materias_MateriasId",
                        column: x => x.MateriasId,
                        principalTable: "Materias",
                        principalColumn: "MateriasId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Avaliacao",
                columns: table => new
                {
                    AvaliacaoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AlunoId = table.Column<int>(type: "int", nullable: false),
                    AlunosId = table.Column<int>(type: "int", nullable: true),
                    ProfessorId = table.Column<int>(type: "int", nullable: false),
                    AvaliacaoDescricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AvaliacaoEstrela = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Avaliacao", x => x.AvaliacaoId);
                    table.ForeignKey(
                        name: "FK_Avaliacao_Aluno_AlunosId",
                        column: x => x.AlunosId,
                        principalTable: "Aluno",
                        principalColumn: "AlunoId");
                    table.ForeignKey(
                        name: "FK_Avaliacao_Professor_ProfessorId",
                        column: x => x.ProfessorId,
                        principalTable: "Professor",
                        principalColumn: "ProfessorId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Conteudo",
                columns: table => new
                {
                    ConteudoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProfessorId = table.Column<int>(type: "int", nullable: false),
                    MateriasId = table.Column<int>(type: "int", nullable: false),
                    ConteudoTexto = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Conteudo", x => x.ConteudoId);
                    table.ForeignKey(
                        name: "FK_Conteudo_Materias_MateriasId",
                        column: x => x.MateriasId,
                        principalTable: "Materias",
                        principalColumn: "MateriasId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Conteudo_Professor_ProfessorId",
                        column: x => x.ProfessorId,
                        principalTable: "Professor",
                        principalColumn: "ProfessorId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comentario",
                columns: table => new
                {
                    ComentarioId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ConteudoId = table.Column<int>(type: "int", nullable: false),
                    DuvidaId = table.Column<int>(type: "int", nullable: false),
                    ProfessorId = table.Column<int>(type: "int", nullable: false),
                    AlunoId = table.Column<int>(type: "int", nullable: false),
                    AlunosId = table.Column<int>(type: "int", nullable: true),
                    ComentarioTexto = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comentario", x => x.ComentarioId);
                    table.ForeignKey(
                        name: "FK_Comentario_Aluno_AlunosId",
                        column: x => x.AlunosId,
                        principalTable: "Aluno",
                        principalColumn: "AlunoId");
                    table.ForeignKey(
                        name: "FK_Comentario_Conteudo_ConteudoId",
                        column: x => x.ConteudoId,
                        principalTable: "Conteudo",
                        principalColumn: "ConteudoId");
                    table.ForeignKey(
                        name: "FK_Comentario_Duvida_DuvidaId",
                        column: x => x.DuvidaId,
                        principalTable: "Duvida",
                        principalColumn: "DuvidaId");
                    table.ForeignKey(
                        name: "FK_Comentario_Professor_ProfessorId",
                        column: x => x.ProfessorId,
                        principalTable: "Professor",
                        principalColumn: "ProfessorId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Avaliacao_AlunosId",
                table: "Avaliacao",
                column: "AlunosId");

            migrationBuilder.CreateIndex(
                name: "IX_Avaliacao_ProfessorId",
                table: "Avaliacao",
                column: "ProfessorId");

            migrationBuilder.CreateIndex(
                name: "IX_Comentario_AlunosId",
                table: "Comentario",
                column: "AlunosId");

            migrationBuilder.CreateIndex(
                name: "IX_Comentario_ConteudoId",
                table: "Comentario",
                column: "ConteudoId");

            migrationBuilder.CreateIndex(
                name: "IX_Comentario_DuvidaId",
                table: "Comentario",
                column: "DuvidaId");

            migrationBuilder.CreateIndex(
                name: "IX_Comentario_ProfessorId",
                table: "Comentario",
                column: "ProfessorId");

            migrationBuilder.CreateIndex(
                name: "IX_Conteudo_MateriasId",
                table: "Conteudo",
                column: "MateriasId");

            migrationBuilder.CreateIndex(
                name: "IX_Conteudo_ProfessorId",
                table: "Conteudo",
                column: "ProfessorId");

            migrationBuilder.CreateIndex(
                name: "IX_Duvida_AlunosId",
                table: "Duvida",
                column: "AlunosId");

            migrationBuilder.CreateIndex(
                name: "IX_Duvida_MateriasId",
                table: "Duvida",
                column: "MateriasId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Avaliacao");

            migrationBuilder.DropTable(
                name: "Comentario");

            migrationBuilder.DropTable(
                name: "Conteudo");

            migrationBuilder.DropTable(
                name: "Duvida");

            migrationBuilder.DropTable(
                name: "Professor");

            migrationBuilder.DropTable(
                name: "Aluno");

            migrationBuilder.DropTable(
                name: "Materias");
        }
    }
}
