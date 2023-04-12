using System;
using Xunit;
using AutoFixture;
using Moq;
using FluentAssertions;
using BusinessLogic;
using df=DataEntities.Entities;
using DataEntities;
using Models;
using Services.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace Allergy_Testing
{
	public class AllergyMoq
	{
		private readonly IFixture _fixture;
		private readonly Mock<Ilogic> _mock;
		private readonly AllergyController _contoller;
        public AllergyMoq()
		{
			_fixture = new Fixture();
			_mock = _fixture.Freeze<Mock<Ilogic>>();
			_contoller = new AllergyController(_mock.Object);
		}
		[Fact]
		public void GetAll()
		{
			var id = _fixture.Create<Guid>();
			var allergy = _fixture.Create<List<Allergy>>();
			_mock.Setup(x => x.GetAllAllergies(id)).Returns(allergy);
			var res = _contoller.GetAllAllergy(id);
			res.Should().NotBeNull();
			res.Should().BeAssignableTo<OkObjectResult>();
			_mock.Verify(x => x.GetAllAllergies(id), Times.AtLeastOnce());		
		}
		[Fact]
		public void GetAllCathc()
		{
			var id = _fixture.Create<Guid>();
			var allergy = _fixture.Create<List<Allergy>>();
			_mock.Setup(x => x.GetAllAllergies(id)).Throws(new Exception("Something went wrong"));
			var res = _contoller.GetAllAllergy(id);
			res.Should().NotBeNull();
			res.Should().BeAssignableTo<BadRequestObjectResult>();
			_mock.Verify(x => x.GetAllAllergies(id), Times.AtLeastOnce());
		}
		[Fact]
		public void Post()
		{
			var req = _fixture.Create<Allergy>();
			_mock.Setup(x => x.addPatientAllergy(req));
			var res = _contoller.PostAllergy(req);
			res.Should().NotBeNull();
			res.Should().BeAssignableTo<OkObjectResult>();
			_mock.Verify(x => x.addPatientAllergy(req), Times.AtLeastOnce());
				
		}
		[Fact]
		public void PostCatch()
		{
			var req = _fixture.Create<Allergy>();
			_mock.Setup(x => x.addPatientAllergy(req)).Throws(new Exception("Something "));
			var res = _contoller.PostAllergy(req);
			res.Should().NotBeNull();
			res.Should().BeAssignableTo<BadRequestObjectResult>();
			_mock.Verify(x => x.addPatientAllergy(req), Times.AtLeastOnce());
		}
	}
}

