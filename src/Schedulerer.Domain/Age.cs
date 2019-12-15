using System.Collections.Generic;
using LanguageExt;
using LanguageExt.Common;
using Schedulerer.Domain.Core;

namespace Schedulerer.Domain
{
    public class Age : ValueObject
    {
        private readonly int _age;

        private Age(int age)
        {
            _age = age;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return _age;
        }

        public override string ToString() => _age.ToString();
        public static bool operator <(Age a1, Age a2) => a1._age < a2._age;
        public static bool operator >(Age a1, Age a2) => a1._age > a2._age;
        public static implicit operator int(Age a) => a._age;

        public static Validation<Error, Age> Create(int age)
        {
            if (age < 0)
            {
                return Error.New("Age cannot be negative");
            }
            
            if (age > 18)
            {
                return Error.New("Age cannot be greater than 18");
            }

            return new Age(age);
        }
    }
}