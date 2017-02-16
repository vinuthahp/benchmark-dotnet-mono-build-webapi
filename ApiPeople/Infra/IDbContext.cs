using System;
using System.Data.Entity;
using ApiPeople.Domain.Person;

namespace ApiPeople
{
	public interface IDbContext
	{
		IDbSet<PersonEntity> People { get; set; }

		int SaveChanges();
	}
}
