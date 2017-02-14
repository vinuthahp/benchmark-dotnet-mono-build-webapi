using System;
using System.Collections.Generic;
using System.Web.Http.ModelBinding;
using ApiPeople.Utils;

namespace ApiPeople.Domain.Person
{
	public class PersonValidatorForCreate : IPersonValidatorForCreate
	{
		public ModelStateDictionary Validate(IDictionary<string, object> formData)
		{
			var state = new ModelStateDictionary();
			validateName(formData, state);
			validateDOB(formData, state);
			return state;
		}

		void validateName(IDictionary<string, object> formData, ModelStateDictionary state)
		{
			if (!formData.ContainsKey("name"))
				state.AddModelError("name", "required");

			if (formData["name"].GetType() != typeof(string))
				state.AddModelError("name", "invalid");
		}

		void validateDOB(IDictionary<string, object> formData, ModelStateDictionary state)
		{
			if (!formData.ContainsKey("dob"))
				state.AddModelError("dob", "required");

			if (formData["dob"].GetType() != typeof(DateTime))
				state.AddModelError("dob", "invalid");
		}
	}
}
