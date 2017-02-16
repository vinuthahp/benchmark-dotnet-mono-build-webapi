using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Http.ModelBinding;
using System.Web.Http.Results;
using ApiPeople.Controllers;
using ApiPeople.Domain.Person;
using ApiPeople.Utils;
using Moq;
using NUnit.Framework;
using System.Collections.Specialized;

namespace ApiPeople.Tests.Controllers
{
	public class PeopleControllerTest
	{
		private PersonController controller;
		private Mock<IPersonService> service;
		private Mock<IPersonValidatorForCreate> validator;

		[SetUp]
		public void Setup()
		{
			service = new Mock<IPersonService>();
			validator = new Mock<IPersonValidatorForCreate>();
			controller = new PersonController(service.Object, validator.Object);
		}

		[TearDown]
		public void TearDown()
		{
		}

		[Test]
		public void Read_NotFound()
		{
			service.Setup(x => x.Read(It.IsAny<int>())).Returns<PersonEntity>(null);

			var response = controller.Read(-1);

			Assert.IsInstanceOf(typeof(NotFoundResult), response);
		}

		[Test]
		public void Read_Ok()
		{
			var fixture = PersonFixtures.Entity();
			service.Setup(x => x.Read(fixture.Id)).Returns(fixture);

			var response = controller.Read(fixture.Id);

			var responseResult = (OkNegotiatedContentResult<PersonEntity>)response;
			Assert.AreEqual(fixture.Id, responseResult.Content.Id);
			Assert.AreEqual(fixture.Name, responseResult.Content.Name);
			Assert.AreEqual(fixture.DOB, responseResult.Content.DOB);
		}

		[Test]
		public void List_Ok()
		{
			var fixture = PersonFixtures.Wrapper();
			service.Setup(x => x.List(It.IsAny<PersonQueryForm>())).Returns(fixture);

            var queryData = new PersonQueryForm();
            var response = controller.List(queryData);

			var responseResult = (OkNegotiatedContentResult<WrapperDTO<PersonEntity>>)response;
			Assert.AreEqual(fixture.TotalCount, responseResult.Content.TotalCount); 
			Assert.AreEqual(fixture.Limit, responseResult.Content.Limit);
			Assert.AreEqual(fixture.Entries, responseResult.Content.Entries);
		}

		[Test]
		public void Create_BadRequest()
		{
			var input = PersonFixtures.Input();
			var failedState = new ModelStateDictionary();
			failedState.AddModelError("name", "invalid");
			validator.Setup(x => x.Validate(input)).Returns(failedState);

			var response = controller.Create(input);

			Assert.IsInstanceOf(typeof(BadRequestResult), response);
		}

		[Test]
		public void Create_Created()
		{
			var input = PersonFixtures.Input();
			var fixture = PersonFixtures.Entity(input);
			service.Setup(x => x.Create(input)).Returns(fixture);
			validator.Setup(x => x.Validate(input)).Returns(new ModelStateDictionary());

			var response = controller.Create(input);

			var responseResult = (CreatedNegotiatedContentResult<PersonEntity>)response;
			Assert.AreEqual(new Uri(string.Format("people/{0}", fixture.Id), UriKind.Relative), responseResult.Location);
			Assert.AreEqual(fixture.Id, responseResult.Content.Id);
			Assert.AreEqual(fixture.Name, responseResult.Content.Name);
			Assert.AreEqual(fixture.DOB, responseResult.Content.DOB);
		}

		[Test]
		public void Update_NotFound()
		{
			var input = PersonFixtures.Input();
			service
				.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<PersonInputForm>()))
				.Returns(false);

			var response = controller.Update(1, input);

			Assert.IsInstanceOf(typeof(NotFoundResult), response);
		}

		[Test]
		public void Update_Created()
		{
			var input = PersonFixtures.Input();
			var fixture = PersonFixtures.Entity(input);
			service.Setup(x => x.Update(fixture.Id, input)).Returns(true);

			var response = controller.Update(fixture.Id, input);

			var responseResult = (StatusCodeResult)response;
			Assert.AreEqual(HttpStatusCode.Accepted, responseResult.StatusCode);
		}

		[Test]
		public void Delete_NotFound()
		{
			service.Setup(x => x.Delete(It.IsAny<int>())).Returns(false);

			var response = controller.Delete(1);

			Assert.IsInstanceOf(typeof(NotFoundResult), response);
		}

		[Test]
		public void Delete_Created()
		{
			var fixture = PersonFixtures.Entity();
			service.Setup(x => x.Delete(fixture.Id)).Returns(true);

			var response = controller.Delete(fixture.Id);

			var responseResult = (StatusCodeResult)response;
			Assert.AreEqual(HttpStatusCode.Accepted, responseResult.StatusCode);
		}
	}
}
