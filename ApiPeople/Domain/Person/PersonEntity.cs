using System;
using System.Collections.Generic;
using System.Collections.Specialized;

namespace ApiPeople.Domain.Person
{
    public class PersonEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DOB { get; set; }

		public void CopyFrom(PersonInputForm formData)
		{
			new PersonMapper(this).CopyFrom(formData);
		}
    }
}
