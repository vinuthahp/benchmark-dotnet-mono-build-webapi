using System;
using System.Collections.Generic;
using ApiPeople.Domain.Person;
using ApiPeople.Utils;

namespace ApiPeople.Tests
{
	public static class PersonFixtures
	{
		public static WrapperDTO<PersonEntity> Wrapper()
		{
			return new WrapperDTO<PersonEntity>(new[] {
				Entity(),
				Entity(),
				Entity()
			});
		}

		public static PersonEntity Entity()
		{
			var input = Input();
			return Entity(input);
		}

		public static PersonEntity Entity(IDictionary<string, object> input)
		{
			var entity = new PersonEntity();
			entity.Id = new Random().Next(1, 123948);
			entity.Name = input["name"] as string;
			entity.DOB = (DateTime) input["dob"];
			return entity;
		}

		public static IDictionary<string, object> Input()
		{
			return new Dictionary<string, object>()
			{
				{ "name", String.Format("name-{0}", new Random().Next(1, 123948)) },
				{ "dob", DateTime.Now.AddDays(new Random().Next(-20, -5)) }
			};
		}

}
}
