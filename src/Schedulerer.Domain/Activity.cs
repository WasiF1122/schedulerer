using System;
using Schedulerer.Domain.Core;
using Schedulerer.Enums;

namespace Schedulerer.Domain
{
    public class Activity : Entity
    {
        public override Guid Id { get; protected set; }
        public string Name { get; protected set; }
        public Duration Duration { get; protected set; } = Duration.Regular;

        private Activity()
        {
        }

        public static Activity Create(string name, Duration duration)
        {
            return new Activity
            {
                Id = Guid.NewGuid(),
                Name = name,
                Duration = duration
            };
        }
    }
}