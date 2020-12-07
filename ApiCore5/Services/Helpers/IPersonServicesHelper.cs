using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiCore5.Services;
namespace ApiCore5.Services
{
    public static class IPersonServicesHelper
    {
        public static void Run(this IPersonService iPersonService)
        {
            iPersonService.Create(new Model.Person());
        }
    }
}
