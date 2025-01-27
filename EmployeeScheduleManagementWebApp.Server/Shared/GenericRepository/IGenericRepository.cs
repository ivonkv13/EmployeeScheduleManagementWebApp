namespace EmployeeScheduleManagementWebApp.Server.Shared.GenericRepository
{
    public interface IGenericRepository<T> where T : class
    {
        IQueryable<T> AsQueryable();

        Task<T?> GetByIdAsync(int id);
        Task<ICollection<T>> GetAllAsync();
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(int id);

        // Pagination method
        Task<(ICollection<T> Items, int TotalCount)> GetPaginatedAsync(int offset, int limit);
    }
}
