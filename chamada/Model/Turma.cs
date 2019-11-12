using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    [Serializable]
    public class Turma
    {
        public int idTurma { get; set; }
        public String Nome { get; set; }

        public Turma() {
        }

        public Turma(int idTurma, string nome)
        {
            this.idTurma = idTurma;
            Nome = nome;
        }
    }
}
