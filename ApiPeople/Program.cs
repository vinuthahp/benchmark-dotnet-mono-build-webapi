namespace ApiPeople
{
    public class Program
	{
		public static void Main(string[] args)
		{
            new Server(args)
				.UpdateDatabase()
				.LaunchAndWait();
        }
	}
}
