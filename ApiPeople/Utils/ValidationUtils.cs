using System.Collections.Generic;

namespace ApiPeople.Utils
{
	public static class ValidationUtils
	{
		public static void Ensure(IValidator validator, IDictionary<string, object> formData)
		{
			validator.Validate(formData);
		}
	}
}
