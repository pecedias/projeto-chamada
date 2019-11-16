using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using MySql.Data.MySqlClient;

namespace Controller
{
    class TurmaController
    {
        public void Incluir(Turma objEntrada)
        {

            if (String.IsNullOrEmpty(objEntrada.Nome))
            {
                throw new ConsistenciaException("Por favor, digite o nome da Turma.");
            }

            MySqlCommand cmd = new MySqlCommand(@"insert into Turma values(
                 default,
                 @Nome,
            ");

            cmd.Parameters.Add(new MySqlParameter("idAula", objEntrada.idTurma));
            cmd.Parameters.Add(new MySqlParameter("Nome", objEntrada.Nome));

            Conexao c = new Conexao();
            c.Abrir();
            c.Executar(cmd);
            c.Fechar();

        }

        public void Atualizar(Turma objEntrada)
        {

            if (String.IsNullOrEmpty(objEntrada.Nome))
            {
                throw new ConsistenciaException("Por favor, digite o nome da Turma.");
            }

            MySqlCommand cmd = new MySqlCommand(@"update Turma
                 set Nome = @Nome,
               where idTurma = @idTurma
             ");

            cmd.Parameters.Add(new MySqlParameter("idTurma", objEntrada.idTurma));
            cmd.Parameters.Add(new MySqlParameter("Nome", objEntrada.Nome));

            Conexao c = new Conexao();
            c.Abrir();
            c.Executar(cmd);
            c.Fechar();

        }

        public void Excluir(Turma objEntrada)
        {

            MySqlCommand cmd = new MySqlCommand("delete from Turma where idTurma = @idTurma");

            cmd.Parameters.Add(new MySqlParameter("idAluno", objEntrada.idTurma));

            Conexao c = new Conexao();
            c.Abrir();
            c.Executar(cmd);
            c.Fechar();

        }

        public List<Turma> Listar(Turma objEntrada)
        {

            MySqlCommand cmd = null;

            cmd = new MySqlCommand(@"
                 select Turma.idTurma,      
                        Turma.Nome
            ");

            Conexao c = new Conexao();

            c.Abrir();

            MySqlDataReader reader = c.Pesquisar(cmd);

            List<Turma> lstRetorno = new List<Turma>();

            while (reader.Read())
            {
                Turma turma = new Turma();

                turma.idTurma = reader.GetInt32(0);
                turma.Nome = reader.GetString(1);

                lstRetorno.Add(turma);

            }

            c.Fechar();

            return lstRetorno;

        }
    }
}
