using Casgem_Portfolio.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Casgem_Portfolio.Repo
{
    public class GenericRepository<X> where X : class, new()
    {
        CasgemPortfolioEntities db = new CasgemPortfolioEntities();
    }
}