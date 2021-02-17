using System.Collections.Generic;

namespace Domain.SharedKernel
{
    public abstract class BaseEntity
    {
        public List<BaseDomainEvent> Events = new List<BaseDomainEvent>();
    }
}
