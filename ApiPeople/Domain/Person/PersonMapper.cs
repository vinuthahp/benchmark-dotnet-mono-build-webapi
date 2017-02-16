using System;
using System.Collections.Generic;
using System.Collections.Specialized;
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

		public void CopyFrom(NameValueCollection formData)
		{
			if (formData["name"] != null)
				entity.Name = formData["name"];

			if (formData["dob"] != null)
				entity.DOB = DateTime.Parse(formData["dob"]);
		}
	}
}
