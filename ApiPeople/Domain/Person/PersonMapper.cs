using ApiPeople.Domain.Person;
using AutoMapper;

namespace ApiPeople
{
    public class PersonMapper
	{
        private static readonly MapperConfiguration Config = new MapperConfiguration(c => c.CreateMap<PersonInputForm, PersonEntity>());

        public readonly PersonEntity entity;

		public PersonMapper(PersonEntity entity)
		{
			this.entity = entity;
		}

		public void CopyFrom(PersonInputForm formData)
		{
            Config.CreateMapper().Map(formData, entity);
		}
	}
}
