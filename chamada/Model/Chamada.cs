using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    [Serializable]
    class Chamada
    {
        private int idChamada { get; set; }
        private Aula idAula { get; set; }
        private Aluno idAluno { get; set; }
        private int Presenca { get; set; }

        public Chamada()
        {

        }

        public Chamada(int idChamada, Aula idAula, Aluno idAluno, int presenca)
        {
            this.idChamada = idChamada;
            this.idAula = idAula;
            this.idAluno = idAluno;
            Presenca = presenca;
        }
    }
}
