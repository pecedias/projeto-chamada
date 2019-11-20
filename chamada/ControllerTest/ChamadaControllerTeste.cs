using NUnit.Framework;
using Model;
using Controller;
using System.Collections.Generic;
using System.Security.Permissions;
using System.Configuration;
using System.Management;

namespace Tests
{
    public class ChamadaControllerTest
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void ListarPresen�a()
        {
            // ================ CENTARIO ===================== //
            ChamadaController pc = new ChamadaController();
            Aula aula = new Aula();
            aula.idAula = 1;
            Chamada cha = new Chamada();
            cha.idAula = aula;


            // ================ A��O ===================== //

            //chama metodod incluir
            List<Chamada> lista = pc.ListarPresenca(cha);


            // ================ VALIDA��O ===================== //
            //verificacao
            Assert.IsNotEmpty(lista);

        }

        [Test]
        public void ListarFalta()
        {
            // ================ CENTARIO ===================== //
            ChamadaController pc = new ChamadaController();
            Aula aula = new Aula();
            aula.idAula = 1;
            Chamada cha = new Chamada();
            cha.idAula = aula;


            // ================ A��O ===================== //

            //chama metodod incluir
            List<Chamada> lista = pc.ListarFalta(cha);


            // ================ VALIDA��O ===================== //
            //verificacao
            Assert.IsNotEmpty(lista);
        }


    }
}