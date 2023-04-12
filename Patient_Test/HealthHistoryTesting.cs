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
	public class HealthHistoryTesting
	{
		private readonly IFixture _fixture;
		private readonly Mock<IHealthHistoryLogic> _mock;
		private readonly HealthHistoryController _controller;
        public HealthHistoryTesting()
		{
			_fixture = new Fixture();
			_mock = _fixture.Freeze<Mock<IHealthHistoryLogic>>();
			_controller = new HealthHistoryController(_mock.Object);
		}
		[Fact]
		public void GetById()
		{
			var history = _fixture.Create<IEnumerable<HealthHistory>>();
			var id = _fixture.Create<Guid>();
			_mock.Setup(x => x.GetHealthHistory(id)).Returns((IEnumerable<HealthHistory>)history);
			var res = _controller.Get(id);
			res.Should().NotBeNull();
			res.Should().BeAssignableTo<OkObjectResult>();
			res.As<OkObjectResult>().Value.Should().NotBeNull().And.BeOfType(history.GetType());
			_mock.Verify(x => x.GetHealthHistory(id), Times.AtLeastOnce());
		}
		[Fact]
		public void GetByIdExecption()
		{
            List<HealthHistory> history = null;
			var id = _fixture.Create<Guid>();
			_mock.Setup(x => x.GetHealthHistory(id)).Returns(history);
			var res = _controller.Get(id);
			res.Should().BeAssignableTo<BadRequestObjectResult>();
			_mock.Verify(x => x.GetHealthHistory(id), Times.AtLeastOnce());
        }
		[Fact]
		public void GetByIdCatch()
		{
			var history = _fixture.Create<IEnumerable<HealthHistory>>();
			var id = _fixture.Create<Guid>();
			_mock.Setup(x => x.GetHealthHistory(id)).Throws(new Exception("Something Went Wrong"));
			var res = _controller.Get(id);
			res.Should().NotBeNull();
            res.Should().BeAssignableTo<BadRequestObjectResult>();
            _mock.Verify(x => x.GetHealthHistory(id), Times.AtLeastOnce());


        }
		[Fact]
		public void Post()
		{
			var req = _fixture.Create<HealthHistory>();
			_mock.Setup(x => x.AddHealthHistory(req)).Returns(req);
			var res = _controller.Post(req);
			res.Should().NotBeNull();
			res.Should().BeAssignableTo<OkObjectResult>();
			_mock.Verify(x => x.AddHealthHistory(req), Times.AtLeastOnce());
		}
		[Fact]
		public void PostCatch()
		{
			HealthHistory histories = null;
			var req = _fixture.Create<HealthHistory>();
			_mock.Setup(x => x.AddHealthHistory(req)).Throws(new Exception("Something Went Wrong"));
			var res = _controller.Post(req);
			res.Should().NotBeNull();
			res.Should().BeAssignableTo<BadRequestObjectResult>();
			_mock.Verify(x => x.AddHealthHistory(req), Times.AtLeastOnce());


		}
		[Fact]
		public void PostExecption()
		{
			var req = _fixture.Create<HealthHistory>();
			_mock.Setup(x => x.AddHealthHistory(req));
			var res = _controller.Post(req);
			res.Should().NotBeNull();
			res.Should().BeAssignableTo<BadRequestObjectResult>();
			_mock.Verify(x=>x.AddHealthHistory(req),Times.AtLeastOnce());

        }
	}
}

