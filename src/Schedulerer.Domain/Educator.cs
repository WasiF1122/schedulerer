using System;
using Schedulerer.Domain.Core;

namespace Schedulerer.Domain
{
    public class Educator : Entity
    {
        public override Guid Id { get; protected set; }
        public Name Name { get; protected set; } = Name.Empty;
        public Activity Activity { get; protected set; }
    }
}