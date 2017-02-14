using System.Collections.Generic;
using System.Web.Http.ModelBinding;

namespace ApiPeople.Utils
{
    public interface IValidator
    {
        ModelStateDictionary Validate(IDictionary<string, object> formData);
    }
}
