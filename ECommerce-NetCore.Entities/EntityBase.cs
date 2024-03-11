using System;
using System.ComponentModel.DataAnnotations;

namespace ECommerce_NetCore.Entities
{
    public class EntityBase
    {
        //    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        [StringLength(36)]
        public string Id { get; set; }
        public bool Status { get; set; }

        protected EntityBase()
        {
            Id = Guid.NewGuid().ToString();
            Status = true;
        }
    }
}