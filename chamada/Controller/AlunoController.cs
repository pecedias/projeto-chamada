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

            MySqlCommand cmd = new MySqlCommand(@"update Aluno
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

            MySqlCommand cmd = new MySqlCommand("delete from Aluno where idAluno = @idAluno");

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
                 select Aluno.idAluno,
                        Aluno.Nome,
                        Aluno.Matricula,
                        Aluno.idTurma
                   from Aluno
                   inner join Turma 
                   on Turma.idTurma = Aluno.idTurma");
           
            Conexao c = new Conexao();

            c.Abrir();

            MySqlDataReader reader = c.Pesquisar(cmd);

            List<Aluno> lstRetorno = new List<Aluno>();

            while (reader.Read())
            {
                Aluno aluno = new Aluno();

                aluno.idAluno = reader.GetInt32(0);
                aluno.Nome = reader.GetString(1);
                aluno.Matricula = reader.GetInt32(2);
                aluno.idTurma.Nome = reader.GetString(3);
                

                lstRetorno.Add(aluno);

            }

            c.Fechar();

            return lstRetorno;

        }

    }
}
