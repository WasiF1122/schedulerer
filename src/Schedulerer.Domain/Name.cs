using System.Collections.Generic;
using LanguageExt;
using Schedulerer.Domain.Core;

namespace Schedulerer.Domain
{
    public class Name : ValueObject
    {
        public string FirstName { get; }
        public Option<string> MiddleName { get; }
        public string LastName { get; }

        public string DisplayName =>
            MiddleName.Map(s => $"{FirstName} {s} {LastName}").IfNone($"{FirstName} {LastName}");

        private Name(string firstName, string middleName, string lastName)
        {
            FirstName = firstName;
            MiddleName = middleName;
            LastName = lastName;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return FirstName.ToUpperInvariant();
            yield return MiddleName.Map(s => s.ToUpperInvariant()).IfNone(string.Empty);
            yield return LastName.ToUpperInvariant();
        }

        public static Name Create(string firstName, string lastName)
        {
            return new Name(firstName, null, lastName);
        }

        public static Name Create(string firstName, string middleName, string lastName)
        {
            return new Name(firstName, string.IsNullOrWhiteSpace(middleName) ? null : middleName, lastName);
        }
    }
}