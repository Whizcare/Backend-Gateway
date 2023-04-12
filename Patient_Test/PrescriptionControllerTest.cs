using System;
using Xunit;
using AutoFixture;
using Moq;
using FluentAssertions;
using Patient_Logic;
using Services.Controllers;
using Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http.HttpResults;
namespace Patient_Test
{
	public class PrescriptionControllerTest
	{
		private readonly IFixture _fixture;
		private readonly Mock<IPresciptionLogic> _mock;
		private readonly PrescriptionsController _contoller;
		public PrescriptionControllerTest()
		{
			_fixture = new Fixture();
			_mock = _fixture.Freeze<Mock<IPresciptionLogic>>();
			_contoller = new PrescriptionsController(_mock.Object);
		}
		[Fact]
		public void GetById()
		{

			var prescription = _fixture.Create<IEnumerable<Prescriptions>>();
			var id = _fixture.Create<Guid>();
			_mock.Setup(x => x.GetPrescriptions(id)).Returns((IEnumerable<Prescriptions>)prescription);
			var res = _contoller.Get(id);
			res.Should().NotBeNull();
			res.Should().BeAssignableTo<OkObjectResult>();
			res.As<OkObjectResult>().Value.Should().NotBeNull().And.BeOfType(prescription.GetType());
			_mock.Verify(x => x.GetPrescriptions(id), Times.AtLeastOnce());
		}
		[Fact]
		public void GetByIdExecption()
		{
			List<Prescriptions> prescriptions = null;
			var id = _fixture.Create<Guid>();
			_mock.Setup(x => x.GetPrescriptions(id)).Throws(new Exception("Something went wrong"));
			var res = _contoller.Get(id);
			res.Should().BeAssignableTo<BadRequestObjectResult>();
			_mock.Verify(x => x.GetPrescriptions(id), Times.AtLeastOnce());
		}
		[Fact]
		public void GetByIdCatch()
		{
			var prescriptions = _fixture.Create<IEnumerable<Prescriptions>>();
			var id = _fixture.Create<Guid>();
			_mock.Setup(x => x.GetPrescriptions(id));
			var res = _contoller.Get(id);
			res.Should().NotBeNull();
			res.Should().BeAssignableTo<OkObjectResult>();
			_mock.Verify(x => x.GetPrescriptions(id), Times.AtLeastOnce());

		}
		[Fact]
		public void Post()
		{
			var req = _fixture.Create<Prescriptions>();
			_mock.Setup(x => x.AddPrescriptions(req)).Returns(req);
			var res = _contoller.Post(req);
			res.Should().NotBeNull();
			res.Should().BeAssignableTo<OkObjectResult>();
			_mock.Verify(x => x.AddPrescriptions(req), Times.AtLeastOnce());
		}
		[Fact]
		public void PostExecption()
		{
			var req = _fixture.Create<Prescriptions>();
			_mock.Setup(x => x.AddPrescriptions(req));
			var res = _contoller.Post(req);
			res.Should().NotBeNull();
			res.Should().BeAssignableTo<BadRequestObjectResult>();
			_mock.Verify(x => x.AddPrescriptions(req), Times.AtLeastOnce());
		}
		[Fact]
		public void PostCathc()
		{
			Prescriptions prescriptions = null;
			var req = _fixture.Create<Prescriptions>();
			_mock.Setup(x => x.AddPrescriptions(req)).Throws(new Exception("Something went wrong"));
			var res = _contoller.Post(req);
			res.Should().NotBeNull();
			res.Should().BeAssignableTo<BadRequestObjectResult>();
			_mock.Verify(x => x.AddPrescriptions(req), Times.AtLeastOnce());
		}
}
}
