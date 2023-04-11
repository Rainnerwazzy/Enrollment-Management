using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JWTAuthorization.Api.Initializer
{
    public interface IDbInitializer
    {
        public void Initialize();
    }
}
