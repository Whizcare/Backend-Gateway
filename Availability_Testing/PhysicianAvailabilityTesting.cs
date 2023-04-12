using AutoFixture;
using Moq;
using Services.Controllers;
using BusinessLogic;
using FluentAssertions;
using Models;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace Availability_Testing
{
    public class PhysicianAvailabilityTesting
    {
        private readonly IFixture fixture;
        private readonly Mock<IPhysicianAvailabilityStatus> mockLogic;
        private readonly PhysicianAvailabilityStatusController controller;

        public PhysicianAvailabilityTesting()
        {
            fixture = new Fixture();
            mockLogic = fixture.Freeze<Mock<IPhysicianAvailabilityStatus>>();
            controller = new PhysicianAvailabilityStatusController(mockLogic.Object);
        }
        [Fact]
        public void GetAvailability_AvailabilityService_OkResponse()
        {
            //Arrange
            var availabilityMock = fixture.Create<PhysicianAvailabilityStatus>();
            var id = fixture.Create<Guid>();
            mockLogic.Setup(x => x.GetAvailabilityStatus(id)).Returns(availabilityMock);

            //Act
            var result = controller.GetAvailability(id);

            //Assert
            result.Should().NotBeNull();
            result.Should().BeAssignableTo<OkObjectResult>();
            result.As<OkObjectResult>().Value
                .Should().NotBeNull()
                .And.BeOfType(availabilityMock.GetType());
            mockLogic.Verify(x => x.GetAvailabilityStatus(id), Times.AtLeastOnce());
        }
        [Fact]
        public void GetAvailability_AvailabilityService_BadRequest()
        {
            //Arrange
            var id = fixture.Create<Guid>();
            mockLogic.Setup(x => x.GetAvailabilityStatus(id)).Throws(new Exception("Something wrong with the request"));

            //Act
            var result = controller.GetAvailability(id);

            //Assert
            result.Should().NotBeNull();
            result.Should().BeAssignableTo<BadRequestObjectResult>();
            mockLogic.Verify(x => x.GetAvailabilityStatus(id), Times.AtLeastOnce());

        }
        [Fact]
        public void AddAvailability_AvailabilityService_OkRequest()
        {
            //Arrange
            var request = fixture.Create<PhysicianAvailabilityStatus>();
            mockLogic.Setup(x => x.AddAvailability(request)).Returns(request);

            //Act
            var result = controller.AddAvailability(request);

            //Assert
            result.Should().NotBeNull();
            result.Should().BeAssignableTo<OkObjectResult>();
            mockLogic.Verify(x => x.AddAvailability(request), Times.AtLeastOnce());
        }
        [Fact]
        public void AddAvailability_AvailabilityService_BadRequest()
        {
            //Arrange
            var request = fixture.Create<PhysicianAvailabilityStatus>();
            mockLogic.Setup(x => x.AddAvailability(request)).Throws(new Exception("Something wrong with the request"));

            //Act
            var result = controller.AddAvailability(request);

            //Assert
            result.Should().NotBeNull();
            result.Should().BeAssignableTo<BadRequestObjectResult>();
            mockLogic.Verify(x => x.AddAvailability(request), Times.AtLeastOnce());
        }
        [Fact]
        public void UpdateAvailability_AvailabilityService_OkResponse()
        {
            //Arrange
            var response = fixture.Create<PhysicianAvailabilityStatus>();
            mockLogic.Setup(x => x.UpdateAvailability(response)).Returns(response);

            //Act
            var result = controller.UpdateAvailability(response);

            //Assert
            result.Should().NotBeNull();
            result.Should().BeAssignableTo<OkObjectResult>();
            result.As<OkObjectResult>().Value
                .Should().NotBeNull()
                .And.BeOfType(response.GetType());
            mockLogic.Verify(x => x.UpdateAvailability(response), Times.AtLeastOnce());
        }
        [Fact]
        public void UpdateAvailability_AvailabilityService_BadRequest()
        {
            //Arrange
            var response = fixture.Create<PhysicianAvailabilityStatus>();
            mockLogic.Setup(x => x.UpdateAvailability(response)).Throws(new Exception("Something wrong with the request"));

            //Act
            var result = controller.UpdateAvailability(response);

            //Assert
            result.Should().NotBeNull();
            result.Should().BeAssignableTo<BadRequestObjectResult>();
            mockLogic.Verify(x => x.UpdateAvailability(response), Times.AtLeastOnce());
        }
    }
}

