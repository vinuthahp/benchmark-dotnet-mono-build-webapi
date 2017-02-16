using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Web.Http.ModelBinding;
using ApiPeople.Utils;

namespace ApiPeople.Domain.Person
{
	public class PersonValidatorForCreate : IPersonValidatorForCreate
	{
		public ModelStateDictionary Validate(NameValueCollection formData)
		{
			var state = new ModelStateDictionary();
			validateName(formData, state);
			validateDOB(formData, state);
			return state;
		}

		void validateName(NameValueCollection formData, ModelStateDictionary state)
		{
			if (string.IsNullOrEmpty(formData["name"]))
				state.AddModelError("name", "required");
		}

		void validateDOB(NameValueCollection formData, ModelStateDictionary state)
		{
			if (string.IsNullOrEmpty(formData["dob"]))
				state.AddModelError("dob", "required");

			var aux = default(DateTime);
			if (!DateTime.TryParse(formData["dob"], out aux))
				state.AddModelError("dob", "invalid");
		}
	}
}
