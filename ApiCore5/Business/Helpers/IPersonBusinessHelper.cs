using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiCore5.Business;
using ApiCore5.Business.Implementations;

namespace ApiCore5.Business
{
    public static class IPersonBusinessHelper
    {
        public static void Run(this IPersonBusiness iPersonBusiness)
        {
            iPersonBusiness.Create(new Model.Person());
        }
    }
}
