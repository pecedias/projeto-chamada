using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    [Serializable]
    public class Chamada
    {
        public int idChamada { get; set; }
        public Aula idAula { get; set; }
        public Aluno idAluno { get; set; }
        public int Presenca { get; set; }
        public DateTime datahora { get; set; }
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
