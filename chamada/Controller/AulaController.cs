using System;
using MySql.Data.MySqlClient;
using Model;

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

            MySqlCommand cmd = new MySqlCommand(@"insert into Unidade values(
                 default,
                 @Nome,
                 @Estado,
                 @idUsuario)");

            cmd.Parameters.Add(new MySqlParameter("Nome", objEntrada.Nome));
            cmd.Parameters.Add(new MySqlParameter("Estado", objEntrada.idAula));
            cmd.Parameters.Add(new MySqlParameter("idUsuario", objEntrada.idProfessor.idProfessor));

            Conexao c = new Conexao();
            c.Abrir();
            c.Executar(cmd);
            c.Fechar();

        }

    }
}
