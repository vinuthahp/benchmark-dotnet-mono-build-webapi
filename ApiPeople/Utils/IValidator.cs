using System.Collections.Generic;
using System.Collections.Specialized;
using System.Web.Http.ModelBinding;

namespace ApiPeople.Utils
{
    public interface IValidator<TForm>
    {
        ModelStateDictionary Validate(TForm formData);
    }
}
