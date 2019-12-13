using System.Collections.Generic;
using Schedulerer.Domain.Core;

namespace Schedulerer.Domain
{
    public class Name : ValueObject
    {
        public string FirstName { get; }
        public string LastName { get; }

        private Name(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return FirstName;
            yield return LastName;
        }

        public static Name Create(string firstName, string lastName)
        {
            return new Name(firstName, lastName);
        }
        
        public static readonly Name Empty = new Name("N/A", "N/A");
    }
}