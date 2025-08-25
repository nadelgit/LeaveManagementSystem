using LeaveManagementSystem.Web.Models.LeaveTypes;

namespace LeaveManagementSystem.Web.Services
{
    public interface ILeaveTypesService
    {
        Task Create(LeaveTypeCreateVM model);
        Task Delete(int? id);
        Task Edit(LeaveTypeEditVM model);
        Task<T> Get<T>(int id) where T : class;
        Task<List<LeaveTypeReadOnlyVM>> GetAll();
    }
}