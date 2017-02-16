using System;
using System.Collections.Generic;

namespace ApiPeople.Domain.Person
{
    public class PersonEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DOB { get; set; }

		public void CopyFrom(IDictionary<string, object> formData)
		{
			new PersonMapper(this).CopyFrom(formData);
		}
    }
}
