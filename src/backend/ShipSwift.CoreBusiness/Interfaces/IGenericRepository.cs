namespace ShipSwift.CoreBusiness;

public interface IGenericRepository<T> where T : class
{
    Task<T> AddAsync(T entity);
    Task DeleteAsync(T entity);
    Task<T> GetByIdAsync(int id);
    Task<List<T>> ListAsync();
    Task UpdateAsync(T entity);
    Task<T> ExecuteSingleResultStoredProcAsync(string storedProcName, params string[] parameters);
    Task<List<T>> ExecuteMultipleResultsStoredProcAsync(string storedProcName, params string[] parameters);
}
