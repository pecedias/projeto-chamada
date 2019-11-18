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

            if (objEntrada.idTurma.idTurma.Equals(null))
            {
                throw new ConsistenciaException("Por favor, informe a Turma");
            }

            MySqlCommand cmd = new MySqlCommand(@"insert into aula values(
                 default,
                 @idProfessor,
                 @idTurma,
                 @Nome)");

            cmd.Parameters.Add(new MySqlParameter("idProfessor", objEntrada.idProfessor.idProfessor));
            cmd.Parameters.Add(new MySqlParameter("Nome", objEntrada.Nome));
            cmd.Parameters.Add(new MySqlParameter("idTurma", objEntrada.idTurma.idTurma));
            
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

            MySqlCommand cmd = new MySqlCommand(@"update aula
                 set 
                     idProfessor = @idProfessor,        
                     idTurma = @idTurma,
                     Nome = @Nome
               where idAula = @idAula
             ");

            cmd.Parameters.Add(new MySqlParameter("idProfessor", objEntrada.idProfessor.idProfessor));
            cmd.Parameters.Add(new MySqlParameter("idTurma", objEntrada.idTurma.idTurma));
            cmd.Parameters.Add(new MySqlParameter("Nome", objEntrada.Nome));
            cmd.Parameters.Add(new MySqlParameter("idAula", objEntrada.idAula));

            Conexao c = new Conexao();
            c.Abrir();
            c.Executar(cmd);
            c.Fechar();

        }

        public void Excluir(Aula objEntrada)
        {

            MySqlCommand cmd = new MySqlCommand("delete from aula where idAula = @idAula");

            cmd.Parameters.Add(new MySqlParameter("idAula", objEntrada.idAula));

            Conexao c = new Conexao();
            c.Abrir();
            c.Executar(cmd);
            c.Fechar();

        }

        public List<Aula> Listar(Aula objEntrada)
        {

            MySqlCommand cmd = null;

            cmd = new MySqlCommand(@"
                 select aula.idAula,
                        professor.Nome,
                        turma.Nome,
                        aula.Nome
                        from aula
                        inner join professor
                        on professor.idProfessor = aula.idProfessor
                        inner join turma
                        on turma.idTurma = aula.idTurma
            ");

            Conexao c = new Conexao();

            c.Abrir();

            MySqlDataReader reader = c.Pesquisar(cmd);

            List<Aula> lstRetorno = new List<Aula>();

            while (reader.Read())
            {
                Aula aula = new Aula();
                Professor professor = new Professor();
                Turma turma = new Turma();

                aula.idAula = reader.GetInt32(0);
                professor.Nome = reader.GetString(1);
                turma.Nome = reader.GetString(2);
                aula.Nome = reader.GetString(3);

                aula.idProfessor = professor;
                aula.idTurma = turma;

                lstRetorno.Add(aula);

            }

            c.Fechar();

            return lstRetorno;

        }

        public List<Aula> ListarByName(Aula objEntrada)
        {

            MySqlCommand cmd = null;

            cmd = new MySqlCommand(@"
                 select aula.idAula,
                        professor.Nome,
                        turma.Nome,
                        aula.Nome
                        from aula
                        inner join professor
                        on professor.idProfessor = aula.idProfessor
                        inner join turma
                        on turma.idTurma = aula.idTurma where aula.Nome = @Nome
            ");
            cmd.Parameters.Add(new MySqlParameter("Nome", objEntrada.Nome));
            Conexao c = new Conexao();

            c.Abrir();

            MySqlDataReader reader = c.Pesquisar(cmd);

            List<Aula> lstRetorno = new List<Aula>();

            while (reader.Read())
            {
                Aula aula = new Aula();
                Professor professor = new Professor();
                Turma turma = new Turma();

                aula.idAula = reader.GetInt32(0);
                professor.Nome = reader.GetString(1);
                turma.Nome = reader.GetString(2);
                aula.Nome = reader.GetString(3);

                aula.idProfessor = professor;
                aula.idTurma = turma;

                lstRetorno.Add(aula);

            }

            c.Fechar();

            return lstRetorno;

        }
        public List<Aula> ListarById(Aula objEntrada)
        {

            MySqlCommand cmd = null;

            cmd = new MySqlCommand(@"
                 select aula.idAula,
                        professor.Nome,
                        turma.Nome,
                        aula.Nome
                        from aula
                        inner join professor
                        on professor.idProfessor = aula.idProfessor
                        inner join turma
                        on turma.idTurma = aula.idTurma where aula.idAula = @Nome
            ");
            cmd.Parameters.Add(new MySqlParameter("Nome", objEntrada.idAula));
            Conexao c = new Conexao();

            c.Abrir();

            MySqlDataReader reader = c.Pesquisar(cmd);

            List<Aula> lstRetorno = new List<Aula>();

            while (reader.Read())
            {
                Aula aula = new Aula();
                Professor professor = new Professor();
                Turma turma = new Turma();

                aula.idAula = reader.GetInt32(0);
                professor.Nome = reader.GetString(1);
                turma.Nome = reader.GetString(2);
                aula.Nome = reader.GetString(3);

                aula.idProfessor = professor;
                aula.idTurma = turma;

                lstRetorno.Add(aula);

            }

            c.Fechar();

            return lstRetorno;

        }

    }
}
