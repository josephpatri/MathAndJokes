using Ardalis.Specification;

namespace Application.Interface
{
    public interface IBaseRepoAsync<T> : IRepositoryBase<T> where T : class
    { }

    public interface IReadBaseRepoAsync<T> : IReadRepositoryBase<T> where T : class
    { }
}