using System;
using Xunit;
using AutoFixture;
using Moq;
using FluentAssertions;
using Audit_BusinessLogic;
using Audit_DataEntites;
using Audit_Models;
using Audit_Service;
using Microsoft.AspNetCore.Mvc;

namespace Audit_Test
{
	public class AuditMoqTest
	{
		private readonly IFixture _fixture;
		private readonly Mock<IAuditLogic> _mock;
		private readonly AuditController _controller;
		public AuditMoqTest()
		{
			_fixture = new Fixture();
			_mock = _fixture.Freeze<Mock<IAuditLogic>>();
			_controller = new AuditController(_mock.Object);
		}
		[Fact]
		public void Add()
		{
			var audit = _fixture.Create<Audit_Data>();
			_mock.Setup(x => x.Add(audit)).Returns(audit);

			var res = _controller.Post(audit);
			res.Should().NotBeNull();
			res.Should().BeAssignableTo<OkObjectResult>();
			_mock.Verify(x => x.Add(audit), Times.AtLeastOnce());
		}
		[Fact]
		public void AddCatch()
		{
			var audit = _fixture.Create<Audit_Data>();
			_mock.Setup(x => x.Add(audit)).Throws(new Exception("SOme thing went wrong"));
			var res = _controller.Post(audit);
			res.Should().BeAssignableTo<BadRequestObjectResult>();
			_mock.Verify(x => x.Add(audit), Times.AtLeastOnce());
		}
		
	}
}

