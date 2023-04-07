using System;
using System.Collections.Generic;
using System.Text;

namespace Enrollment.Management.Registration.Domain.Helpers
{
    [AttributeUsage(AttributeTargets.Property)]
    public class SwaggerExcludeAttribute : Attribute
    {
    }
}
