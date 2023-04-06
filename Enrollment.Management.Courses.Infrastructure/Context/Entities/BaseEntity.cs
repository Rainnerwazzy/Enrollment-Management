using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Enrollment.Management.Courses.Infrastructure.Context.Entities
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }
    }
}
