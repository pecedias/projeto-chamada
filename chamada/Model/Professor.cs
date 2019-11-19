using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    [Serializable]
    public class Professor
    {
        public int idProfessor { get; set; }
        public String Nome { get; set; }
        public String Email { get; set; }
        public String Senha { get; set; }
        public List<Pagina> listaPaginaAcesso { get; set;}

        public Professor()
        {
            listaPaginaAcesso = new List<Pagina>();
        }

        public Professor(int idProfessor, string nome, string senha, string email, List<Pagina> listaPaginaAcesso)
        {
            this.idProfessor = idProfessor;
            Nome = nome;
            Senha = senha;
            Email = email;
            this.listaPaginaAcesso = listaPaginaAcesso;
        }
    }
}
