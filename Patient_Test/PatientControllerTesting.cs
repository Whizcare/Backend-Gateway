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
    public class PatientConstollerTesting
    {
        private readonly IFixture _fixture;
        private readonly Mock<IPatientLogic> _patientLogic;
        private readonly PatientController _controller;

        public PatientConstollerTesting()
        {
            _fixture = new Fixture();
            _patientLogic = _fixture.Freeze<Mock<IPatientLogic>>();
            _controller = new PatientController(_patientLogic.Object);

        }

        [Fact]
        public void GetAll()
        {
            var Patients = _fixture.Create<IEnumerable<Patient>>();
            _patientLogic.Setup(x => x.GetPatients()).Returns(Patients);

            var res = _controller.Get();

            res.Should().NotBeNull();
            res.Should().BeAssignableTo<OkObjectResult>();
            res.As<OkObjectResult>().Value.Should().NotBeNull().And.BeOfType(Patients.GetType());
            _patientLogic.Verify(x => x.GetPatients(), Times.AtLeastOnce());

        }
        [Fact]
        public void GetAllExecption()
        {

            List<Patient> Patients = null;
            _patientLogic.Setup(x => x.GetPatients()).Returns(Patients);

            var res = _controller.Get();

            res.Should().BeAssignableTo<BadRequestResult>();

            _patientLogic.Verify(x => x.GetPatients(), Times.AtLeastOnce());

        }
        [Fact]
        public void GetAllCatch()
        {
            var patient = _fixture.Create<Patient>();
            _patientLogic.Setup(x => x.GetPatients()).Throws(new Exception("Something Went Wrong"));
            var res = _controller.Get();
            res.Should().BeAssignableTo<BadRequestObjectResult>();
            _patientLogic.Verify(x => x.GetPatients(), Times.AtLeastOnce());
        }

        [Fact]
        public void GetById()
        {
            var Pateints = _fixture.Create<Patient>();
            var id = _fixture.Create<Guid>();
            _patientLogic.Setup(x => x.GetPatientById(id)).Returns(Pateints);
            var res = _controller.Get(id);
            res.Should().NotBeNull();
            res.Should().BeAssignableTo<OkObjectResult>();
            res.As<OkObjectResult>().Value.Should().NotBeNull().And.BeOfType(Pateints.GetType());
            _patientLogic.Verify(x => x.GetPatientById(id), Times.AtLeastOnce());
        }
        [Fact]
        public void GetByIdExecption()
        {
            Patient Patients = null;
            var id = _fixture.Create<Guid>();
            _patientLogic.Setup(x => x.GetPatientById(id)).Returns(Patients);
            var res = _controller.Get(id);
            res.Should().BeAssignableTo<BadRequestResult>();
            _patientLogic.Verify(x => x.GetPatientById(id), Times.AtLeastOnce());
        }
        [Fact]
        public void GetByIdCatch()
        {
            var patient = _fixture.Create<Patient>();
            var id = _fixture.Create<Guid>();
            _patientLogic.Setup(x => x.GetPatientById(id)).Throws(new Exception("Something Went wrong"));
            var res = _controller.Get(id);
            res.Should().BeAssignableTo<BadRequestObjectResult>();
            _patientLogic.Verify(x => x.GetPatientById(id), Times.AtLeastOnce());
        }

        [Fact]
        public void Post()
        {
            var req = _fixture.Create<Patient>();

            _patientLogic.Setup(x => x.AddPatient(req)).Returns(req);

            var result = _controller.RegisterPat(req);
            result.Should().NotBeNull();
            result.Should().BeAssignableTo<OkObjectResult>();
            _patientLogic.Verify(x => x.AddPatient(req), Times.AtLeastOnce());

        }
        [Fact]
        public void PostExecption()
        {
            var req = _fixture.Create<Patient>();

            _patientLogic.Setup(x => x.AddPatient(req)).Throws(new Exception("Something Went Wrong"));

            var result = _controller.RegisterPat(req);
            result.Should().NotBeNull();
            result.Should().BeAssignableTo<BadRequestObjectResult>();
            _patientLogic.Verify(x => x.AddPatient(req), Times.AtLeastOnce());

        }
        [Fact]
        public void PostCatch()
        {
            Patient Patients = null;
            var req = _fixture.Create<Patient>();
            _patientLogic.Setup(x => x.AddPatient(req)).Returns(Patients);
            var res = _controller.RegisterPat(req);
            res.Should().BeAssignableTo<BadRequestObjectResult>();
            _patientLogic.Verify(x => x.AddPatient(req), Times.AtLeastOnce());

        }
        [Fact]
        public void Put()
        {
            var patient = _fixture.Create<Patient>();
            var email = _fixture.Create<string>();
            _patientLogic.Setup(x => x.UpdatePatient(email, patient)).Returns(patient);
            var res = _controller.Update(email, patient);
            res.Should().NotBeNull();
            res.Should().BeAssignableTo<OkObjectResult>();
            res.As<OkObjectResult>().Value.Should().NotBeNull().And.BeOfType(patient.GetType());
            _patientLogic.Verify(x => x.UpdatePatient(email, patient), Times.AtLeastOnce());
        }
        [Fact]
        public void PutExecption()
        {
            var patient = _fixture.Create<Patient>();
            var email = _fixture.Create<string>();
            _patientLogic.Setup(x => x.UpdatePatient(email, patient)).Throws(new Exception("Something went wrong"));
            var res = _controller.Update(email, patient);
            res.Should().BeAssignableTo<BadRequestObjectResult>();
            _patientLogic.Verify(x => x.UpdatePatient(email, patient), Times.AtLeastOnce());
        }
       
     
        [Fact]
        public void Delete()
        {
            var patient = _fixture.Create<Patient>();
            var email = _fixture.Create<string>();
            _patientLogic.Setup(x => x.DeletePatient(email)).Returns(patient);
            var res = _controller.Delete(email);
            res.Should().NotBeNull();
            res.Should().BeAssignableTo<OkObjectResult>();
            res.As<OkObjectResult>().Value.Should().NotBeNull().And.BeOfType(patient.GetType());
            _patientLogic.Verify(x => x.DeletePatient(email), Times.AtLeastOnce());
        }
        [Fact]
        public void DeleteExecption()
        {
            var patient = _fixture.Create<Patient>();
            var email = _fixture.Create<string>();
            _patientLogic.Setup(x => x.DeletePatient(email)).Throws(new Exception("Something went Worng"));
            var res = _controller.Delete(email);
            res.Should().BeAssignableTo<BadRequestObjectResult>();
            _patientLogic.Verify(x => x.DeletePatient(email), Times.AtLeastOnce());
        }
        [Fact]
        public void DeleteCatch()
        {
            Patient Patients = null;
            var email = _fixture.Create<string>();
            _patientLogic.Setup(x => x.DeletePatient(email)).Returns(Patients);
            var res = _controller.Delete(email);
            res.Should().BeAssignableTo<BadRequestObjectResult>();
            _patientLogic.Verify(x => x.DeletePatient(email), Times.AtLeastOnce());
        }
        [Fact]
        public void GetByEmail()
        {
            var patient = _fixture.Create<Patient>();
            var email = _fixture.Create<String>();
            _patientLogic.Setup(x => x.GetPatientByEmail(email)).Returns(patient);
            var res = _controller.getpatientsbyemail(email);
            res.Should().NotBeNull();
            res.Should().BeAssignableTo<OkObjectResult>();
            res.As<OkObjectResult>().Value.Should().NotBeNull().And.BeOfType(patient.GetType());
            _patientLogic.Verify(x => x.GetPatientByEmail(email), Times.AtLeastOnce());
        }
        [Fact]
        public void GetByEmailExecption()
        {
            var patient = _fixture.Create<Patient>();
            var email = _fixture.Create<string>();
            _patientLogic.Setup(x => x.GetPatientByEmail(email)).Throws(new Exception("Something went Worng"));
            var res = _controller.getpatientsbyemail(email);
            res.Should().BeAssignableTo<BadRequestObjectResult>();
            _patientLogic.Verify(x => x.GetPatientByEmail(email), Times.AtLeastOnce());
        }
        [Fact]
        public void GetByEmailNull()
        {
            Patient Patients = null;
            var email = _fixture.Create<string>();
            _patientLogic.Setup(x => x.GetPatientByEmail(email)).Returns(Patients);
            var res = _controller.getpatientsbyemail(email);
            res.Should().BeAssignableTo<BadRequestResult>();
            _patientLogic.Verify(x => x.GetPatientByEmail(email), Times.AtLeastOnce());
        }
        [Fact]
        public void Login()
        {
            var patient = _fixture.Create<Patient>();
            var email = _fixture.Create<string>();
            var password = _fixture.Create<string>();
            _patientLogic.Setup(x => x.LoginPatient(email, password)).Returns(patient);
            var res = _controller.SignInPatient(email, password);
            res.Should().NotBeNull();
            res.Should().BeAssignableTo<OkObjectResult>();
            res.As<OkObjectResult>().Value.Should().NotBeNull().And.BeOfType(patient.GetType());
            _patientLogic.Verify(x => x.LoginPatient(email, password), Times.AtLeastOnce());
        }
        [Fact]
        public void LoginExecption()
        {
            var patient = _fixture.Create<Patient>();
            var email = _fixture.Create<string>();
            var password = _fixture.Create<string>();
            _patientLogic.Setup(x => x.LoginPatient(email, password)).Throws(new Exception("Something went wrong"));
            var res = _controller.SignInPatient(email, password);
            res.Should().BeAssignableTo<BadRequestObjectResult>();
            _patientLogic.Verify(x => x.LoginPatient(email, password), Times.AtLeastOnce());
        }
        [Fact]
        public void LoginCatch()
        {
            Patient patient = null;
            var email = _fixture.Create<string>();
            var password = _fixture.Create<string>();
            _patientLogic.Setup(x => x.LoginPatient(email, password)).Returns(patient);
            var res = _controller.SignInPatient(email, password);
            res.Should().BeAssignableTo<BadRequestObjectResult>();
            _patientLogic.Verify(x => x.LoginPatient(email, password), Times.AtLeastOnce());



           
        }
    }
}
