using System;
using Schedulerer.Domain.Core;

namespace Schedulerer.Domain
{
    public class Activity : Entity
    {
        public string Name { get; private set; }

        private Activity () { }

        private Activity (Guid id, string name)
        {
            Id = id;
            Name = name;
        }

        public static Activity Create (string name)
        {
            return new Activity (Guid.NewGuid (), name);
        }
    }
}
