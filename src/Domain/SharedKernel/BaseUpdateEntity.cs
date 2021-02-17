using System;

namespace Domain.SharedKernel
{
    public abstract class BaseUpdateEntity : BaseEntity
    {
        public DateTime? CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifiedAt { get; set; }
        public string ModifiedBy { get; set; }
    }
}
