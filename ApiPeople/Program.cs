using ApiPeople.Migrations;
using System.Data.Entity;

namespace ApiPeople
{
    public class Program
	{
		public static void Main(string[] args)
		{
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<EF6Context, Configuration>());
            new Server(args).Launch();
        }
	}
}
