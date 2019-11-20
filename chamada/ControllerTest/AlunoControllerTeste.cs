using NUnit.Framework;
using Model;
using Controller;
using System.Collections.Generic;
using System.Security.Permissions;
using System.Configuration;

namespace Tests
{
    public class AlunoControllerTest
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void Incluir()
        {
            // ================ CENTARIO ===================== //
            //pega uma turma
            TurmaController t = new TurmaController();
            List<Turma> turma = t.Listar(new Turma());

            //cria um aluno
            Aluno aluno = new Aluno();
            aluno.Foto = 12;
            aluno.Matricula = 123;
            aluno.Nome = "Rubiao";
            aluno.idTurma = turma[0];
            // ================ A��O ===================== //

            //chama metodod incluir
            AlunoController alunoControl = new AlunoController();
            alunoControl.Incluir(aluno);

            // ================ VALIDA��O ===================== //
            Assert.IsNotNull(alunoControl.ListarByMatricula(aluno));
        }

        [Test]
        public void Atualizar()
        {
            // ================ CENTARIO ===================== //
            //pega uma turma
            AlunoController t = new AlunoController();
            List<Aluno> alunos = t.Listar(new Aluno());
            Aluno att = new Aluno();
            att.Nome = "Joao";
            Turma turma = new Turma();
            turma.idTurma = 1;
            att.idAluno = 1;
            att.idTurma = turma;
            att.Matricula = 123;

            // ================ A��O ===================== //

            t.Atualizar(att);


            Aluno consulta = t.ListarById(att)[0];

            // ================ VALIDA��O ===================== //
            //verificacao
            Assert.IsNotNull(consulta.Nome);
            Assert.AreEqual(att.idAluno, consulta.idAluno);
        }

        [Test]
        public void Deletar()
        {
            // ================ CENTARIO ===================== //
            //pega uma turma
            AlunoController t = new AlunoController();
            List<Aluno> alunos = t.Listar(new Aluno());
            Aluno att = new Aluno();
            Turma turma = new Turma();
            turma.idTurma = 1;
            att.Nome = "Joao";
            att.idAluno = 1;
            att.idTurma = turma;
            att.Matricula = 123;

            // ================ A��O ===================== //

            t.Excluir(att);
            List<Aluno> consulta = t.ListarById(att);

            // ================ VALIDA��O ===================== //
            //verificacao
            Assert.IsEmpty(consulta);
        }

        [Test]
        public void Listar()
        {
            // ================ CENTARIO ===================== //
            //pega uma turma
            AlunoController t = new AlunoController();

            // ================ A��O ===================== //

            List<Aluno> alunos = t.Listar(new Aluno());

            // ================ VALIDA��O ===================== //
            //verificacao
            Assert.IsNotEmpty(alunos);
            Assert.AreNotEqual(0, alunos.Count);
        }

        [Test]
        public void ListarById()
        {
            // ================ CENTARIO ===================== //
            //pega uma turma

            Turma turma = new Turma();

            turma.idTurma = 1;
            turma.Nome = "ADS";

            AlunoController t = new AlunoController();
            Aluno a = new Aluno();

            a.idAluno = 1;
            a.idTurma = turma;
            a.Matricula = 123;
            a.Nome = "Joao";

            // ================ A��O ===================== //

            List<Aluno> alunos = t.ListarById(a);

            // ================ VALIDA��O ===================== //
            //verificacao
            Assert.IsNotEmpty(alunos);
            Assert.AreEqual(alunos[0].idAluno, a.idAluno);
        }

        [Test]
        public void ListarByMatricula()
        {
            // ================ CENTARIO ===================== //
            //pega uma turma

            Turma turma = new Turma();

            turma.idTurma = 1;
            turma.Nome = "ADS";

            AlunoController t = new AlunoController();
            Aluno a = new Aluno();

            a.idAluno = 1;
            a.idTurma = turma;
            a.Matricula = 123;
            a.Nome = "Jo�o";

            // ================ A��O ===================== //

            List<Aluno> alunos = t.ListarByMatricula(a);

            // ================ VALIDA��O ===================== //
            //verificacao
            Assert.IsNotEmpty(alunos);
            Assert.AreEqual(alunos[0].Matricula, a.Matricula);
        }

    }
}