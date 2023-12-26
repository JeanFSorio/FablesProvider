namespace FablesProvider.Core;

public interface IRepository
{
    Task<IList<T>> GetAll<T>() where T : DbEntityBase;

    Task<T> Get<T>(int id) where T : DbEntityBase;

    Task Add<T>(T item) where T : DbEntityBase;

    Task Edit<T>(T item) where T : DbEntityBase;

    Task Delete<T>(int id) where T : DbEntityBase;
}
