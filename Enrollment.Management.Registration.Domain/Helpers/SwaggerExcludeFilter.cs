using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Enrollment.Management.Registration.Domain.Helpers
{
    public class SwaggerExcludeFilter : ISchemaFilter
    {
        public void Apply(OpenApiSchema schema, SchemaFilterContext context)
        {
            var type = context.Type;
            if (!schema.Properties.Any() || type == null)
            {
                return;
            }

            var excludedPropertyNames = type
                    .GetProperties()
                    .Where(
                        t => t.GetCustomAttribute<SwaggerExcludeAttribute>() != null
                    ).Select(d => d.Name).ToList();

            if (!excludedPropertyNames.Any())
            {
                return;
            }

            var excludedSchemaPropertyKey = schema.Properties
                   .Where(
                        ap => excludedPropertyNames.Any(
                            pn => pn.ToLower() == ap.Key
                        )
                    ).Select(ap => ap.Key);

            foreach (var propertyToExclude in excludedSchemaPropertyKey)
            {
                schema.Properties.Remove(propertyToExclude);
            }
        }
    }
}
