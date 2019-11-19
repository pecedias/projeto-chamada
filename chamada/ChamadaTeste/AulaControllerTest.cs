using NUnit.Framework;
using Model;
using Controller;
using System.Collections.Generic;
using System.Security.Permissions;
using System.Configuration;
using System.Management;

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

            // ================ AÇÃO ===================== //

            //chama metodod incluir
            AulaController aulac = new AulaController();
            aulac.Incluir(aula);
            List<Aula> consulta = aulac.ListarByName(aula);

            // ================ VALIDAÇÃO ===================== //
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
            string nome = "Joao";
            Aula att = new Aula();
            att.Nome = aulas[0].Nome;
            att.idAula = aulas[0].idAula;
            att.idProfessor = aulas[0].idProfessor;
            att.idTurma = aulas[0].idTurma;

            // ================ AÇÃO ===================== //

            att.Nome = nome;
            t.Atualizar(att);


            Aula consulta = t.ListarByName(att)[0];

            // ================ VALIDAÇÃO ===================== //
            //verificacao
            Assert.IsTrue(consulta.Nome == nome);
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

            // ================ AÇÃO ===================== //

            t.Excluir(att);
            List<Aula> consulta = t.ListarById(att);

            // ================ VALIDAÇÃO ===================== //
            //verificacao
            Assert.IsEmpty(consulta);
        }

        [Test]
        public void Listar()
        {
            // ================ CENTARIO ===================== //
            //pega uma turma
            AulaController t = new AulaController();

            // ================ AÇÃO ===================== //

            List<Aula> aulas = t.Listar(new Aula());

            // ================ VALIDAÇÃO ===================== //
            //verificacao
            Assert.IsNotEmpty(aulas);
            Assert.AreNotEqual(0, aulas.Count);
        }

        [Test]
        public void ListarById()
        {
            // ================ CENTARIO ===================== //
            //pega uma turma
            AulaController t = new AulaController();
            Aula a = Aula() {
                idAula = 1;
            }

            // ================ AÇÃO ===================== //

            List<Aula> aulas = t.Listar(a.idAula);

            // ================ VALIDAÇÃO ===================== //
            //verificacao
            Assert.IsNotEmpty(aulas);
            Assert.AreEqual(aulas[0].idAula, a.idAula);
        }

        [Test]
        public void ListarByName()
        {
            // ================ CENTARIO ===================== //
            //pega uma turma
            AulaController t = new AulaController();
            Aula a = Aula() {
                nome = "Ads-05";
            }

            // ================ AÇÃO ===================== //

            List<Aula> aulas = t.ListarByName(a.nome);

            // ================ VALIDAÇÃO ===================== //
            //verificacao
            Assert.IsNotEmpty(aulas);
            Assert.AreEqual(aulas[0].nome, a.nome);
        }

    }
}