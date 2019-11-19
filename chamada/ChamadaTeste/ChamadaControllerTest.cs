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
        public void ListarPresença()
        {
            // ================ CENTARIO ===================== //
            ChamadaController pc = new ChamadaController();


            // ================ AÇÃO ===================== //

            //chama metodod incluir
            List<Chamada> lista = pc.ListarPresenca(new Chamada());


            // ================ VALIDAÇÃO ===================== //
            //verificacao
            Assert.IsNotEmpty(lista);
            
        }

        [Test]
        public void ListarFalta()
        {
            // ================ CENTARIO ===================== //
            ChamadaController pc = new ChamadaController();


            // ================ AÇÃO ===================== //

            //chama metodod incluir
            List<Chamada> lista = pc.ListarFalta(new Chamada());


            // ================ VALIDAÇÃO ===================== //
            //verificacao
            Assert.IsNotEmpty(lista);

        }

       
    }
}