using EmployeeScheduleManagementWebApp.Server.Infrastructure.Data;

namespace EmployeeScheduleManagementWebApp.Server.Shared.UnitOfWork
{
    /// <summary>
    /// Important!
    /// Unit of Work pattern is just partially implemented as it only handles the SaveChanges.
    /// 
    /// We miss the whole repository lifecycle and transaction control:
    /// - BeginTransaction
    /// - CommitTransaction
    /// - Rollback
    /// 
    /// We can treat every service method and request as a unit of work by implementing a middleware for handling it.
    /// 
    /// 
    /// </summary>
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
