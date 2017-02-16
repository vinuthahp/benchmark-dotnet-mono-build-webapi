using System;
using System.Collections.Generic;
using ApiPeople.Domain.Person;
using ApiPeople.Utils;
using System.Collections.Specialized;

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

		public static PersonEntity Entity(PersonInputForm input)
		{
			var entity = new PersonEntity();
			entity.Id = new Random().Next(1, 123948);
			entity.Name = input.Name;
            if (input.DOB.HasValue) entity.DOB = input.DOB.Value;
			return entity;
		}

		public static PersonInputForm Input()
		{
            return new PersonInputForm()
            {
                Name = string.Format("name-{0}", new Random().Next(1, 123948)),
                DOB = DateTime.Now.AddDays(new Random().Next(-20, -5))
            };
		}

}
}
