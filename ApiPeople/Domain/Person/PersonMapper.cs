using System;
using System.Collections.Generic;
using ApiPeople.Domain.Person;

namespace ApiPeople
{
	public class PersonMapper
	{
		public readonly PersonEntity entity;

		public PersonMapper(PersonEntity entity)
		{
			this.entity = entity;
		}

		public void CopyFrom(IDictionary<string, object> formData)
		{
			if (formData.ContainsKey("name"))
				entity.Name = (string)formData["name"];

			if (formData.ContainsKey("dob"))
				entity.DOB = (DateTime)formData["dob"];
		}
	}
}
