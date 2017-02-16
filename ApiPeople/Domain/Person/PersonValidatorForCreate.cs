using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Web.Http.ModelBinding;
using ApiPeople.Utils;

namespace ApiPeople.Domain.Person
{
	public class PersonValidatorForCreate : IPersonValidatorForCreate
	{
		public ModelStateDictionary Validate(PersonInputForm formData)
		{
			var state = new ModelStateDictionary();
			validateName(formData, state);
			validateDOB(formData, state);
			return state;
		}

		void validateName(PersonInputForm formData, ModelStateDictionary state)
		{
			if (string.IsNullOrEmpty(formData.Name))
				state.AddModelError("name", "required");
		}

		void validateDOB(PersonInputForm formData, ModelStateDictionary state)
		{
            if (!formData.DOB.HasValue)
                state.AddModelError("dob", "required");
            else
                if (formData.DOB.Value > DateTime.Now)
                    state.AddModelError("dob", "invalid");
        }
	}
}
