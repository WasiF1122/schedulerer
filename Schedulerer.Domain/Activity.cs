using System;
using Schedulerer.Domain.Core;

namespace Schedulerer.Domain
{
    public class Activity : Entity
    {
        public string Name { get; private set; }

        private Activity() { }

        public static Activity Create(string name)
        {
            return new Activity
            {
                Id = Guid.NewGuid(),
                    Name = name
            };
        }
    }
}
