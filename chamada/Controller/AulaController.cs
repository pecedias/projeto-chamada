using System;
using MySql.Data.MySqlClient;
using Model;
using System.Collections.Generic;

namespace Controller
{
    public class AulaController
    {

        public void Incluir(Aula objEntrada)
        {

            if (String.IsNullOrEmpty(objEntrada.Nome))
            {
                throw new ConsistenciaException("Por favor, digite o nome da Aula.");
            }

            if (objEntrada.idTurma.Equals(null))
            {
                throw new ConsistenciaException("Por favor, informe a Turma");
            }

            if (objEntrada.idProfessor.Equals(null))
            {
                throw new ConsistenciaException("Por favor, informa um Professor");
            }

            MySqlCommand cmd = new MySqlCommand(@"insert into Aula values(
                 default,
                 @Nome,
                 @idTurma,
                 @idProfessor)");

            cmd.Parameters.Add(new MySqlParameter("idAula", objEntrada.idAula));
            cmd.Parameters.Add(new MySqlParameter("Nome", objEntrada.Nome));
            cmd.Parameters.Add(new MySqlParameter("Estado", objEntrada.idTurma.idTurma));
            cmd.Parameters.Add(new MySqlParameter("idProfessor", objEntrada.idProfessor.idProfessor));

            Conexao c = new Conexao();
            c.Abrir();
            c.Executar(cmd);
            c.Fechar();

        }

        public void Atualizar(Aula objEntrada)
        {

            if (String.IsNullOrEmpty(objEntrada.Nome))
            {
                throw new ConsistenciaException("Por favor, digite o nome da Aula.");
            }

            if (objEntrada.idTurma.Equals(null))
            {
                throw new ConsistenciaException("Por favor, informe a Turma");
            }

            if (objEntrada.idProfessor.Equals(null))
            {
                throw new ConsistenciaException("Por favor, informa um Professor");
            }

            MySqlCommand cmd = new MySqlCommand(@"update Aula
                 set Nome = @Nome,
                     idTurma = @idTurma,
                     idProfessor = @idProfessor
               where idAula = @idAula
             ");

            cmd.Parameters.Add(new MySqlParameter("idAula", objEntrada.idAula));
            cmd.Parameters.Add(new MySqlParameter("Nome", objEntrada.Nome));
            cmd.Parameters.Add(new MySqlParameter("Estado", objEntrada.idTurma.idTurma));
            cmd.Parameters.Add(new MySqlParameter("idProfessor", objEntrada.idProfessor.idProfessor));

            Conexao c = new Conexao();
            c.Abrir();
            c.Executar(cmd);
            c.Fechar();

        }

        public void Excluir(Aula objEntrada)
        {

            MySqlCommand cmd = new MySqlCommand("delete from Aula where idAula = @idAula");

            cmd.Parameters.Add(new MySqlParameter("idAluno", objEntrada.idAula));

            Conexao c = new Conexao();
            c.Abrir();
            c.Executar(cmd);
            c.Fechar();

        }

        public List<Aula> Listar(Aula objEntrada)
        {

            MySqlCommand cmd = null;

            cmd = new MySqlCommand(@"
                 select Aula.idAula,
                        Aula.idProfessor,
                        Aula.idTurma,
                        Aula.Nome
                        from Aula
                        inner join Professor
                        on Professor.idProfessor = Aula.idProfessor
                        inner join Turma
                        on Turma.idTurma = Aula.idTurma
            ");

            Conexao c = new Conexao();

            c.Abrir();

            MySqlDataReader reader = c.Pesquisar(cmd);

            List<Aula> lstRetorno = new List<Aula>();

            while (reader.Read())
            {
                Aula aula = new Aula();

                aula.idAula = reader.GetInt32(0);
                aula.idProfessor.Nome = reader.GetString(1);
                aula.idTurma.Nome = reader.GetString(2);
                aula.Nome = reader.GetString(3);

                lstRetorno.Add(aula);

            }

            c.Fechar();

            return lstRetorno;

        }

    }
}
