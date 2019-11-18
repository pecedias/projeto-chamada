using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using Model;

namespace Controller
{
    public class AlunoController
    {

        public void Incluir(Aluno objEntrada)
        {

            if (String.IsNullOrEmpty(objEntrada.Nome))
            {
                throw new ConsistenciaException("Por favor, digite o nome do aluno.");
            }

            if (objEntrada.Matricula.Equals(null))
            {
                throw new ConsistenciaException("Por favor, informa a matricula do Aluno");
            }

            MySqlCommand cmd = new MySqlCommand(@"insert into aluno (idAluno, idTurma, Matricula, Nome) values(
                 default,
                 @idTurma,
                 @Matricula,
                 @Nome)"
            );

            cmd.Parameters.Add(new MySqlParameter("idAluno", objEntrada.idAluno));
            cmd.Parameters.Add(new MySqlParameter("idTurma", objEntrada.idTurma.idTurma));
            cmd.Parameters.Add(new MySqlParameter("Matricula", objEntrada.Matricula));
            cmd.Parameters.Add(new MySqlParameter("Nome", objEntrada.Nome));

            Conexao c = new Conexao();
            c.Abrir();
            c.Executar(cmd);
            c.Fechar();

        }

        public void Atualizar(Aluno objEntrada)
        {

            if (String.IsNullOrEmpty(objEntrada.Nome))
            {
                throw new ConsistenciaException("Por favor, digite o nome do aluno.");
            }

            if (objEntrada.Matricula.Equals(null))
            {
                throw new ConsistenciaException("Por favor, informa a matricula do Aluno.");
            }

            if (objEntrada.idTurma.Equals(null))
            {
                throw new ConsistenciaException("Por favor, inserir uma turma");
            }

            MySqlCommand cmd = new MySqlCommand(@"update aluno
                 set Nome = @Nome,
                     Matricula = @Matricula,
                     idTurma = @idTurma
               where idAluno = @idAluno
             ");

            cmd.Parameters.Add(new MySqlParameter("Nome", objEntrada.Nome));
            cmd.Parameters.Add(new MySqlParameter("Matricula", objEntrada.Matricula));
            cmd.Parameters.Add(new MySqlParameter("idTurma", objEntrada.idTurma.idTurma));
            cmd.Parameters.Add(new MySqlParameter("idAluno", objEntrada.idAluno));

            Conexao c = new Conexao();
            c.Abrir();
            c.Executar(cmd);
            c.Fechar();

        }

        public void Excluir(Aluno objEntrada)
        {

            MySqlCommand cmd = new MySqlCommand("delete from aluno where idAluno = @idAluno");

            cmd.Parameters.Add(new MySqlParameter("idAluno", objEntrada.idAluno));

            Conexao c = new Conexao();
            c.Abrir();
            c.Executar(cmd);
            c.Fechar();

        }

        public List<Aluno> Listar(Aluno objEntrada)
        {

            MySqlCommand cmd = null;

            cmd = new MySqlCommand(@"
                 select aluno.idAluno,
                        aluno.Nome,
                        aluno.Matricula,
                        turma.Nome
                   from aluno
                   inner join turma 
                   on turma.idTurma = aluno.idTurma") ;
            cmd.Parameters.Add(new MySqlParameter("Matricula", objEntrada.Matricula));
            Conexao c = new Conexao();

            c.Abrir();

            MySqlDataReader reader = c.Pesquisar(cmd);

            List<Aluno> lstRetorno = new List<Aluno>();

            while (reader.Read())
            {
                Aluno aluno = new Aluno();
                Turma turma = new Turma();

                aluno.idAluno = reader.GetInt32(0);
                aluno.Nome = reader.GetString(1);
                aluno.Matricula = reader.GetInt32(2);
                turma.Nome = reader.GetString(3);

                aluno.idTurma = turma;

                lstRetorno.Add(aluno);

            }

            c.Fechar();

            return lstRetorno;

        }

        public List<Aluno> ListarByMatricula(Aluno objEntrada)
        {

            MySqlCommand cmd = null;

            cmd = new MySqlCommand(@"
                 select aluno.idAluno,
                        aluno.Nome,
                        aluno.Matricula,
                        turma.Nome
                   from aluno
                   inner join turma 
                   on turma.idTurma = aluno.idTurma where aluno.Matricula = @Matricula");
            cmd.Parameters.Add(new MySqlParameter("Matricula", objEntrada.Matricula));
            Conexao c = new Conexao();

            c.Abrir();

            MySqlDataReader reader = c.Pesquisar(cmd);

            List<Aluno> lstRetorno = new List<Aluno>();

            while (reader.Read())
            {
                Aluno aluno = new Aluno();
                Turma turma = new Turma();

                aluno.idAluno = reader.GetInt32(0);
                aluno.Nome = reader.GetString(1);
                aluno.Matricula = reader.GetInt32(2);
                turma.Nome = reader.GetString(3);

                aluno.idTurma = turma;

                lstRetorno.Add(aluno);

            }

            c.Fechar();

            return lstRetorno;

        }


        public List<Aluno> ListarById(Aluno objEntrada)
        {

            MySqlCommand cmd = null;

            cmd = new MySqlCommand(@"
                 select aluno.idAluno,
                        aluno.Nome,
                        aluno.Matricula,
                        turma.Nome
                   from aluno
                   inner join turma 
                   on turma.idTurma = aluno.idTurma where aluno.idAluno = @idAluno");
            cmd.Parameters.Add(new MySqlParameter("idAluno", objEntrada.idAluno));
            Conexao c = new Conexao();

            c.Abrir();

            MySqlDataReader reader = c.Pesquisar(cmd);

            List<Aluno> lstRetorno = new List<Aluno>();

            while (reader.Read())
            {
                Aluno aluno = new Aluno();
                Turma turma = new Turma();

                aluno.idAluno = reader.GetInt32(0);
                aluno.Nome = reader.GetString(1);
                aluno.Matricula = reader.GetInt32(2);
                turma.Nome = reader.GetString(3);

                aluno.idTurma = turma;

                lstRetorno.Add(aluno);

            }

            c.Fechar();

            return lstRetorno;

        }

    }
}
