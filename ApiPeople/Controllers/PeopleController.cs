﻿using System.Collections.Generic;
using System.Net;
using System.Web.Http;
using ApiPeople.Domain.Person;

namespace ApiPeople.Controllers
{
	[RoutePrefix("people")]
	public class PersonController : ApiController
	{
		private readonly IPersonService service;
		private readonly IPersonValidatorForCreate validator;

		public PersonController(
			IPersonService service,
			IPersonValidatorForCreate validator)
		{
			this.service = service;
			this.validator = validator;
		}

		[HttpGet]
		public IHttpActionResult List(IDictionary<string, object> queryData)
		{
			return Ok(service.List(queryData));
		}

		[HttpGet]
		[Route("{id}")]
		public IHttpActionResult Read(int id)
		{
			var entity = service.Read(id);
			if (entity != null)
				return Ok(entity);
			else
				return NotFound();
		}

		[HttpPost]
		public IHttpActionResult Create(IDictionary<string, object> formData)
		{
			var validation = validator.Validate(formData);
			if (!validation.IsValid)
			{
				ModelState.Merge(validation);
				return BadRequest();
			}

			var entity = service.Create(formData);
			return this.CreatedAtRoute(
				"{id}",
				new { @id = entity.Id },
				entity);
		}

		[HttpPut, HttpPatch]
		[Route("{id:int}")]
		public IHttpActionResult Update(int id, IDictionary<string, object> formData)
		{
			if (!service.Update(id, formData))
				return NotFound();

			return StatusCode(HttpStatusCode.Accepted);
		}

		[HttpDelete]
		[Route("{id:int}")]
		public IHttpActionResult Delete(int id)
		{
			if (!service.Delete(id))
				return NotFound();

			return StatusCode(HttpStatusCode.Accepted);
		}
	}
}