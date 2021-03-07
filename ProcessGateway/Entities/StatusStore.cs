using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ProcessGateway.Entities
{
    public class StatusStore<Tkey>
    {
        [Required]
        [MaxLength(30)]
        public virtual Tkey PId { get; set; }
        public virtual DateTime CreatedAt { get; set; } = DateTime.Now;

        public virtual DateTime ModifiedAt { get; set; } = DateTime.MinValue;
    }
}
