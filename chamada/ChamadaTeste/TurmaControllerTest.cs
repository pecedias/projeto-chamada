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
            // ================ AÇÃO ===================== //

            //chama metodod incluir
            t.Incluir(turma);
            List<Turma> consulta = t.ListarByName(turma);

            // ================ VALIDAÇÃO ===================== //
            Assert.IsNotEmpty(consulta);
        }

        [Test]
        public void Atualizar()
        {
            // ================ CENTARIO ===================== //
            //pega uma turma
             TurmaController t = new TurmaController();
             Turma turma = t.Listar(new Turma())[0];

            string nome = "Atualizado";
            Turma updated = new Turma();
            updated.idTurma = turma.idTurma;
            updated.Nome = turma.Nome;

            // ================ AÇÃO ===================== //

            updated.Nome = nome;
            t.Atualizar(updated);

            List<Turma> consulta = t.ListarByName(updated);

            // ================ VALIDAÇÃO ===================== //
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

            // ================ AÇÃO ===================== //

            t.Excluir(turma);
            List<Turma> consulta = t.ListarByName(turma);

            // ================ VALIDAÇÃO ===================== //
            //verificacao
            Assert.IsEmpty(consulta);
        }

        [Test]
        public void Listar()
        {
            // ================ CENTARIO ===================== //
            //pega uma turma
            TurmaController t = new TurmaController();

            // ================ AÇÃO ===================== //

            List<Turma> alunos = t.Listar(new Turma());

            // ================ VALIDAÇÃO ===================== //
            //verificacao
            Assert.IsNotEmpty(alunos);
            Assert.AreNotEqual(0, alunos.Count);
        }

    }
}