using System;

namespace ApiPeople.Domain.Person
{
    public class PersonQueryForm
    {
        public string Name { get; set; }
        public DateTime? DOBFrom { get; set; }
        public DateTime? DOBUntil { get; set; }
    }
}
