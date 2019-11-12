using System;
using System.Collections.Generic;
using Model;
using MySql.Data.MySqlClient;

namespace Controller
{
    class ProfessorController
    {
        public Professor Logar(Professor objEntrada)
        {

            if (String.IsNullOrEmpty(objEntrada.Email))
                throw new ConsistenciaException("Por favor, preencha o campo E-mail!");

            if (String.IsNullOrEmpty(objEntrada.Senha))
                throw new ConsistenciaException("Por favor, prencha o campo senha!");

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

            cmd.Parameters.Add(new MySqlParameter("Cpf", objEntrada.Email)); ;
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

            cmd = new MySqlCommand(@"
                select distinct pagina.idPagina,
                       pagina.url,
	                   pagina.descricao,
                       pagina.idPai
                  from pagina
                 inner join modulo_pagina on modulo_pagina.idPagina = pagina.idPagina
                 inner join Modulo on modulo_pagina.idModulo = modulo.idModulo
                 inner join usuario_modulo on modulo.idModulo = usuario_modulo.idModulo
                 where usuario_modulo.idUsuario = @IdUsuario");

            cmd.Parameters.Add(new MySqlParameter("IdUsuario", p.idProfessor));

            reader = conx.Pesquisar(cmd);

            while (reader.Read())
            {

                Pagina pag = new Pagina();

                pag.idPagina = reader.GetInt32(0);

                if (reader["url"] != DBNull.Value)
                    pag.url = reader.GetString(1);

                pag.descricao = reader.GetString(2);

                if (reader["idPai"] != DBNull.Value)
                    pag.idPai = reader.GetInt32(3);

                p.listaPaginaAcesso.Add(pag);

            }

            conx.Fechar();

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
