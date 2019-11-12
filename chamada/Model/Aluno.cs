using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    [Serializable]
    public class Aluno
    {
        public int idAluno { get; set; }
        public Turma idTurma { get; set; }
        public int Matricula { get; set; }
        public String Nome { get; set; }
        public int Foto { get; set; }

        public Aluno()
        {

        }

        public Aluno(int idAluno, Turma idTurma, int matricula, string nome, int foto)
        {
            this.idAluno = idAluno;
            this.idTurma = idTurma;
            Matricula = matricula;
            Nome = nome;
            Foto = foto;
        }
    }
}
