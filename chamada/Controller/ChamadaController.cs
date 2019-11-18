using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using MySql.Data.MySqlClient;

namespace Controller
{
    public class ChamadaController
    {

        public List<Chamada> ListarPresenca(Chamada objEntrada)
        {

            MySqlCommand cmd = null;

            cmd = new MySqlCommand(@"
                    SELECT c.idChamada,a.Nome,c.DataHora 
                    FROM chamada c 
                    inner join aluno a ON a.idAluno = c.idAluno
                    where c.idAula = @idAula
            ");

            cmd.Parameters.Add(new MySqlParameter("idAula", objEntrada.idAula.idAula));

            Conexao c = new Conexao();

            c.Abrir();

            MySqlDataReader reader = c.Pesquisar(cmd);

            List<Chamada> lstRetorno = new List<Chamada>();

            while (reader.Read())
            {
                Chamada chamada = new Chamada();
                Aluno a = new Aluno();
                a.Nome = reader.GetString(1);

                chamada.idChamada = reader.GetInt32(0);
                chamada.idAluno = a;
                chamada.datahora = reader.GetDateTime(2);
                lstRetorno.Add(chamada);

            }

            c.Fechar();

            return lstRetorno;

        }
        public List<Chamada> ListarFalta(Chamada objEntrada)
        {

            MySqlCommand cmd = null;

            cmd = new MySqlCommand(@"
                    select a.idAluno,a.Nome from aluno a 
                    INNER JOIN aula al ON a.idTurma = al.idTurma
                    where a.idAluno not in(
                    SELECT idAluno FROM chamada c WHERE c.idAula = @idAula
                    ) AND al.idAula = @idAula
            ");

            cmd.Parameters.Add(new MySqlParameter("idAula", objEntrada.idAula.idAula));

            Conexao c = new Conexao();

            c.Abrir();

            MySqlDataReader reader = c.Pesquisar(cmd);

            List<Chamada> lstRetorno = new List<Chamada>();

            while (reader.Read())
            {
                Chamada chamada = new Chamada();
                Aluno a = new Aluno();
                a.Nome = reader.GetString(1);

                chamada.idAluno = a;
                lstRetorno.Add(chamada);

            }

            c.Fechar();

            return lstRetorno;

        }
    }
}