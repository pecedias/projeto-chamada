using NUnit.Framework;
using Model;
using Controller;
using System.Collections.Generic;
using System.Security.Permissions;
using System.Configuration;
using System.Management;

namespace Tests
{
    public class TurmaControllerTest
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
            Turma turma = new Turma();
            turma.Nome = "Ads";
            // ================ A플O ===================== //

            //chama metodod incluir
            t.Incluir(turma);
            List<Turma> consulta = t.ListarByName(turma);

            // ================ VALIDA플O ===================== //
            Assert.IsNotEmpty(consulta);
        }

        [Test]
        public void Atualizar()
        {
            // ================ CENTARIO ===================== //
            //pega uma turma
            TurmaController t = new TurmaController();
            Turma turma = t.Listar(new Turma())[0];

            string nome = "Adm";
            Turma updated = new Turma();
            updated.idTurma = turma.idTurma;
            updated.Nome = turma.Nome;

            // ================ A플O ===================== //

            updated.Nome = nome;
            t.Atualizar(updated);

            List<Turma> consulta = t.ListarByName(updated);

            // ================ VALIDA플O ===================== //
            Assert.IsNotEmpty(consulta);
            Assert.IsNotNull(consulta[0].Nome);
            Assert.IsTrue(consulta[0].Nome == nome);

        }

        [Test]
        public void Deletar()
        {
            // ================ CENTARIO ===================== //
            //pega uma turma
            TurmaController t = new TurmaController();
            Turma turma = t.Listar(new Turma())[0];

            // ================ A플O ===================== //

            t.Excluir(turma);
            List<Turma> consulta = t.ListarByName(turma);

            // ================ VALIDA플O ===================== //
            //verificacao
            Assert.IsEmpty(consulta);
        }

        [Test]
        public void Listar()
        {
            // ================ CENTARIO ===================== //
            //pega uma turma
            TurmaController t = new TurmaController();

            // ================ A플O ===================== //

            List<Turma> turmas = t.Listar(new Turma());

            // ================ VALIDA플O ===================== //
            //verificacao
            Assert.IsNotEmpty(turmas);
            Assert.AreNotEqual(0, turmas.Count);
        }

        [Test]
        public void ListarById()
        {
            // ================ CENTARIO ===================== //
            //pega uma turma
            TurmaController t = new TurmaController();
            Turma t1 = new Turma();

            t1.idTurma = 1;
            

            // ================ A플O ===================== //

            List<Turma> turmas = t.Listar(t1);

            // ================ VALIDA플O ===================== //
            //verificacao
            Assert.IsNotEmpty(turmas);
            Assert.AreEqual(turmas[0].idTurma, t1.idTurma);
        }

        [Test]
        public void ListarByName()
        {
            // ================ CENTARIO ===================== //
            //pega uma turma
            TurmaController t = new TurmaController();
            Turma t1 = new Turma();

            t1.Nome = "ADS";
            

            // ================ A플O ===================== //

            List<Turma> turmas = t.ListarByName(t1);

            // ================ VALIDA플O ===================== //
            //verificacao
            Assert.IsNotEmpty(turmas);
            Assert.AreEqual(turmas[0].Nome, t1.Nome);
        }

    }
}