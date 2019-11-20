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
            p.Nome = "Jo�o";
            p.Senha = "12345";
            p.Email = "teste@teste.com";



            // ================ A��O ===================== //

            //chama metodo de logar
            Professor logado = pc.Logar(p);


            // ================ VALIDA��O ===================== //
            //verificacao
            Assert.IsNotNull(logado);
            Assert.AreEqual(p.Email, logado.Email);

        }

        [Test]
        public void Listar()
        {
            // ================ CENTARIO ===================== //
            ProfessorController pc = new ProfessorController();

            // ================ A��O ===================== //

            //chama metodo de logar
            List<Professor> logado = pc.Listar(new Professor());


            // ================ VALIDA��O ===================== //
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
            

            // ================ A��O ===================== //

            //chama metodo de logar
            List<Professor> professor = pc.Listar(pf);


            // ================ VALIDA��O ===================== //
            //verificacao
            Assert.IsNotEmpty(professor);
            Assert.AreEqual(professor[0].idProfessor, pf.idProfessor);

        }


    }
}