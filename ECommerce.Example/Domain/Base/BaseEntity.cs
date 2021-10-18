using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain.Base
{
    public abstract class BaseEntity
    {
         
    }

    public abstract class BaseEntity<TKey> : BaseEntity
    {
        [Key]
        public TKey Id { get; set; }
    }
}
