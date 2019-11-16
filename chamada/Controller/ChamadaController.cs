using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using MySql.Data.MySqlClient;

namespace Controller
{
    class ChamadaController
    {
        public List<Chamada> ListarPresenca(Chamada objEntrada)
        {

            MySqlCommand cmd = null;

            cmd = new MySqlCommand(@"
                 select Turma.idTurma,      
                        Turma.Nome
            ");

            Conexao c = new Conexao();

            c.Abrir();

            MySqlDataReader reader = c.Pesquisar(cmd);

            List<Chamada> lstRetorno = new List<Chamada>();

            while (reader.Read())
            {
                Chamada turma = new Chamada();

                turma.idTurma = reader.GetInt32(0);
                turma.Nome = reader.GetString(1);

                lstRetorno.Add(turma);

            }

            c.Fechar();

            return lstRetorno;

        }
    }
}
