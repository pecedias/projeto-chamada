using System;
using System.Collections.Generic;
using Model;
using MySql.Data.MySqlClient;

namespace Controller
{
    public class ProfessorController
    {
        public Professor Logar(Professor objEntrada)
        {

            Conexao conx = new Conexao();

            MySqlCommand cmd = new MySqlCommand(@"
                select idProfessor,
                       Nome,
                       Email,
                       Senha
                  from professor
                 where Email = @Email
                   and Senha = md5(@Senha)");

            conx.Abrir();

            cmd.Parameters.Add(new MySqlParameter("Email", objEntrada.Email)); ;
            cmd.Parameters.Add(new MySqlParameter("Senha", objEntrada.Senha));

            MySqlDataReader reader = conx.Pesquisar(cmd);

            if (!reader.Read())
            {
                conx.Fechar();
                throw new ConsistenciaException("Usuario ou senha inválido!");
            }

            Professor p = new Professor();

            p.idProfessor = reader.GetInt32(0);
            p.Nome = reader.GetString(1);
            p.Email = reader.GetString(2);
            p.Senha = reader.GetString(3);

            reader.Close();

            return p;
        }

        public List<Professor> Listar(Professor objEntrada)
        {

            MySqlCommand cmd = null;

            if (objEntrada.idProfessor != 0)
            {

                cmd = new MySqlCommand(@"
                 select Professor.idProfessor,
                        Professor.Nome,
                        Professor.Email
                   from Professor
                   where Professor.idProfessor = @idProfessor");

                cmd.Parameters.Add(new MySqlParameter("idProfessor", objEntrada.idProfessor));

            }
            else
            {
                cmd = new MySqlCommand(@"
                 select professor.idProfessor, 
                    professor.Nome, 
                    professor.Email 
                    from Professor");
            }

            Conexao c = new Conexao();

            c.Abrir();

            MySqlDataReader reader = c.Pesquisar(cmd);

            List<Professor> lstRetorno = new List<Professor>();

            while (reader.Read())
            {
                Professor professor = new Professor();

                professor.idProfessor = reader.GetInt32(0);
                professor.Nome = reader.GetString(1);
                professor.Email = reader.GetString(2);

                lstRetorno.Add(professor);

            }

            c.Fechar();

            return lstRetorno;

        }
    }


}
