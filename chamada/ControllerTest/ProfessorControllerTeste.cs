using NUnit.Framework;
using Model;
using Controller;
using System.Collections.Generic;
using System.Security.Permissions;
using System.Configuration;
using System.Management;

namespace Tests
{
    public class ProfessorControllerTest
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void Logar()
        {
            // ================ CENTARIO ===================== //
            ProfessorController pc = new ProfessorController();
            Professor p = new Professor();
            p.Nome = "João";
            p.Senha = "12345";
            p.Email = "teste@teste.com";



            // ================ AÇÃO ===================== //

            //chama metodo de logar
            Professor logado = pc.Logar(p);


            // ================ VALIDAÇÃO ===================== //
            //verificacao
            Assert.IsNotNull(logado);
            Assert.AreEqual(p.Email, logado.Email);

        }

        [Test]
        public void Listar()
        {
            // ================ CENTARIO ===================== //
            ProfessorController pc = new ProfessorController();

            // ================ AÇÃO ===================== //

            //chama metodo de logar
            List<Professor> logado = pc.Listar(new Professor());


            // ================ VALIDAÇÃO ===================== //
            //verificacao
            Assert.IsNotEmpty(logado);

        }

        [Test]
        public void ListarById()
        {
            // ================ CENTARIO ===================== //
            ProfessorController pc = new ProfessorController();
            Professor pf = new Professor();

            pf.idProfessor = 1;
            

            // ================ AÇÃO ===================== //

            //chama metodo de logar
            List<Professor> professor = pc.Listar(pf);


            // ================ VALIDAÇÃO ===================== //
            //verificacao
            Assert.IsNotEmpty(professor);
            Assert.AreEqual(professor[0].idProfessor, pf.idProfessor);

        }


    }
}