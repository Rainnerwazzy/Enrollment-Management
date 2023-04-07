using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Enrollment.Management.Registration.Infrastructure.Context.Entities
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }
    }
}
