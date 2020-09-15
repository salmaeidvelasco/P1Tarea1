using System;
using System.Net;
using System.Web.Http;
using System.Web.Http.Results;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PracticaP1.Controllers;
using PracticaP1.Models;

namespace UnitTestTarea1
{
    [TestClass]
    public class UnitTest1
    {
        //Get
        [TestMethod]
        public void TestMethodGet()
        {
            //Arrange
            EidsController controller = new EidsController();


            //Act
            var listaEid = controller.GetEids();

            //Assert
            Assert.IsNotNull(listaEid);
        }

        //Post
        [TestMethod]
        public void TestMethodPost()
        {
            //Arrange
            EidsController controller = new EidsController();
            Eid esperado = new Eid()
            {
                eidID = 1,
                Friendofeid = "Monica",
                Place = CategoryType.Cine,
                Email = "monicavg@hotmail.com",
                Birthday = DateTime.Today

            };


            //Act
            IHttpActionResult actionResult = controller.PostEid(esperado);
            var resultadoCreado = actionResult as CreatedAtRouteNegotiatedContentResult<Eid>;

            //Assert
            Assert.IsNotNull(resultadoCreado);
            Assert.AreEqual("DefaultApi", resultadoCreado.RouteName);
            Assert.AreEqual(esperado.Friendofeid, resultadoCreado.Content.Friendofeid);
        }


        //Delete
        [TestMethod]
        public void TestMethodDelete()
        {
            //Arrange
            EidsController controller = new EidsController();
            Eid esperado = new Eid()
            {
                eidID = 1,
                Friendofeid = "Monica",
                Place = CategoryType.Cine,
                Email = "monicavg@hotmail.com",
                Birthday = DateTime.Today

            };


            //Act
            var ListaSalma = controller.PostEid(esperado);
            var resultadoEliminado = controller.DeleteEid(esperado.eidID);

            //Assert
            Assert.IsInstanceOfType(resultadoEliminado,typeof(OkNegotiatedContentResult<Eid>));
           
        }


        //Put
        [TestMethod]
        public void TestMethodPut()
        {
            //Arrange
            EidsController controlador = new EidsController();
            Eid prueba = new Eid()
            {
               eidID = 1,
                Friendofeid = "Monica",
                Place = CategoryType.Cine,
                Email = "monicavg@hotmail.com",
                Birthday = DateTime.Today
            };
            //Act
            var ListaEid = controlador.PostEid(prueba);
            prueba.Friendofeid = "Marcela";
            var resultadoCreado = controlador.PutEid(prueba.eidID, prueba) as StatusCodeResult;

            //Assert
            Assert.IsNotNull(resultadoCreado);
            Assert.AreEqual(HttpStatusCode.NoContent, resultadoCreado.StatusCode);
            Assert.IsInstanceOfType(resultadoCreado, typeof(StatusCodeResult));
        }


    }
}
