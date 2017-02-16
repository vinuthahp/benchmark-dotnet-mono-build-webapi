using System.Collections.Specialized;
using System.Net;
using System.Net.Http;
using System.Web;
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
		[Route("")]
		public IHttpActionResult List([FromUri] PersonQueryForm queryData)
		{
            if (queryData == null) queryData = new PersonQueryForm();
            return Ok(service.List(queryData));
		}

		[HttpGet]
		[Route("{id:int}")]
		public IHttpActionResult Read(int id)
		{
			var entity = service.Read(id);
			if (entity != null)
				return Ok(entity);
			else
				return NotFound();
		}

		[HttpPost]
		[Route("")]
		public IHttpActionResult Create([FromBody] PersonInputForm formData)
		{
			var validation = validator.Validate(formData);
			if (!validation.IsValid)
			{
				ModelState.Merge(validation);
				return BadRequest();
			}

			var entity = service.Create(formData);
			var resource = string.Format("people/{0}", entity.Id);
			return Created(resource, entity);
		}

		[HttpPut, HttpPatch]
		[Route("{id:int}")]
		public IHttpActionResult Update(int id, [FromBody] PersonInputForm formData)
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