using FluentAssertions;
using GigHub.Controllers.Api;
using GigHub.Core;
using GigHub.Core.Models;
using GigHub.Core.Repositories;
using GigHub.Tests.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Web.Http.Results;

namespace GigHub.Tests.Controllers.Api
{
    /// <summary>
    /// Descripción resumida de GigsControllerTests
    /// </summary>
    [TestClass]
    public class GigsControllerTests
    {
        private GigsController _controller;
        private Mock<IGigRepository> _mockRepository;
        private string _userId;

        [TestInitialize]
        public void TestInitialize()
        {
            _mockRepository = new Mock<IGigRepository>();
            var mockUoW = new Mock<IUnitOfWork>();
            mockUoW.SetupGet(u => u.Gigs).Returns(_mockRepository.Object);

            _controller = new GigsController(mockUoW.Object);
            _userId = "1";
            _controller.MockCurrentUser(_userId, "user1@domain.com");           
        }
        /// <summary>
        ///Obtiene o establece el contexto de las pruebas que proporciona
        ///información y funcionalidad para la serie de pruebas actual.
        ///</summary>
        public TestContext TestContext { get; set; }

        #region Atributos de prueba adicionales
        //
        // Puede usar los siguientes atributos adicionales conforme escribe las pruebas:
        //
        // Use ClassInitialize para ejecutar el código antes de ejecutar la primera prueba en la clase
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup para ejecutar el código una vez ejecutadas todas las pruebas en una clase
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Usar TestInitialize para ejecutar el código antes de ejecutar cada prueba 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup para ejecutar el código una vez ejecutadas todas las pruebas
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void Cancel_NoGigWithGivenIdExists_ShouldReturnNotFund()
        {
            var result = _controller.Cancel(3);

            result.Should().BeOfType<NotFoundResult>();
        }

        [TestMethod]
        public void Cancel_GigIsCanceled_ShouldReturnNotFund()
        {
            var gig = new Gig();
            gig.Cancel();

            _mockRepository.Setup(r => r.GetGigWithAttendees(3)).Returns(gig);

            var result = _controller.Cancel(3);

            result.Should().BeOfType<NotFoundResult>();
        }

        [TestMethod]
        public void Cancel_UserCancelingAnotherUsersGig_ShouldReturnUnauthorized()
        {
            var gig = new Gig{ ArtistId = _userId + "-"};

            _mockRepository.Setup(r => r.GetGigWithAttendees(3)).Returns(gig);

            var result = _controller.Cancel(3);

            result.Should().BeOfType<UnauthorizedResult>();
        }

        [TestMethod]
        public void Cancel_ValidRequest_ShouldReturnOK()
        {
            var gig = new Gig { ArtistId = _userId };

            _mockRepository.Setup(r => r.GetGigWithAttendees(3)).Returns(gig);

            var result = _controller.Cancel(3);

            result.Should().BeOfType<OkResult>();
        }
    }
}
