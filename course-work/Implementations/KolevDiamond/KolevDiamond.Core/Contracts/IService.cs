namespace KolevDiamond.Core.Contracts
{
    public interface IService<T>
    {
        Task Create(T model);
        Task Delete(int id);
        Task Update(int id, T model);
    }
}
