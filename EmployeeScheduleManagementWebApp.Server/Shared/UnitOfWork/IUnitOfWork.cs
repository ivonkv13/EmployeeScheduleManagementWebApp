namespace EmployeeScheduleManagementWebApp.Server.Shared.UnitOfWork
{
    public interface IUnitOfWork
    {
        Task<int> SaveChangesAsync();
    }
}
