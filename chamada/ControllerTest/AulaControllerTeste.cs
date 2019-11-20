using NUnit.Framework;
using Model;
using Controller;
using System.Collections.Generic;
using System;

namespace Tests
{
    public class AulaControllerTest
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void Incluir()
        {
            // ================ CENTARIO ===================== //
            //pega uma Professor
            ProfessorController pc = new ProfessorController();
            Professor p = pc.Listar(new Professor())[0];

            TurmaController tc = new TurmaController();
            Turma t = tc.Listar(new Turma())[0];


            Aula aula = new Aula();
            aula.idProfessor = p;
            aula.idTurma = t;
            aula.Nome = "ADS-05";

            // ================ A플O ===================== //

            //chama metodod incluir
            AulaController aulac = new AulaController();
            aulac.Incluir(aula);
            List<Aula> consulta = aulac.ListarByName(aula);

            // ================ VALIDA플O ===================== //
            //verificacao
            Assert.IsNotEmpty(consulta);
            Assert.IsTrue(consulta[0].Nome == aula.Nome);
        }

        [Test]
        public void Atualizar()
        {
            // ================ CENTARIO ===================== //
            //pega uma turma
            AulaController t = new AulaController();
            List<Aula> aulas = t.Listar(new Aula());
            Professor prof = new Professor();
            Turma turma = new Turma();
            turma.idTurma = 1;
            prof.idProfessor = 1;
            Aula att = new Aula();
            att.Nome = "Analise";
            att.idAula = 1;
            att.idProfessor = prof;
            att.idTurma = turma;

            // ================ A플O ===================== //

            t.Atualizar(att);


            Aula consulta = t.ListarByName(att)[0];

            // ================ VALIDA플O ===================== //
            //verificacao
            Assert.IsNotNull(consulta.Nome);
            Assert.AreEqual(att.idAula, consulta.idAula);
        }

        [Test]
        public void Deletar()
        {
            // ================ CENTARIO ===================== //
            //pega uma turma
            AulaController t = new AulaController();
            List<Aula> aulas = t.Listar(new Aula());
            Aula att = new Aula();
            att.Nome = aulas[0].Nome;
            att.idAula = aulas[0].idAula;
            att.idProfessor = aulas[0].idProfessor;
            att.idTurma = aulas[0].idTurma;

            // ================ A플O ===================== //

            t.Excluir(att);
            List<Aula> consulta = t.ListarById(att);

            // ================ VALIDA플O ===================== //
            //verificacao
            Assert.IsEmpty(consulta);
        }

        [Test]
        public void Listar()
        {
            // ================ CENTARIO ===================== //
            //pega uma turma
            AulaController t = new AulaController();

            // ================ A플O ===================== //

            List<Aula> aulas = t.Listar(new Aula());

            // ================ VALIDA플O ===================== //
            //verificacao
            Assert.IsNotEmpty(aulas);
            Assert.AreNotEqual(0, aulas.Count);
        }

        [Test]
        public void ListarById()
        {
            // ================ CENTARIO ===================== //
            //pega uma turma

            Turma turma = new Turma();

            turma.idTurma = 1;

            Professor prof = new Professor();

            prof.idProfessor = 1;

            AulaController t = new AulaController();
            Aula a = new Aula();

            a.idAula = 1;

            // ================ A플O ===================== //

            List<Aula> aulas = t.ListarById(a);

            // ================ VALIDA플O ===================== //
            //verificacao
            Assert.IsNotEmpty(aulas);
            Assert.AreEqual(aulas[0].idAula, a.idAula);
        }

        [Test]
        public void ListarByName()
        {
            // ================ CENTARIO ===================== //
            //pega uma turma

            Turma turma = new Turma();

            turma.idTurma = 1;
            turma.Nome = "ADS";

            Professor prof = new Professor();

            prof.idProfessor = 1;
            prof.Nome = "Victor";
            prof.Email = "teste1@teste.com";
            prof.Senha = "12345";

            AulaController t = new AulaController();
            Model.Aula a = new Model.Aula();

            a.idAula = 1;
            a.idProfessor = prof;
            a.idTurma = turma;
            a.Nome = "ADS-05";

            // ================ A플O ===================== //

            List<Aula> aulas = t.ListarByName(a);

            // ================ VALIDA플O ===================== //
            //verificacao
            Assert.IsNotEmpty(aulas);
            Assert.AreEqual(aulas[0].Nome, a.Nome);
        }

    }
}