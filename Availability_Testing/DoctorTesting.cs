using AutoFixture;
using Moq;
using Services.Controllers;
using BusinessLogic;
using FluentAssertions;
using Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Availability_Testing
{
    public class DoctorTesting
    {
        private readonly IFixture fixture;
        private readonly Mock<IDoctorLogic> mockLogic;
        private readonly DoctorController controller;

        public DoctorTesting()
        {
            fixture = new Fixture();
            mockLogic = fixture.Freeze<Mock<IDoctorLogic>>();
            controller = new DoctorController(mockLogic.Object);
        }
        [Fact]
        public void GetAllDoctors_AvailabilityService_OkResponse()
        {
            //Arrange
            var doc = fixture.Create<List<Doctor>>();
            mockLogic.Setup(x => x.GetAllDoctors()).Returns(doc);

            //Act
            var result = controller.GetAllDoctors();

            //Assert
            result.Should().NotBeNull();
            result.Should().BeAssignableTo<OkObjectResult>();
            result.As<OkObjectResult>().Value
                .Should().NotBeNull()
                .And.BeOfType(doc.GetType());
            mockLogic.Verify(x => x.GetAllDoctors(), Times.AtLeastOnce());
        }
        [Fact]
        public void GetAllDoctors_AvailabilityService_BadRequest()            
        {
            //Arrange
            var doc = fixture.Create<List<Doctor>>();
            mockLogic.Setup(x => x.GetAllDoctors()).Throws(new Exception("Something wrong with the request"));

            //Act
            var result = controller.GetAllDoctors();

            //Assert
            result.Should().BeAssignableTo<BadRequestObjectResult>();
            mockLogic.Verify(x => x.GetAllDoctors(), Times.AtLeastOnce());

        }
        [Fact]
        public void GetDoctorByEmail_AvailabilityService_OkResponse()
        {
            //Arrange
            var doc = fixture.Create<Doctor>();
            var email = fixture.Create<string>();
            mockLogic.Setup(x => x.GetDoctorByEmail(email)).Returns(doc);

            //Act
            var result = controller.GetDoctorsByEmail(email);

            //Assert
            result.Should().NotBeNull();
            result.Should().BeAssignableTo<OkObjectResult>();
            result.As<OkObjectResult>().Value
                .Should().NotBeNull()
                .And.BeOfType(doc.GetType());
            mockLogic.Verify(x => x.GetDoctorByEmail(email), Times.AtLeastOnce());
        }
        [Fact]
        public void GetDoctorByEmail_AvailabilityService_BadRequest()
        {
            //Arrange
            var email = fixture.Create<string>();
            mockLogic.Setup(x => x.GetDoctorByEmail(email)).Throws(new Exception("Something wrong with the request"));

            //Act
            var result = controller.GetDoctorsByEmail(email);

            //Assert
            result.Should().NotBeNull();
            result.Should().BeAssignableTo<BadRequestObjectResult>();
            mockLogic.Verify(x => x.GetDoctorByEmail(email), Times.AtLeastOnce());

        }
        [Fact]
        public void GetDoctorByDepartment_AvailabilityService_OkResponse()
        {
            //Arrange
            var doc = fixture.Create<List<Doctor>>();
            var dept = fixture.Create<string>();
            mockLogic.Setup(x => x.GetDoctorByDepartment(dept)).Returns(doc);
            
            //Act
            var result = controller.GetDoctorByDepartment(dept);

            //Assert
            result.Should().NotBeNull();
            result.Should().BeAssignableTo<OkObjectResult>();
            result.As<OkObjectResult>().Value
                .Should().NotBeNull()
                .And.BeOfType(doc.GetType());
            mockLogic.Verify(x => x.GetDoctorByDepartment(dept), Times.AtLeastOnce());
        }
        [Fact]
        public void GetDoctorByDepartment_AvailabilityService_BadRequest()
        {
            //Arrange
            var dept = fixture.Create<string>();
            mockLogic.Setup(x => x.GetDoctorByDepartment(dept)).Throws(new Exception("Something wrong with the request"));

            //Act
            var result = controller.GetDoctorByDepartment(dept);

            //Assert
            result.Should().NotBeNull();
            result.Should().BeAssignableTo<BadRequestObjectResult>();
            mockLogic.Verify(x => x.GetDoctorByDepartment(dept), Times.AtLeastOnce());

        }
        [Fact]
        public void GetDoctorsByAvailability_AvailabilityService_OkResponse()
        {
            //Arrange
            //List<Doctor> doc = null;
            var doc = fixture.Create<List<Doctor>>();
            var day = fixture.Create<string>();
            mockLogic.Setup(x => x.GetAllDoctorsByAvailability(day)).Returns(doc);

            //Act
            var result = controller.GetDoctorsByAvailability(day);

            //Assert
            result.Should().NotBeNull();
            result.Should().BeAssignableTo<OkObjectResult>();
            result.As<OkObjectResult>().Value
                .Should().NotBeNull()
                .And.BeOfType(doc.GetType());
            mockLogic.Verify(x => x.GetAllDoctorsByAvailability(day), Times.AtLeastOnce());
        }
        [Fact]
        public void GetDoctorsByAvailability_AvailabilityService_BadRequest()
        {
            //Arrange
            var day = fixture.Create<string>();
            mockLogic.Setup(x => x.GetAllDoctorsByAvailability(day)).Throws(new Exception("Something wrong with the request"));

            //Act
            var result = controller.GetDoctorsByAvailability(day);

            //Assert
            result.Should().NotBeNull();
            result.Should().BeAssignableTo<BadRequestObjectResult>();
            mockLogic.Verify(x => x.GetAllDoctorsByAvailability(day), Times.AtLeastOnce());

        }
        [Fact]
        public void AddDoctor_AvailabilityService_OkRequest()
        {
            //Arrange
            var request = fixture.Create<Doctor>();
            mockLogic.Setup(x => x.AddDoctor(request)).Returns(request);

            //Act
            var result = controller.AddDoctor(request);

            //Assert
            result.Should().NotBeNull();
            result.Should().BeAssignableTo<OkObjectResult>();
            mockLogic.Verify(x => x.AddDoctor(request), Times.AtLeastOnce());
        }
        [Fact]
        public void AddDoctor_AvailabilityService_BadRequest()
        {
            //Arrange
            var request = fixture.Create<Doctor>();
            mockLogic.Setup(x => x.AddDoctor(request)).Throws(new Exception("Something wrong with the request"));

            //Act
            var result = controller.AddDoctor(request);

            //Assert
            result.Should().NotBeNull();
            result.Should().BeAssignableTo<BadRequestObjectResult>();
            mockLogic.Verify(x => x.AddDoctor(request), Times.AtLeastOnce());
        }

    }
}
