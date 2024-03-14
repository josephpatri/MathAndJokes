using Application.Interface;
using Ardalis.Specification.EntityFrameworkCore;
using Persistence.Context;

namespace Persistence.Repos
{
    public class BaseRepoAsync<T> : RepositoryBase<T>, IBaseRepoAsync<T> where T : class
    {
        private readonly AppDbContext _context;

        public BaseRepoAsync(AppDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
