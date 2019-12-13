using System;
using System.Collections.Generic;
using Schedulerer.Domain.Core;

namespace Schedulerer.Domain
{
    public class Child : Entity
    {
        private readonly List<Activity> _activities = new List<Activity>();

        public override Guid Id { get; protected set; }
        public Name Name { get; private set; } = Name.Empty;
        public IReadOnlyCollection<Activity> Activities => _activities.AsReadOnly();

        private Child()
        {
        }

        public void AddActivities(IEnumerable<Activity> activities)
        {
            _activities.AddRange(activities);
        }
    }
}