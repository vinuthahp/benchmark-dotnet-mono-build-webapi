using System;
using System.Data.Entity;
using ApiPeople.Domain.Person;

namespace ApiPeople
{
	public class EF6Context : DbContext, IDbContext
	{
		public EF6Context() : base("name=DataServices")
		{
		}

		public IDbSet<PersonEntity> People { get; set; }

		void IDbContext.SaveChanges()
		{
			base.SaveChanges();
		}
	}
}
