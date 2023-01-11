using Ardalis.Specification.EntityFrameworkCore;
using OnionSolution.Core.Application.Interfaces;
using OnionSolution.Infraestructure.EF.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionSolution.Infraestructure.EF.Persistence.Repository
{
    public class MyRepositoryAsync<T> : RepositoryBase<T>, IRepositoryAsync<T> where T : class
    {
        public MyRepositoryAsync(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
