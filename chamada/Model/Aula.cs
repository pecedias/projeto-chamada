using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    [Serializable]
    public class Aula
    {
        public int idAula { get; set; }
        public Professor idProfessor { get; set; }
        public Turma idTurma { get; set; }
        public String Nome { get; set; }

        public Aula()
        {

        }

        public Aula(int idAula, Professor idProfessor, Turma idTurma, string nome)
        {
            this.idAula = idAula;
            this.idProfessor = idProfessor;
            this.idTurma = idTurma;
            Nome = nome;
        }
    }
}
