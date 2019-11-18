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
                    SELECT a.idAluno,a.Nome,c.DataHora 
                    FROM orbx01.chamada c 
                    inner join aluno a 
                    where a.idAluno = @idAluno
                    AND c.idAula = @idAula
            ");

            cmd.Parameters.Add(new MySqlParameter("idAula", objEntrada.idAula));
            cmd.Parameters.Add(new MySqlParameter("idAluno", objEntrada.idAluno));

            Conexao c = new Conexao();

            c.Abrir();

            MySqlDataReader reader = c.Pesquisar(cmd);

            List<Chamada> lstRetorno = new List<Chamada>();

            while (reader.Read())
            {
                Chamada chamada = new Chamada();

                chamada.idAluno.Matricula = reader.GetInt32(1);
                chamada.idAluno.Nome = reader.GetString(2);

                lstRetorno.Add(chamada);

            }

            c.Fechar();

            return lstRetorno;

        }
        public List<Chamada> ListarFalta(Chamada objEntrada)
        {

            MySqlCommand cmd = null;

            cmd = new MySqlCommand(@"
                    select * from aluno a 
                    INNER JOIN aula al ON a.idTurma = @idTurma
                    where idAluno not in(
                    SELECT idAluno FROM chamada c WHERE c.idAula = @idAula
                    ) AND al.idAula = @idAula
            ");

            cmd.Parameters.Add(new MySqlParameter("idAula", objEntrada.idAula));
            cmd.Parameters.Add(new MySqlParameter("idTurma", objEntrada.idAula.idTurma));

            Conexao c = new Conexao();

            c.Abrir();

            MySqlDataReader reader = c.Pesquisar(cmd);

            List<Chamada> lstRetorno = new List<Chamada>();

            while (reader.Read())
            {
                Chamada chamada = new Chamada();

                chamada.idAluno.Matricula = reader.GetInt32(2);
                chamada.idAluno.Nome = reader.GetString(3);

                lstRetorno.Add(chamada);

            }

            c.Fechar();

            return lstRetorno;

        }
    }
}
